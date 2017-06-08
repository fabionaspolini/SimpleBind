using Android.App;
using Android.Views;
using SimpleBind.Core.ComponentMap;
using System.Reflection;

namespace SimpleBind.Droid.ComponentMap
{
    public static class ComponentMapEngine
    {
        public static void Initialize(View rootLayout, object mapsContainer)
        {
            var lFields = mapsContainer.GetType().GetRuntimeFields();
            foreach (var lField in lFields)
            {
                var lMapAttrib = lField.GetCustomAttribute<ComponentMapAttribute>();
                if (lMapAttrib != null)
                    lField.SetValue(mapsContainer, rootLayout.FindViewById(lMapAttrib.Id));
            }
        }

        public static void Initialize(View rootLayout)
        {
            Initialize(rootLayout, rootLayout);
        }

        public static void Initialize(Activity activity)
        {
            var lView = activity.FindViewById(global::Android.Resource.Id.Content);
            Initialize(lView, activity);
        }

        public static void Initialize(Fragment fragment)
        {
            Initialize(fragment.View, fragment);
        }
    }
}