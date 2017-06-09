using Android.App;
using Android.OS;
using SimpleBind.Core;
using SimpleBind.Droid;
using SimpleBind.Droid.ComponentMap;
using SimpleBind.Examples.Model.UITest;
using System;
using SimpleBind.Droid.Proxy;

namespace SimpleBind.Examples.Droid.View
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public partial class MainActivity : Activity
    {
        private readonly TestModel _model = new TestModel();
        private BindContainer<TestModel> _container;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            BindEngine.Initialize(new BindPlatformAndroid());
            _container = new BindContainer<TestModel>(_model);

            SetContentView(Resource.Layout.Main);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            ComponentMapEngine.Initialize(this);
            ConfigureBindings();
        }

        private void ConfigureBindings()
        {
            if (_container.Applyed)
                _container.RemoveControlsBinds();

            try
            {
                // EditText -> TextChanged
                _container.CreateBind(_editText_TextChanged)
                    .From(m => m.EditText_TextChanged)
                    .To(v => v.Text)
                    .TwoWay();

                _container.CreateBind(_editText_TextChanged_TextView)
                    .From(m => m.EditText_TextChanged)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>((model, view, value) => TestModelConsts.EditText_TextChanged_Prefix + value))
                    .SourceToDestWay();

                // CheckBox -> CheckedChange
                _container.CreateBind(_checkBox_CheckedChange)
                    .From(m => m.CheckBox_CheckedChange)
                    .To(v => v.Checked)
                    .TwoWay();

                _container.CreateBind(_checkBox_CheckedChange_TextView)
                    .From(m => m.CheckBox_CheckedChange)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<bool>(
                            (model, view, value) => TestModelConsts.CheckBox_CheckedChange_Prefix + value))
                    .SourceToDestWay();

                // Spinner - Weekdays
                _container.CreateBind(_spinner_ItemSelected.CreateBindProxy())
                    .From(m => m.Spinner_Weekdays)
                    .To(v => v.SelectedItem)
                    .TwoWay();

                _container.CreateBind(_spinner_ItemSelected_TextViewInfo)
                    .From(m => m.Spinner_Weekdays)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>(
                            (model, view, value) => TestModelConsts.Spinner_Weekdays_Prefix + value))
                    .SourceToDestWay();

                //
                _container.Apply();
            }
            catch (Exception e)
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle("Info");
                builder.SetMessage($"Message: {e.Message}");
                builder.Show();
            }
        }
    }
}

