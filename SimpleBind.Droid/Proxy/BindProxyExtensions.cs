using Android.Widget;

namespace SimpleBind.Droid.Proxy
{
    public static class BindProxyExtensions
    {
        public static SpinnerProxyBind CreateBindProxy(this Spinner spinner, bool animated = false)
        {
            return new SpinnerProxyBind(spinner, animated);
        }
    }
}