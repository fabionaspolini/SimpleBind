using SimpleBind.Core.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleBind.Core.BindHandler
{
    /// <summary>
    /// Indicar ao container a dire��o que o manipulador est� trabalhando
    /// </summary>
    public enum BindHandlerOrientation
    {
        /// <summary>
        /// Indicar altera��es no contexto origem para destino
        /// </summary>
        SourceToDest,

        /// <summary>
        /// Indicar altera�oes no contexto destino para origem
        /// </summary>
        DestToSource
    }

    /// <summary>
    /// Respons�vel por adicionar os eventos para controle de bind a um objeto
    /// </summary>
    public interface IBindHandler
    {
        /// <summary>
        /// Tipo da classe controlada por este manipulador
        /// </summary>
        object Item { get; }

        /// <summary>
        /// Aplicar configura��es necess�rias para escutar altera��es das propriedades do objeto
        /// </summary>
        void Apply();

        /// <summary>
        /// Remover configura��es de escuta de altera��es de propriedades definidas pelo m�todo <see cref="Apply"/>
        /// </summary>
        void Remove();
    }

    /// <summary>
    /// Respons�vel por adicionar os eventos para controle de bind ao objeto refer�nciado na propriedade <see cref="Item"/>
    /// </summary>
    /// <typeparam name="TType">Classe a ser adicionado os manipuladores de bind</typeparam>
    public abstract class BindHandler<TType> : IBindHandler
    {
        // Escondendo propriedade da interface para expor a propriedade com o tipo configurado no generic type
        object IBindHandler.Item => Item;

        /// <summary>
        /// Container de aplica��o de bind que criou o manipulador
        /// </summary>
        public BindContainer Container { get; }

        /// <summary>
        /// Configura��es do bind que originou esta inst�ncia do manipulador
        /// </summary>
        public IBindedItem Config { get; }

        /// <summary>
        /// Tipo da classe controlada por este manipulador
        /// </summary>
        public TType Item { get; }

        /// <summary>
        /// Orienta��o para qual este manipulador foi criado. Indica se a propriedade alterada ser� na orgem origem para destino ou destino para origem
        /// </summary>
        public BindHandlerOrientation Orientation { get; private set; }

        /// <summary>
        /// Construtor padr�o, toda classe que herdar desta deve possuir este mesmo construtor
        /// </summary>
        /// <param name="container"></param>
        /// <param name="item"></param>
        /// <param name="config"></param>
        /// <param name="orientation"></param>
        protected BindHandler(BindContainer container, TType item, IBindedItem config, BindHandlerOrientation orientation)
        {
            Container = container;
            Item = item;
            Config = config;
            Orientation = orientation;
        }

        /// <summary>
        /// Aplicar configura��es necess�rias para escutar altera��es das propriedades do objeto referenciado em <see cref="Item"/>
        /// </summary>
        public abstract void Apply();

        /// <summary>
        /// Remover configura��es de escuta de altera��es de propriedades definidas pelo m�todo <see cref="Apply"/>
        /// </summary>
        public abstract void Remove();

        /// <summary>
        /// Notificar ao container uma mudan�a de valor da propriedade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bindName"></param>
        /// <param name="value"></param>
        protected void BroadcastValueChanged(object sender, string bindName, object value)
        {
            Container.BroadcastValueChanged(sender, bindName, value, Orientation);
        }

        /// <summary>
        /// Notificar ao container uma mudan�a de valor da propriedade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bindExpression"></param>
        /// <param name="value"></param>
        protected void BroadcastValueChanged(object sender, Expression<Func<object, object>> bindExpression, object value)
        {
            Container.BroadcastValueChanged(sender, bindExpression, value, Orientation);
        }
    }

    /// <summary>
    /// Configurar manipulador para o tipo de dados, atrav�s da propriedade <see cref="HandlerType"/> vinculamos um manipulador para tratar todos os objetos da classe espec�ficada em <see cref="ClassType"/>
    /// </summary>
    public class BindHandlerConfig
    {
        /// <summary>
        /// No construtor verificado se a classe indicada para o manipulador em <see cref="HandlerType"/> � v�lida e carrega a refer�ncia ao construtor padr�o utilizado pelo framework
        /// </summary>
        private ConstructorInfo _constructor;

        /// <summary>
        /// Classe da aplica��o do usu�rio
        /// </summary>
        public Type ClassType { get; }

        /// <summary>
        /// Manipulador definido a partir de <see cref="IBindHandler"/> que � respons�vel por gerenciar as altera��es de propriedades da classe <see cref="ClassType"/>
        /// </summary>
        public Type HandlerType { get; }

        /// <summary>
        /// Indica que a configura��o tamb�m se aplica a classes herdadas de <see cref="ClassType"/>
        /// </summary>
        public bool EnableForInherited { get; }

        /// <summary>
        /// Construtor padr�o
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="handlerType"></param>
        /// <param name="enableForInherited"></param>
        protected BindHandlerConfig(Type classType, Type handlerType, bool enableForInherited = true)
        {
            if (classType == null)
                throw new ArgumentNullException(nameof(classType));

            if (handlerType == null)
                throw new ArgumentNullException(nameof(handlerType));

            ClassType = classType;
            HandlerType = handlerType;
            EnableForInherited = enableForInherited;

            LoadDefaultConstructor();
        }

        /// <summary>
        /// Buscar construtor padr�o esperado pelo framework definido no manipulador v�nculado em <see cref="HandlerType"/>
        /// </summary>
        /// <exception cref="Exception">Nenhum construtor definido na classe <see cref="HandlerType"/> utilizando os par�metros do tipo: <see cref="BindContainer"/>, <see cref="ClassType"/>, <see cref="IBindedItem"/> e <see cref="BindHandlerOrientation"/></exception>
        private void LoadDefaultConstructor()
        {
            _constructor = HandlerType.GetConstructor(new[]
            {
                typeof (BindContainer),
                ClassType,
                typeof(IBindedItem),
                typeof(BindHandlerOrientation)
            });

            if (_constructor == null)
                throw new Exception($"Construtor padr�o para bind handler n�o encontrado.\nBind handler type: {ClassType.FullName}");
        }

        /// <summary>
        /// Criar uma nova inst�ncia do manipulador indicado em <see cref="HandlerType"/>, vinculando ao container, objeto, configura�oes de bind e indicando a dire��o do mesmo
        /// </summary>
        /// <param name="container"></param>
        /// <param name="item"></param>
        /// <param name="config"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public IBindHandler CreateHandlerInstance(BindContainer container, object item, IBindedItem config, BindHandlerOrientation orientation)
        {
            var lHandler = (IBindHandler) _constructor.Invoke(new[] {container, item, config, orientation});
            return lHandler;
        }
    }

    /// <summary>
    /// Configurar manipulador para o tipo de dados, atrav�s do generic type <see cref="THandlerType"/> vinculamos um manipulador para tratar todos os objetos da classe espec�ficada no generic type <see cref="TClassType"/>
    /// </summary>
    /// <typeparam name="TClassType">Classe da aplica��o do usu�rio</typeparam>
    /// <typeparam name="THandlerType">Manipulador definido a partir de <see cref="IBindHandler"/> que � respons�vel por gerenciar as altera��es de propriedades da classe <see cref="TClassType"/></typeparam>
    public class BindHandlerConfig<TClassType, THandlerType> : BindHandlerConfig
        where THandlerType : IBindHandler
    {
        /// <summary>
        /// Construtor padr�o
        /// </summary>
        /// <param name="enableForInherited"></param>
        public BindHandlerConfig(bool enableForInherited = true) : base(typeof(TClassType), typeof(THandlerType), enableForInherited)
        {
        }
    }

    /// <summary>
    /// Container para configura��es de manipuladores
    /// </summary>
    public class BindHandlerConfigs
    {
        private readonly List<BindHandlerConfig> _handlers = new List<BindHandlerConfig>();

        public void Register(BindHandlerConfig config)
        {
            _handlers.RemoveAll(h => h.ClassType == config.ClassType && h.HandlerType == config.HandlerType);
            _handlers.Add(config);
        }

        public void Register<TClassType, THandlerType>(bool enableForInherited = true) where THandlerType : IBindHandler
        {
            Register(new BindHandlerConfig<TClassType,THandlerType>());
        }

        public BindHandlerConfig[] GetHandlers(Type objectClassType)
        {
            return _handlers
                .Where(h => h.ClassType == objectClassType ||
                            (h.EnableForInherited && h.ClassType.IsAssignableFrom(objectClassType)))
                .ToArray();
        }
    }
}