using NUnit.Framework;
using SimpleBind.Examples.Model.UITest;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace SimpleBind.Droid.UITest
{
    [TestFixture(Platform.Android)]
    public class AndroidHandlersTest
    {
        private AndroidApp _app;
        private readonly Platform _platform;
        private readonly TestModel _baseModelValues = new TestModel();

        public AndroidHandlersTest(Platform platform)
        {
            _platform = platform;
        }

        [TestFixtureSetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void EditTextHandler_TextChanged()
        {
            const string editTextId = "editText_TextChanged";
            const string textViewId = "editText_TextChanged_TextViewInfo";

            // Valor inicial
            Assert.IsTrue(_app.Query(c => c
                .Marked(editTextId)
                .Text(_baseModelValues.EditText_TextChanged)).Any());

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.EditText_TextChanged_Prefix + _baseModelValues.EditText_TextChanged)).Any());

            // Limpar texto
            _app.ClearText(editTextId);

            Assert.IsTrue(_app.Query(c => c
                .Marked(editTextId)
                .Text("")).Any());

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.EditText_TextChanged_Prefix)).Any());

            // Atribuir novo texto
            _app.EnterText(editTextId, "Unit Test UI Edit Changed!");

            Assert.IsTrue(_app.Query(c => c
                .Marked(editTextId)
                .Text("Unit Test UI Edit Changed!")).Any());

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.EditText_TextChanged_Prefix + "Unit Test UI Edit Changed!")).Any());
        }

        [Test]
        public void CheckBoxHandler_CheckedChange()
        {
            const string checkBoxId = "checkBox_CheckedChange";
            const string textViewId = "checkBox_CheckedChange_TextViewInfo";

            // Valor inicial
            Assert.IsTrue(_app.Query(c => c
                                  .Marked(checkBoxId)
                                  .Invoke("isChecked")
                                  .Value<bool>())
                              .First() == _baseModelValues.CheckBox_CheckedChange);

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.CheckBox_CheckedChange_Prefix + _baseModelValues.CheckBox_CheckedChange)).Any());

            // Desmarcar checkbox
            _app.Tap(checkBoxId);

            Assert.IsFalse(_app.Query(c => c
                    .Marked(checkBoxId)
                    .Invoke("isChecked")
                    .Value<bool>())
                .First());

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.CheckBox_CheckedChange_Prefix + false)).Any());

            // Marcar checkbox
            _app.Tap(checkBoxId);

            Assert.IsTrue(_app.Query(c => c
                    .Marked(checkBoxId)
                    .Invoke("isChecked")
                    .Value<bool>())
                .First());

            Assert.IsTrue(_app.Query(c => c
                .Marked(textViewId)
                .Text(TestModelConsts.CheckBox_CheckedChange_Prefix + true)).Any());
        }
    }
}

