using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBind.Core
{
    /// <summary>
    /// Manipulador de conversão de dados quando efetuado bind com propriedades vínculadas com tipos diferentes
    /// </summary>
    public interface IBindDataConveter
    {
        /// <summary>
        /// Tipo de dados origem da informação
        /// </summary>
        Type SourceType { get; }

        /// <summary>
        /// Tipo de dados destino da informação
        /// </summary>
        Type DestType { get; }

        /// <summary>
        /// Método que realiza a conversão do dado
        /// </summary>
        /// <param name="value">Valor do tipo origem <see cref="SourceType"/> a ser convertido</param>
        /// <returns>Valor convertido para o tipo destino <see cref="DestType"/></returns>
        object Convert(object value);
    }

    /// <summary>
    /// Manipulador de conversão de dados quando efetuado bind com propriedades vínculadas com tipos diferentes
    /// </summary>
    /// <typeparam name="TSourceType">Tipo de dados origem da informação</typeparam>
    /// <typeparam name="TDestType">Tipo de dados destino da informação</typeparam>
    public class BindDataConveter<TSourceType, TDestType> : IBindDataConveter
    {
        /// <summary>
        /// Função reponsável pela conversão de dados recebida no construtor
        /// </summary>
        protected Func<TSourceType, TDestType> ConverFunc { get; set; }

        /// <summary>
        /// Tipo de dados origem da informação. Definido através do generic <see cref="TSourceType"/>
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// Tipo de dados destino da informação. Definido através do generic <see cref="TDestType"/>
        /// </summary>
        public Type DestType { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="converFunc">Função para realizar a conversão do dado <see cref="TSourceType"/> para <see cref="TDestType"/></param>
        public BindDataConveter(Func<TSourceType, TDestType> converFunc)
        {
            SourceType = typeof (TSourceType);
            DestType = typeof (TDestType);
            ConverFunc = converFunc;
        }

        /// <summary>
        /// Método que realiza a conversão do dado
        /// </summary>
        /// <param name="value">Valor do tipo origem <see cref="TSourceType"/> a ser convertido</param>
        /// <returns>Valor convertido para o tipo destino <see cref="TDestType"/></returns>
        public object Convert(object value)
        {
            return ConverFunc.Invoke((TSourceType) value);
        }
    }

    /// <summary>
    /// Lista de conversores de dados
    /// </summary>
    public class BindDataConverters
    {
        private readonly List<IBindDataConveter> _converters = new List<IBindDataConveter>();

        /// <summary>
        /// Obter conversor com o tipo de dados origem e destino
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="destType"></param>
        /// <returns></returns>
        public IBindDataConveter GetConveter(Type sourceType, Type destType)
        {
            var lConverter = _converters.FirstOrDefault(p => p.SourceType == sourceType && p.DestType == destType);
            return lConverter;
        }

        /// <summary>
        /// Obter conversor com o tipo de dados origem e destino
        /// </summary>
        /// <typeparam name="TSourceType"></typeparam>
        /// <typeparam name="TDestType"></typeparam>
        /// <returns></returns>
        public IBindDataConveter GetConveter<TSourceType, TDestType>() => GetConveter(typeof (TSourceType), typeof (TDestType));

        /// <summary>
        /// Converter valor utilizando o conversor registrado para o tipo de dados origem e destino
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="value"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public object Convert(Type sourceType, Type destType, object value)
        {
            var lConveter = GetConveter(sourceType, destType);

            if (lConveter == null)
                throw new Exception(
                    string.Format("Nenhum conversor registrado para executar a operação.\nOrigem: {0}\nDestino: {1}",
                        sourceType.FullName,
                        destType.FullName));

            return lConveter.Convert(value);
        }

        /// <summary>
        /// Converter valor utilizando o conversor registrado para o tipo de dados origem e destino
        /// </summary>
        /// <typeparam name="TSourceType"></typeparam>
        /// <typeparam name="TDestType"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public TDestType Convert<TSourceType, TDestType>(TSourceType value)
        {
            var lRet = Convert(typeof (TSourceType), typeof (TDestType), value);
            return (TDestType) lRet;
        }

        /// <summary>
        /// Converter valor buscando o único conversor registrado com este tipo de origem
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ConvertFromSourceType(Type sourceType, object value)
        {
            var lConverter = _converters.SingleOrDefault(c => c.SourceType == sourceType);
            try
            {
                if (lConverter == null)
                    throw new Exception(
                        string.Format("Nenhum conversor registrado para executar a operação automaticamente.\nOrigem: {0}",
                            sourceType.FullName));

                return lConverter.Convert(value);
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format("Não foi possível converter \"{0}\" para \"{1}\".\nValor: {2}",
                        (lConverter?.SourceType ?? sourceType)?.FullName,
                        lConverter?.DestType?.FullName,
                        value),
                    e);
            }
        }

        /// <summary>
        /// Converter valor buscando o único conversor registrado com este tipo de destino
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object ConvertFromDestType(Type destType, object value)
        {
            var lConverter = _converters.SingleOrDefault(c => c.DestType == destType);
            try
            {
                if (lConverter == null)
                    throw new Exception(
                        string.Format("Nenhum conversor registrado para executar a operação automaticamente.\nDestino: {0}",
                            destType.FullName));

                return lConverter.Convert(value);
            }
            catch (Exception e)
            {
                throw new Exception(
                    string.Format("Não foi possível converter \"{0}\" para \"{1}\".\nValor: {2}",
                        lConverter?.SourceType?.FullName ?? "Não identificado",
                        (lConverter?.DestType ?? destType)?.FullName,
                        value),
                    e);
            }
        }

        /// <summary>
        /// Register conversor
        /// </summary>
        /// <typeparam name="TSourceType"></typeparam>
        /// <typeparam name="TDestType"></typeparam>
        /// <param name="converFunc"></param>
        public void Register<TSourceType, TDestType>(Func<TSourceType, TDestType> converFunc)
        {
            _converters.RemoveAll(c => c.SourceType == typeof (TSourceType) && c.DestType == typeof (TDestType));
            _converters.Add(new BindDataConveter<TSourceType, TDestType>(converFunc));
        }
    }

    public struct BindDataConverterEnum<TValueType>
    {
        /// <summary>
        /// Tipo que representa o enum (typeof(EnumType))
        /// </summary>
        public Type EnumDataType { get; set; }

        /// <summary>
        /// Valor a ser convertido
        /// </summary>
        public TValueType Value { get; set; }

        public BindDataConverterEnum(Type enumDataType, TValueType value)
        {
            EnumDataType = enumDataType;
            Value = value;
        }
    }
}