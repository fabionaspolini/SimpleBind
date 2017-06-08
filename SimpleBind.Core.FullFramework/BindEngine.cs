using SimpleBind.Core.BindHandler;
using SimpleBind.Core.Interface;
using SimpleBind.Core.Lib;
using System;
using System.ComponentModel;
using System.Globalization;

namespace SimpleBind.Core
{
    public static class BindEngine
    {
        public static readonly BindDataConverters Converters = new BindDataConverters();

        private static IBindPlatform _platform;
        public static IBindPlatform Platform
        {
            get
            {
                return _platform;
            }

            internal set
            {
                if (value == null)
                    throw new Exception("Não é possível remover o configurador de plataforma para o bind!");

                if (_platform != value)
                {
                    _platform = value;
                    RegisterHandlersConfig(_platform.Handlers);
                }
            }
        }

        public static CultureInfo DefaultCultureInfo { get; set; } = CultureInfo.InvariantCulture;

        static BindEngine()
        {
            RegisterDataConverters();
        }

        /// <summary>
        /// Configurar framework com a plataforma padrão para funcionamento
        /// </summary>
        /// <param name="platform"></param>
        public static void Initialize(IBindPlatform platform)
        {
            Platform = platform;
        }

        /// <summary>
        /// Executar conversão de dados padrão a todas as plataformas
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="value"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public static object ToValue(Type sourceType, Type destType, object value)
        {
            if (value == null)
                return null;

            // Dado destino é enum
            if (typeof(Enum).IsAssignableFrom(destType))
            {
                var lValueType = value.GetType();

                var lEnumConverterType = typeof(BindDataConverterEnum<>).MakeGenericType(lValueType);
                var lEnumConverter = Converters.GetConveter(lEnumConverterType, typeof(Enum));
                if (lEnumConverter != null)
                {
                    var lEnumData = Activator.CreateInstance(lEnumConverterType, destType, value);
                    return lEnumConverter.Convert(lEnumData);
                }
            }

            // Dado origem é enum
            if (typeof(Enum).IsAssignableFrom(sourceType))
            {
                var lEnumConverter = Converters.GetConveter(typeof(Enum), destType);
                if (lEnumConverter != null)
                    return lEnumConverter.Convert(value);
            }

            // Conversores padrões
            var lConverter = Converters.GetConveter(sourceType, destType);

            // destType is Nullable<>
            if (lConverter == null && destType.IsConstructedGenericType && destType.GetGenericTypeDefinition() == typeof(Nullable<>))
                lConverter = Converters.GetConveter(sourceType, destType.GenericTypeArguments[0]);

            // sourceType is Nullable<>
            if (lConverter == null && sourceType.IsConstructedGenericType && sourceType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                lConverter = Converters.GetConveter(sourceType.GenericTypeArguments[0], destType);

                // sourceType and destType is Nullable<>
                if (lConverter == null && destType.IsConstructedGenericType && destType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    lConverter = Converters.GetConveter(sourceType.GenericTypeArguments[0], destType.GenericTypeArguments[0]);
            }

            if (lConverter != null)
            {
                try
                {
                    return lConverter.Convert(value);
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Não foi possível converter \"{0}\" para \"{1}\".\nValor: {2}",
                        (lConverter.SourceType ?? sourceType)?.FullName,
                        (lConverter.DestType ?? destType)?.FullName,
                        value),
                    e);
                }
            }

            return value;
        }

