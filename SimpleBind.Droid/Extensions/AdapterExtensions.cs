using Android.Widget;

namespace SimpleBind.Droid.Extensions
{
    public static class AdapterExtensions
    {
        public static Java.Lang.Object GetItemJavaById(this IAdapter adapter, long id)
        {
			if (adapter == null)
				return null;

            for (int i = 0; i < adapter.Count; i++)
                if (adapter.GetItemId(i) == id)
                    return adapter.GetItem(i);

            return null;
        }

        public static object GetItemById(this IAdapter adapter, long id)
        {
            var lItem = GetItemJavaById(adapter, id);
            return lItem.GetInstance();
        }

        public static T GetItemById<T>(this IAdapter adapter, long id) where T : class
        {
            var lItem = GetItemJavaById(adapter, id);
            return lItem.Cast<T>();
        }
    }
}