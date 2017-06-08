using SimpleBind.Core.BindHandler;
using System;
using System.Linq;
using SimpleBind.Core.Interface;

namespace SimpleBind.Core
{
    public abstract class BindPlatform : IBindPlatform
    {
        /* Tipos básicos:
        - bool
        - byte
        - char
        - decimal
        - double
        - float
        - int
        - long
        - sbyte
        - short
        - string
        - DateTime */
        public static readonly Type[] DotNetPrimitiveTypes =
        {
            typeof(bool),
            typeof(byte),
            typeof(char),
            typeof(decimal),
            typeof(double),
            typeof(float),
            typeof(int),
            typeof(long),
            typeof(sbyte),
            typeof(short),
            typeof(string),
            typeof(DateTime)
        };

        public BindDataConverters DataConverters { get; } = new BindDataConverters();
        public BindHandlerConfigs Handlers { get; } = new BindHandlerConfigs();

        #region Construtor

        protected BindPlatform()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            RegisterDefaultDataConverters(DataConverters);
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            RegisterDefaultHandlersConfig(Handlers);
        }

        #endregion

        #region IBindPlatform

        public object ToPlataformValue(object dotNetValue)
        {
            if (dotNetValue == null)
                return null;

            try
            {
                return DataConverters.ConvertFromSourceType(dotNetValue.GetType(), dotNetValue);
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format("Não foi possível converter para tipo de dados da plataforma.\nValor: {0}\n.NET Type: {1}",
                        dotNetValue, dotNetValue.GetType().FullName), e);
            }
        }

        public object ToDotNetValue(object plataformValue)
        {
            if (plataformValue == null)
                return null;

            try
            {
                return DataConverters.ConvertFromSourceType(plataformValue.GetType(), plataformValue);
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format("Não foi possível converter para tipo de dados .NET.\nValor: {0}\nPlataform Type: {1}",
                        plataformValue, plataformValue.GetType().FullName), e);
            }
        }

        public bool IsDotNetPrimitiveType(Type type)
        {
            return DotNetPrimitiveTypes.Contains(type);
        }

        #endregion

        public abstract bool IsPlatformType(Type type);
        public abstract bool IsPlataformPrimitiveType(Type type);
        protected abstract void RegisterDefaultDataConverters(BindDataConverters converters);
        protected abstract void RegisterDefaultHandlersConfig(BindHandlerConfigs handlers);
    }
}
