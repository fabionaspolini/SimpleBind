using SimpleBind.Core.BindHandler;
using System;
using System.Linq;

namespace SimpleBind.Core
{
    /// <summary>
    /// Configurações de plataforma para linguagem padrão .NET
    /// </summary>
    public class BindPlataformDefault : BindPlatform
    {
        public override bool IsPlatformType(Type type)
        {
            return false;
        }

        public override bool IsPlataformPrimitiveType(Type type)
        {
            return DotNetPrimitiveTypes.Contains(type);
        }

        protected override void RegisterDefaultDataConverters(BindDataConverters converters)
        {                       
        }

        protected override void RegisterDefaultHandlersConfig(BindHandlerConfigs handlers)
        {
        }
    }
}
