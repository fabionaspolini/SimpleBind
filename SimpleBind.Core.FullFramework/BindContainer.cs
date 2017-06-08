using SimpleBind.Core.BindHandler;
using SimpleBind.Core.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleBind.Core
{
    public abstract class BindContainer
    {
        internal abstract void BroadcastValueChanged(object sender, string bindName, object value, BindHandlerOrientation orientation);
        internal abstract void BroadcastValueChanged(object sender, Expression<Func<object, object>> bindExpression, object value, BindHandlerOrientation orientation);
    }

    public class BindContainer<TSource> : BindContainer
    {
        #region Variáveis

        private readonly List<IBindedItem> _bindedItems = new List<IBindedItem>();
        private readonly List<IBindHandler> _handlers = new List<IBindHandler>();
        private IBindedItem[] _currentWorkSourceToDestBidings;
        private IBindedItem[] _currentWorkDestToSourceBidings;

        #endregion

        #region Propriedades

        public bool Applyed { get; private set; } = false;

        /// <summary>
        /// Instância do objeto origem dos dados, não pode ser modificado após execução do método <see cref="Apply"/>
        /// </summary>
        public TSource Source { get; set; }

        public ICollection<IBindedItem> BindedItems => _bindedItems;

        #endregion

        #region Construtor

        public BindContainer()
        {
        }

        public BindContainer(TSource source)
        {
            Source = source;;
        }

        #endregion

        #region Métodos de acesso ao programador

        /// <summary>
        /// Inicializar um novo controlador de eventos
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="destInstance"></param>
        /// <returns></returns>
        public BindedItem<TSource, TDest> CreateBind<TDest>(TDest destInstance)
        {
            if (Applyed)
                throw new Exception("Não é possível criar novos bind's enquanto a configuração atual estiver aplicada!");

            var lBindedItem = new BindedItem<TSource, TDest>(this, destInstance);
            _bindedItems.Add(lBindedItem);
            return lBindedItem;
        }

        /// <summary>
        /// Aplicar bind's
        /// </summary>
        public void Apply()
        {
            if (Applyed)
                return;

            RemoveControlsBinds();

            if (!BindedItems.Any())
                return;

            if (Source == null)
                throw new Exception("Não é possível aplicar configurações de Bind sem informar o controle de origem (Source)!");

            Applyed = true;
            ApplySourceToDestBindings();
            ApplyDestToSourceBindings();
            RefreshControlsValues();
        }

        /// <summary>
        /// Limpar e remover todos os manipuladores de bind criados pelo framework
        /// </summary>
        public void Clear()
        {
            lock (this)
            {
                RemoveControlsBinds();

                Applyed = false;
                _handlers.Clear();
                _bindedItems.Clear();
                _currentWorkSourceToDestBidings = null;
                _currentWorkDestToSourceBidings = null;
            }
        }

        /// <summary>
        /// Remover controle de bind's que foram adicionados aos eventos
        /// </summary>
        public void RemoveControlsBinds()
        {
            Applyed = false;
            foreach (var lHandler in _handlers)
                lHandler.Remove();
            _handlers.Clear();
        }

        /// <summary>
        /// Atualizar os dados controladoes no sentido SourceToDest e DestToSource, dados controlados TwoWay são tratados como SourceToDest
        /// </summary>
        public void RefreshControlsValues() => InternalRefreshControlsValues();

        #endregion

        #region Aplicar eventos para escutar alterações de propriedades

        private void ApplySourceToDestBindings()
        {
            if (_bindedItems.Any(b => b.IsCompatibleOrientarion(BindHandlerOrientation.SourceToDest)))
                CreateBindHandlers(Source.GetType(), Source, null, BindHandlerOrientation.SourceToDest);
        }

        private void ApplyDestToSourceBindings()
         {
            var lBindinds = _bindedItems
                .Where(b => b.IsCompatibleOrientarion(BindHandlerOrientation.DestToSource))
                .ToArray();

            foreach (var lBindedItem in lBindinds)
            {
                var lViewType = lBindedItem.DestInstance.GetType();
                CreateBindHandlers(lViewType, lBindedItem.DestInstance, lBindedItem, BindHandlerOrientation.DestToSource);
            }
        }

        /// <summary>
        /// Instanciar o manipulador referente ao tipo da classe indicada
        /// </summary>
        /// <param name="objectClassType"></param>
        /// <param name="objectInstance"></param>
        /// <param name="bindedItem"></param>
        /// <param name="orientation"></param>
        private void CreateBindHandlers(Type objectClassType, object objectInstance, IBindedItem bindedItem, BindHandlerOrientation orientation)
        {
            var lHandlersConfig = BindEngine.Platform.Handlers.GetHandlers(objectClassType);

            if (lHandlersConfig.Any())
            {
                foreach (var lConfig in lHandlersConfig)
                    if (!_handlers.Any(h => h.Item == objectInstance && h.GetType() == lConfig.HandlerType))
                    {
                        var lHandler = lConfig.CreateHandlerInstance(this, objectInstance, bindedItem, orientation);
                        lHandler.Apply();
                        _handlers.Add(lHandler);
                    }
            }
        }

        #endregion

        #region Broadcast - Tratar notificações de alterações de propriedades

        internal override void BroadcastValueChanged(object sender, string bindName, object value, BindHandlerOrientation orientation)
        {
            var lBindings = GetBindedItemsFrom(sender, bindName, orientation);
            if (!lBindings.Any())
                return;

            if (orientation != BindHandlerOrientation.SourceToDest && orientation != BindHandlerOrientation.DestToSource)
                throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Orientação do bind inesperada para requisição solicitada");

            lock (this)
            {
                SetCurrentWorkBindings(lBindings, orientation);
                try
                {
                    foreach (var lBindedItem in lBindings)
                        if (AllowSetBindedItemValue(lBindedItem, orientation))
                        {
                            var lBindConfig = orientation == BindHandlerOrientation.DestToSource
                                ? lBindedItem.Source
                                : lBindedItem.Dest;
                            var lInstanceObj = orientation == BindHandlerOrientation.DestToSource
                                ? Source
                                : lBindedItem.DestInstance;

                            var lValue = value;
                            if (lBindConfig.SetterDataConverterDelegate != null)
                                lValue = lBindConfig.SetterDataConverterDelegate(Source, lBindedItem.DestInstance, lValue);

                            if (lBindConfig.SetterMethodDelegate != null)
                                lBindConfig.SetterMethodDelegate(Source, lBindedItem.DestInstance, lValue);
                            else
                                SetMemberValue(lInstanceObj, lBindConfig, lValue);
                        }
                }
                finally
                {
                    SetCurrentWorkBindings(null, orientation);
                }
            }
        }

        internal override void BroadcastValueChanged(object sender, Expression<Func<object, object>> bindExpression, object value, BindHandlerOrientation orientation)
        {
            var lMember = BindUtils.GetExpressionMember(bindExpression);
            if (!string.IsNullOrWhiteSpace(lMember?.Name))
                BroadcastValueChanged(sender, lMember.Name, value, orientation);
        }

        /// <summary>
        /// Obter bind's configurados como origem os dados informados nos argumentos <see cref="instance"/> e <see cref="bindName"/> de acordo com o contexto requisitado em <see cref="orientation"/>
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindName"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        private IBindedItem[] GetBindedItemsFrom(object instance, string bindName, BindHandlerOrientation orientation)
        {
            if (string.IsNullOrWhiteSpace(bindName))
                throw new ArgumentNullException(nameof(bindName), "Informe o nome do bind para obter configurações");

            var lRet = _bindedItems.ToArray();
            switch (orientation)
            {
                case BindHandlerOrientation.SourceToDest:
                    lRet = lRet
                        .Where(b => b.Source.Name == bindName &&
                                    b.IsCompatibleOrientarion(BindHandlerOrientation.SourceToDest))
                        .ToArray();
                    break;
                case BindHandlerOrientation.DestToSource:
                    lRet = lRet
                        .Where(b => b.DestInstance == instance &&
                                    b.Dest.Name == bindName &&
                                    b.IsCompatibleOrientarion(BindHandlerOrientation.DestToSource))
                        .ToArray();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Orientação do bind inesperada para requisição solicitada");
            }

            return lRet;
        }

        #endregion

        #region Refresh

        /// <summary>
        /// Atualizar os dados controladoes no sentido SourceToDest e DestToSource, dados controlados TwoWay são tratados como SourceToDest
        /// </summary>
        private void InternalRefreshControlsValues()
        {
            // SourceToDest and TwoWay
            var lBindings = _bindedItems
                .Where(b => b.IsCompatibleOrientarion(BindHandlerOrientation.SourceToDest))
                .ToArray();

            if (lBindings.Any())
            {
                lock (this)
                {
                    SetCurrentWorkBindings(lBindings, BindHandlerOrientation.SourceToDest);
                    try
                    {
                        foreach (var lBindedItem in lBindings)
                            if (AllowSetBindedItemValue(lBindedItem, BindHandlerOrientation.SourceToDest))
                            {
                                var lValue = GetMemberValue(Source, lBindedItem.DestInstance, lBindedItem.Source, lBindedItem.Dest);
                                if (lBindedItem.Dest.SetterMethodDelegate != null)
                                    lBindedItem.Dest.SetterMethodDelegate(Source, lBindedItem.DestInstance, lValue);
                                else
                                    SetMemberValue(lBindedItem.DestInstance, lBindedItem.Dest, lValue);
                            }
                    }
                    finally
                    {
                        SetCurrentWorkBindings(null, BindHandlerOrientation.SourceToDest);
                    }
                }
            }

            // DestToSource
            lBindings = _bindedItems
                .Where(b => b.Orientarion == BindOrientarion.DestToSource)
                .ToArray();

            if (lBindings.Any())
            {
                lock (this)
                {
                    SetCurrentWorkBindings(lBindings, BindHandlerOrientation.DestToSource);
                    try
                    {
                        foreach (var lBindedItem in lBindings)
                            if (AllowSetBindedItemValue(lBindedItem, BindHandlerOrientation.DestToSource))
                            {
                                var lValue = GetMemberValue(lBindedItem.DestInstance, lBindedItem.DestInstance, lBindedItem.Dest, lBindedItem.Source);
                                if (lBindedItem.Source.SetterMethodDelegate != null)
                                    lBindedItem.Source.SetterMethodDelegate(Source, lBindedItem.DestInstance, lValue);
                                else
                                    SetMemberValue(Source, lBindedItem.Source, lValue);
                            }
                    }
                    finally
                    {
                        SetCurrentWorkBindings(null, BindHandlerOrientation.DestToSource);
                    }
                }
            }
        }

        private object GetMemberValue(object objectInstance, object destInstance, BindedItemConfig sourceBindConfig, BindedItemConfig destBindConfig)
        {
            object lValue;
            if (sourceBindConfig.Member is PropertyInfo)
            {
                var lProp = (PropertyInfo)sourceBindConfig.Member;
                lValue = lProp.GetValue(objectInstance);
            }
            else if (sourceBindConfig.Member is FieldInfo)
            {
                var lField = (FieldInfo)sourceBindConfig.Member;
                lValue = lField.GetValue(objectInstance);
            }
            else if (sourceBindConfig.Member is MethodInfo)
            {
                var lMethod = (MethodInfo)sourceBindConfig.Member;
                lValue = lMethod.Invoke(objectInstance, null);
            }
            else
                throw new ArgumentException("Tipo de expressão não suportada para obter valor: " + sourceBindConfig.Member?.GetType().Name, nameof(sourceBindConfig));

            //
            if (destBindConfig.SetterDataConverterDelegate != null)
                lValue = destBindConfig.SetterDataConverterDelegate(Source, destInstance, lValue);

            //
            return lValue;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Definir bind's que estão sendo processados no momento para travar execução concorrentes de direção contrária
        /// </summary>
        /// <param name="bindedItems"></param>
        /// <param name="orientation"></param>
        private void SetCurrentWorkBindings(IBindedItem[] bindedItems, BindHandlerOrientation orientation)
        {
            switch (orientation)
            {
                case BindHandlerOrientation.SourceToDest:
                    _currentWorkSourceToDestBidings = bindedItems;
                    break;
                case BindHandlerOrientation.DestToSource:
                    _currentWorkDestToSourceBidings = bindedItems;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Orientação do bind inesperada para requisição solicitada");
            }
        }

        /// <summary>
        /// Permitir atribuição de valor ao objeto configurada no bind. Enquanto o framework estiver atribuindo um valor, uma atribuição concorrente no sentido contrário ficará bloqueada
        /// </summary>
        /// <param name="bindedItem"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        private bool AllowSetBindedItemValue(IBindedItem bindedItem, BindHandlerOrientation orientation)
        {
            switch (orientation)
            {
                case BindHandlerOrientation.SourceToDest:
                    return _currentWorkDestToSourceBidings == null || !_currentWorkDestToSourceBidings.Contains(bindedItem);
                case BindHandlerOrientation.DestToSource:
                    return _currentWorkSourceToDestBidings == null || !_currentWorkSourceToDestBidings.Contains(bindedItem);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, "Orientação do bind inesperada para requisição solicitada");
            }
        }

        /// <summary>
        /// Atribuir valor para o membro (Propriedade/Variável) indicado na expressão
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bind"></param>
        /// <param name="value">Valor padrão que foi definido no componente origem para atribuir ao destino. Se haver algum método de conversão "SetterDataConverterDelegate" configurado, já deve estar com a conversão aplicada</param>
        private void SetMemberValue(object instance, BindedItemConfig bind, object value)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance), "Instância não informada para atribuir valor!");

            if (bind?.Member == null)
                throw new ArgumentNullException(nameof(bind), "Bind ou membro não informado para atribuir valor!");

            var lExecuteDefaultConvertes = bind.SetterDataConverterDelegate == null;
            if (bind.Member is PropertyInfo)
            {
                var lProp = (PropertyInfo) bind.Member;
                var lValue = ConvertValue(value, lProp.PropertyType, lExecuteDefaultConvertes);
                lProp.SetValue(instance, lValue);
            }
            else if (bind.Member is FieldInfo)
            {
                var lField = (FieldInfo) bind.Member;
                var lValue = ConvertValue(value, lField.FieldType, lExecuteDefaultConvertes);
                lField.SetValue(instance, lValue);
            }
            else
                throw new Exception("MemberInfo inesperado atribuir valor: " + bind.Member?.GetType().FullName);
        }

        /// <summary>
        /// Converter valor para o tipo especifícado
        /// </summary>
        /// <param name="aValue"></param>
        /// <param name="aDesType"></param>
        /// <param name="aExecuteDefaultConvertes">Executar conversores de dados padrão do framework, deve ser verdadeiro quando não haver um customizado para o bind configurado pelo desenvolvedor</param>
        /// <returns></returns>
        private object ConvertValue(object aValue, Type aDesType, bool aExecuteDefaultConvertes)
        {
            if (aValue == null)
                return null;

            // Se o tipo de dados destino, for herdado do valor a ser convertido, não é necessário converter e retorna o próprio valor origem
            if (aDesType.IsInstanceOfType(aValue))
                return aValue;

            // C# Type -> Plataform Type (Java.Lang.Object)
            if (BindEngine.Platform.IsPlatformType(aDesType))
                return BindEngine.Platform.ToPlataformValue(aValue);

            // Plataform Type (Java.Lang.Object) -> C# Type
            if (BindEngine.Platform.IsPlatformType(aValue.GetType()))
                return BindEngine.Platform.ToDotNetValue(aValue);

            // Conversões de valores padrões
            if (aExecuteDefaultConvertes)
                return BindEngine.ToValue(aValue.GetType(), aDesType, aValue);

            return aValue;
        }

        #endregion
    }
}