using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace SimpleBind.Droid.UITest
{
    [TestFixture(Platform.Android)]
    public class AndroidHandlersTest
    {
        private AndroidApp _app;
        private readonly Platform _platform;

        public AndroidHandlersTest(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void AppLaunches()
        {
            //_app.Screenshot("First screen.");
            Assert.AreEqual(1, 1);
        }
    }
}

