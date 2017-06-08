using Android.App;
using Android.OS;
using SimpleBind.Core;
using SimpleBind.Droid;
using SimpleBind.Droid.ComponentMap;
using SimpleBind.Examples.Model.UITest;
using System;

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
                // Edit Text -> Text Changed
                _container.CreateBind(_editTextChanged)
                    .From(m => m.EditTextChanged)
                    .To(v => v.Text)
                    .TwoWay();

                _container.CreateBind(_editTextChanged_TextView)
                    .From(m => m.EditTextChanged)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>((model, view, value) => TestModelConsts.EditTextTextChangedPrefix + value))
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

