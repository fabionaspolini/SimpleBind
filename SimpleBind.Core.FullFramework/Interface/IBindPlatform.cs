using System;
using SimpleBind.Core.BindHandler;

namespace SimpleBind.Core.Interface
{
    /// <summary>
    /// Configurações específicas para plataforma
    /// </summary>
    public interface IBindPlatform
    {
        BindHandlerConfigs Handlers { get; }

        /// <summary>
        /// Verificar se é descente do tipo básico da plataforma
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsPlatformType(Type type);

        /// <summary>
        /// Verificar se é tipo de dados básico da plataforma (Java.Lang.Integer, Java.Lang.Float, Java.Lang.Boolean, etc)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsPlataformPrimitiveType(Type type);

        /// <summary>
        /// Verificar se é tipo de dado básico do .NET (bool, int, long, float, etc)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsDotNetPrimitiveType(Type type);

        /// <summary>
        /// Converter dado do .NET para o tipo correspondente na plataform Android/iOS
        /// </summary>
        /// <param name="dotNetValue"></param>
        /// <returns></returns>
        object ToPlataformValue(object dotNetValue);

        /// <summary>
        /// Converter dado da plataforma Android/iOS para o tipo correspondente no .NET
        /// </summary>
        /// <param name="plataformValue"></param>
        /// <returns></returns>
        object ToDotNetValue(object plataformValue);
    }
}