        public static TDestType ToValue<TDestType>(Type sourceType, object value)
        {
            try
            {
                return (TDestType) ToValue(sourceType, typeof(TDestType), value);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Não foi possível realizar o cast \"{0}\" para \"{1}\".\nValor: {2}",
                        sourceType?.FullName,
                        typeof(TDestType).FullName,
                        value),
                    e);
            }
        }

        /// <summary>
        /// Registrar conversores de dados padrões a todas as plataformas
        /// </summary>
        private static void RegisterDataConverters()
        {
            // To bool
            Converters.Register<byte, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<decimal, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<double, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<float, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<int, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<long, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<short, bool>(v => Convert.ToBoolean(v, DefaultCultureInfo));
            Converters.Register<string, bool>(v => !string.IsNullOrWhiteSpace(v) && Convert.ToBoolean(v, DefaultCultureInfo));

            // To byte
            Converters.Register<decimal, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<double, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<float, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<int, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<long, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<short, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<sbyte, byte>(v => Convert.ToByte(v, DefaultCultureInfo));
            Converters.Register<string, byte>(v => string.IsNullOrWhiteSpace(v) ? default(byte) : Convert.ToByte(v, DefaultCultureInfo));

            // To char
            Converters.Register<int, char>(v => Convert.ToChar(v, DefaultCultureInfo));
            Converters.Register<long, char>(v => Convert.ToChar(v, DefaultCultureInfo));
            Converters.Register<short, char>(v => Convert.ToChar(v, DefaultCultureInfo));
            Converters.Register<string, char>(v => string.IsNullOrWhiteSpace(v) ? default(char) : Convert.ToChar(v, DefaultCultureInfo));

            // To decimal
            Converters.Register<double, decimal>(v => Convert.ToDecimal(v, DefaultCultureInfo));
            Converters.Register<float, decimal>(v => Convert.ToDecimal(v, DefaultCultureInfo));
            Converters.Register<int, decimal>(v => Convert.ToDecimal(v, DefaultCultureInfo));
            Converters.Register<long, decimal>(v => Convert.ToDecimal(v, DefaultCultureInfo));
            Converters.Register<short, decimal>(v => Convert.ToDecimal(v, DefaultCultureInfo));
            Converters.Register<string, decimal>(v => string.IsNullOrWhiteSpace(v) ? default(decimal) : Convert.ToDecimal(v, DefaultCultureInfo));

            // To double
            Converters.Register<decimal, double>(v => Convert.ToDouble(v, DefaultCultureInfo));
            Converters.Register<float, double>(v => Convert.ToDouble(v, DefaultCultureInfo));
            Converters.Register<int, double>(v => Convert.ToDouble(v, DefaultCultureInfo));
            Converters.Register<long, double>(v => Convert.ToDouble(v, DefaultCultureInfo));
            Converters.Register<short, double>(v => Convert.ToDouble(v, DefaultCultureInfo));
            Converters.Register<string, double>(v => string.IsNullOrWhiteSpace(v) ? default(double) : Convert.ToDouble(v, DefaultCultureInfo));

            // To float
            Converters.Register<decimal, float>(v => Convert.ToSingle(v, DefaultCultureInfo));
            Converters.Register<double, float>(v => Convert.ToSingle(v, DefaultCultureInfo));
            Converters.Register<int, float>(v => Convert.ToSingle(v, DefaultCultureInfo));
            Converters.Register<long, float>(v => Convert.ToSingle(v, DefaultCultureInfo));
            Converters.Register<short, float>(v => Convert.ToSingle(v, DefaultCultureInfo));
            Converters.Register<string, float>(v => string.IsNullOrWhiteSpace(v) ? default(float) : Convert.ToSingle(v, DefaultCultureInfo));

            // To int
            Converters.Register<byte, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<decimal, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<double, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<float, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<long, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<sbyte, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<short, int>(v => Convert.ToInt32(v, DefaultCultureInfo));
            Converters.Register<string, int>(v => string.IsNullOrWhiteSpace(v) ? default(int) : Convert.ToInt32(v, DefaultCultureInfo));

            Converters.Register<string, int?>(v => string.IsNullOrWhiteSpace(v) ? (int?) null : Convert.ToInt32(v, DefaultCultureInfo));

            // To long
            Converters.Register<byte, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<decimal, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<double, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<float, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<int, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<sbyte, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<short, long>(v => Convert.ToInt64(v, DefaultCultureInfo));
            Converters.Register<string, long>(v => string.IsNullOrWhiteSpace(v) ? default(long) : Convert.ToInt64(v, DefaultCultureInfo));

            // To sbyte
            Converters.Register<byte, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<decimal, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<double, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<float, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<int, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<long, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<short, sbyte>(v => Convert.ToSByte(v, DefaultCultureInfo));
            Converters.Register<string, sbyte>(v => string.IsNullOrWhiteSpace(v) ? default(sbyte) : Convert.ToSByte(v, DefaultCultureInfo));

            // To short
            Converters.Register<byte, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<decimal, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<double, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<float, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<int, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<long, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<sbyte, short>(v => Convert.ToInt16(v, DefaultCultureInfo));
            Converters.Register<string, short>(v => string.IsNullOrWhiteSpace(v) ? default(short) : Convert.ToInt16(v, DefaultCultureInfo));

            // To string
            Converters.Register<bool, string>(v => v.ToString());
            Converters.Register<byte, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<char, string>(v => v.ToString());
            Converters.Register<decimal, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<double, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<float, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<int, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<long, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<sbyte, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<short, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<DateTime, string>(v => v.ToString(DefaultCultureInfo));
            Converters.Register<Enum, string>(v => v.ToString());

            // To DateTime
            Converters.Register<string, DateTime>(v => string.IsNullOrWhiteSpace(v) ? default(DateTime) : Convert.ToDateTime(v, DefaultCultureInfo));

            // To Enum
            Converters.Register<BindDataConverterEnum<string>, Enum>(v => (Enum) Enum.Parse(v.EnumDataType, v.Value));
        }

        /// <summary>
        /// Registrar manipuladores de controles padrões a todas as plataformas
        /// </summary>
        /// <param name="handlers"></param>
        private static void RegisterHandlersConfig(BindHandlerConfigs handlers)
        {
            handlers.Register<INotifyPropertyChanged, NotifyPropertyChangedBindHandler>();
        }
    }
}