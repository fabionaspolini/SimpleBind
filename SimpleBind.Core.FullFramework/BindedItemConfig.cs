using SimpleBind.Core.BindHandler;
using SimpleBind.Core.Lib;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleBind.Core
{
    /// <summary>
    /// Direção que o bind será aplicado
    /// </summary>
    public enum BindOrientarion
    {
        SourceToDest,
        DestToSource,
        TwoWay
    }

    public delegate object DataConverterDelegate(object source, object dest, object value);
    public delegate object DataConverterDelegate<in TSource, in TDest, in TSourcePropType>(TSource source, TDest dest, TSourcePropType value);

    public delegate void BindSetValueAsMethodDelegate(object source, object dest, object value);
    public delegate void BindSetValueAsMethodDelegate<in TSource, in TDest>(TSource source, TDest dest, object value);
    public delegate void BindSetValueAsMethodDelegate<in TSource, in TDest, in TSourcePropType>(TSource source, TDest dest, TSourcePropType value);

    public class BindedItemConfig
    {
        public Expression Expression { get; internal set; }
        public MemberInfo Member { get; internal set; }
        public string Name { get; internal set; }
        public DataConverterDelegate SetterDataConverterDelegate { get; internal set; }
        public BindSetValueAsMethodDelegate SetterMethodDelegate { get; internal set; }

        public bool CompareExpressionMember(Expression expression)
        {
            var lMember1 = BindUtils.GetExpressionMember(this.Expression);
            var lMember2 = BindUtils.GetExpressionMember(expression);
            return lMember1 == lMember2;
        }
    }

    public class BindedItemConfig<TSource, TDest> : BindedItemConfig
    {
        public BindedItemConfig<TSource, TDest> SetterDataConverter(DataConverterDelegate converterMethod)
        {
            SetterDataConverterDelegate = converterMethod;
            return this;
        }

        public BindedItemConfig<TSource, TDest> SetterDataConverter<TSourcePropType>(DataConverterDelegate<TSource, TDest, TSourcePropType> converterMethod)
        {
            SetterDataConverterDelegate = (source, dest, value) => converterMethod((TSource) source, (TDest) dest, (TSourcePropType) value);
            return this;
        }

        public BindedItemConfig<TSource, TDest> SetterMethod(BindSetValueAsMethodDelegate<TSource, TDest> method)
        {
            SetterMethodDelegate = (source, dest, value) => method((TSource) source, (TDest) dest, value);
            return this;
        }

        public BindedItemConfig<TSource, TDest> SetterMethod<TSourcePropType>(BindSetValueAsMethodDelegate<TSource, TDest, TSourcePropType> method)
        {
            SetterMethodDelegate = (source, dest, value) => method((TSource) source, (TDest) dest, (TSourcePropType)value);
            return this;
        }
    }

    public interface IBindedItem
    {
        BindOrientarion Orientarion { get; }

        object DestInstance { get; }

        BindedItemConfig Source { get; }
        BindedItemConfig Dest { get; }

        bool IsCompatibleOrientarion(BindHandlerOrientation handlerOrientation);
    }

    public class BindedItem<TSource, TDest> : IBindedItem
    {
        #region IBindedItem - Propriedades

        BindOrientarion IBindedItem.Orientarion => Orientarion;
        private BindOrientarion Orientarion { get; set; } = BindOrientarion.TwoWay;
        //public BindOrientarion Orientarion { get; set; }

        object IBindedItem.DestInstance => DestInstance;
        private TDest DestInstance { get; }

        BindedItemConfig IBindedItem.Source => Source;
        private BindedItemConfig<TSource, TDest> Source { get; } = new BindedItemConfig<TSource, TDest>();

        BindedItemConfig IBindedItem.Dest => Dest;
        private BindedItemConfig<TSource, TDest> Dest { get; } = new BindedItemConfig<TSource, TDest>();

        #endregion

        #region Propriedades

        protected BindContainer<TSource> Container { get; }

        #endregion

        #region Construtor

        public BindedItem(BindContainer<TSource> container, TDest destInstance)
        {
            Container = container;
            DestInstance = destInstance;
        }

        #endregion

        #region IBindedItem

        bool IBindedItem.IsCompatibleOrientarion(BindHandlerOrientation handlerOrientation) => IsCompatibleOrientarion(handlerOrientation);

        private bool IsCompatibleOrientarion(BindHandlerOrientation handlerOrientation)
        {
            if (handlerOrientation == BindHandlerOrientation.SourceToDest)
                return Orientarion == BindOrientarion.TwoWay || Orientarion == BindOrientarion.SourceToDest;

            if (handlerOrientation == BindHandlerOrientation.DestToSource)
                return Orientarion == BindOrientarion.TwoWay || Orientarion == BindOrientarion.DestToSource;

            throw new Exception("BindHandlerOrientation inesperada para verificar compatibilidade com BindOrientarion: " + handlerOrientation);
        }

        #endregion

        #region Configurações do bind

        public BindedItem<TSource, TDest> From(string sourceProp, Action<BindedItemConfig<TSource, TDest>> config = null)
        {
            if (string.IsNullOrWhiteSpace(sourceProp))
            {
                Source.Expression = null;
                Source.Member = null;
                Source.Name = null;
                config?.Invoke(Source);
            }

            Source.Member = Container.Source.GetType().GetProperty(sourceProp);
            Source.Name = sourceProp;
            config?.Invoke(Source);
            return this;
        }

        public BindedItem<TSource, TDest> From(Expression<Func<TSource, object>> sourcePropExpr, Action<BindedItemConfig<TSource, TDest>> config = null)
        {
            if (sourcePropExpr == null)
            {
                Source.Expression = null;
                Source.Member = null;
                Source.Name = null;
                config?.Invoke(Source);
                return this;
            }

            if (sourcePropExpr.Body is UnaryExpression)
            {
                var lUnaryExpr = (UnaryExpression) sourcePropExpr.Body;
                Source.Expression = lUnaryExpr.Operand;
                Source.Member = (lUnaryExpr.Operand as MemberExpression)?.Member;
            }
            else
            {
                Source.Expression = sourcePropExpr.Body;
                Source.Member = (Source.Expression as MemberExpression)?.Member;
            }

            if (Source.Member == null)
                throw new ArgumentException("Tipo de expressão informada deve ser uma propriedade!",
                    nameof(sourcePropExpr));

            Source.Name = Source.Member.Name;
            config?.Invoke(Source);
            return this;
        }

        public BindedItem<TSource, TDest> From(Action<BindedItemConfig<TSource, TDest>> config)
        {
            Source.Expression = null;
            Source.Member = null;
            Source.Name = null;
            config.Invoke(Source);
            return this;
        }

        public BindedItem<TSource, TDest> To(string destProp, Action<BindedItemConfig<TSource, TDest>> config = null)
        {
            if (string.IsNullOrWhiteSpace(destProp))
            {
                Dest.Expression = null;
                Dest.Member = null;
                Dest.Name = null;
                config?.Invoke(Dest);
            }

            Dest.Member = DestInstance.GetType().GetProperty(destProp);
            Dest.Name = destProp;
            config?.Invoke(Dest);
            return this;
        }

        public BindedItem<TSource, TDest> To(Expression<Func<TDest, object>> destPropExpr, Action<BindedItemConfig<TSource, TDest>> config = null)
        {
            if (destPropExpr == null)
            {
                Dest.Expression = null;
                Dest.Member = null;
                Dest.Name = null;
                config?.Invoke(Dest);
                return this;
            }

            if (destPropExpr.Body is UnaryExpression)
            {
                var lUnaryExpr = (UnaryExpression) destPropExpr.Body;
                Dest.Expression = lUnaryExpr.Operand;
                Dest.Member = (lUnaryExpr.Operand as MemberExpression)?.Member;
            }
            else
            {
                Dest.Expression = destPropExpr.Body;
                Dest.Member = (Dest.Expression as MemberExpression)?.Member;
            }

            if (Dest.Member == null)
                throw new ArgumentException("Tipo de expressão informada deve ser uma propriedade!",
                    nameof(destPropExpr));

            Dest.Name = Dest.Member.Name;
            config?.Invoke(Dest);
            return this;
        }

        public BindedItem<TSource, TDest> To(Action<BindedItemConfig<TSource, TDest>> config)
        {
            Dest.Expression = null;
            Dest.Member = null;
            Dest.Name = null;
            config.Invoke(Dest);
            return this;
        }

        #endregion

        #region Configurações para orientação do bind

        /// <summary>
        /// Definir direção do bind somente com o caminho de origem para destino
        /// </summary>
        /// <returns></returns>
        public BindedItem<TSource, TDest> SourceToDestWay()
        {
            Orientarion = BindOrientarion.SourceToDest;
            return this;
        }

        /// <summary>
        /// Definir direção do bind somente com o caminho de destino para origem
        /// </summary>
        /// <returns></returns>
        public BindedItem<TSource, TDest> DestToSourceWay()
        {
            Orientarion = BindOrientarion.DestToSource;
            return this;
        }

        /// <summary>
        /// Definir direção do bind nas duas formar, origem para destino e vice-versa
        /// </summary>
        /// <returns></returns>
        public BindedItem<TSource, TDest> TwoWay()
        {
            Orientarion = BindOrientarion.TwoWay;
            return this;
        }

        #endregion
    }
}