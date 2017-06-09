using System.Linq;
using NUnit.Framework;
using SimpleBind.Examples.Model.UITest;
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
        public void EditTextHandler_TextChanged()
        {
            const string editTextId = "editTextChanged";
            const string textViewId = "editTextChanged_TextView";

            _app.ClearText(editTextId);
            Assert.IsTrue(_app.Query(c => c.Marked(editTextId).Text("")).Any());

            _app.EnterText(editTextId, "Unit Test UI Edit Changed!");
            Assert.IsTrue(_app.Query(c => c.Marked(editTextId).Text("Unit Test UI Edit Changed!")).Any());
            Assert.IsTrue(_app.Query(c => c.Marked(textViewId).Text(TestModelConsts.EditTextTextChangedPrefix + "Unit Test UI Edit Changed!")).Any());
        }
    }
}

