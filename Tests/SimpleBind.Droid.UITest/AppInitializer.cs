﻿using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace SimpleBind.Droid.UITest
{
    public class AppInitializer
    {
        public static AndroidApp StartApp(Platform platform)
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            var lApp = ConfigureApp
                .Android
                .PreferIdeSettings()
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile ("../../../../Examples/SimpleBind.Examples.Droid/bin/Release/SimpleBind.Examples.Droid.SimpleBind.Examples.Droid.apk")
                .StartApp();

            return lApp;
        }
    }
}
