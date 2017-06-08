using System;

namespace SimpleBind.Droid.Extensions
{
    public static class XamarinExtensions
    {
        public static object GetInstance(this Java.Lang.Object obj)
        {
            var propertyInfo = obj?.GetType().GetProperty("Instance");
            return propertyInfo?.GetValue(obj, null);
        }

        public static T Cast<T>(this Java.Lang.Object obj) where T : class
        {
            var propertyInfo = obj?.GetType().GetProperty("Instance");
            var lValue = propertyInfo?.GetValue(obj, null);
            if (lValue == null)
                return null;

            if (lValue is T)
                return (T) lValue;

            throw new InvalidCastException($"Não é possível converter {lValue.GetType().FullName} para {typeof(T).FullName}!");
        }
    }
}