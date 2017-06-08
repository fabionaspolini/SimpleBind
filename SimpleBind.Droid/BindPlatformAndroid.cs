using Android.Widget;
using SimpleBind.Core;
using SimpleBind.Core.BindHandler;
using SimpleBind.Droid.BindHandler;
using SimpleBind.Droid.Proxy;
using System;
using System.Linq;

namespace SimpleBind.Droid
{
    public class BindPlatformAndroid : BindPlatform
    {
        public static readonly Type[] PlataformTypes =
        {
            typeof(Java.Lang.Boolean),
            typeof(Java.Lang.Byte),
            typeof(Java.Lang.Character),
            typeof(Java.Lang.Double),
            typeof(Java.Lang.Float),
            typeof(Java.Lang.Integer),
            typeof(Java.Lang.Long),
            typeof(Java.Lang.Short),
            typeof(Java.Lang.String)
            //typeof(Java.Util.Date)
        };

        public override bool IsPlatformType(Type type)
        {
            return typeof (Java.Lang.Object).IsAssignableFrom(type);
        }

        public override bool IsPlataformPrimitiveType(Type type)
        {
            return PlataformTypes.Contains(type);
        }

        protected override void RegisterDefaultDataConverters(BindDataConverters converters)
        {
            // C# -> Java
            converters.Register<bool, Java.Lang.Boolean>(Java.Lang.Boolean.ValueOf);
            converters.Register<sbyte, Java.Lang.Byte>(Java.Lang.Byte.ValueOf);
            converters.Register<char, Java.Lang.Character>(Java.Lang.Character.ValueOf);
            converters.Register<double, Java.Lang.Double>(Java.Lang.Double.ValueOf);
            converters.Register<float, Java.Lang.Float>(Java.Lang.Float.ValueOf);
            converters.Register<int, Java.Lang.Integer>(Java.Lang.Integer.ValueOf);
            //converters.Register<int, Java.Lang.Object>(Java.Lang.Integer.ValueOf);
            converters.Register<long, Java.Lang.Long>(Java.Lang.Long.ValueOf);
            converters.Register<short, Java.Lang.Short>(Java.Lang.Short.ValueOf);
            // Decimal
            // converters.Register<DateTime, Java.Util.Date>(Java.Util.Date.ValueOf);

            // Java -> C#
            converters.Register<Java.Lang.Boolean, bool>(v => v.BooleanValue());
            converters.Register<Java.Lang.Byte, sbyte>(v => v.ByteValue());
            converters.Register<Java.Lang.Character, char>(v => v.CharValue());
            converters.Register<Java.Lang.Double, double>(v => v.DoubleValue());
            converters.Register<Java.Lang.Float, float>(v => v.FloatValue());
            converters.Register<Java.Lang.Integer, int>(v => v.IntValue());
            converters.Register<Java.Lang.Long, long>(v => v.LongValue());
            converters.Register<Java.Lang.Short, short>(v => v.ShortValue());
        }

        protected override void RegisterDefaultHandlersConfig(BindHandlerConfigs handlers)
        {
            handlers.Register<EditText, EditTextBindHandler>();
            handlers.Register<CheckBox, CheckBoxBindHandler>();
            handlers.Register<SpinnerProxyBind, SpinnerProxyBindHandler>();
        }
    }
}