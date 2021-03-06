﻿using Android.App;
using Android.OS;
using SimpleBind.Core;
using SimpleBind.Droid;
using SimpleBind.Droid.ComponentMap;
using SimpleBind.Examples.Model.UITest;
using System;
using System.Linq;
using Android.Widget;
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
            InitializeScreen();
            ConfigureBindings();
        }

        private void ConfigureBindings()
        {
            if (_container.Applyed)
                _container.RemoveControlsBinds();

            try
            {
                // EditText.Text
                _container.CreateBind(_editText_Text)
                    .From(m => m.EditText_TextChanged)
                    .To(v => v.Text)
                    .TwoWay();

                _container.CreateBind(_editText_Text_TextView)
                    .From(m => m.EditText_TextChanged)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>((model, view, value) => TestModelConsts.EditText_TextChanged_Prefix + value))
                    .SourceToDestWay();

                // CheckBox.Checked
                _container.CreateBind(_checkBox_Checked)
                    .From(m => m.CheckBox_CheckedChange)
                    .To(v => v.Checked)
                    .TwoWay();

                _container.CreateBind(_checkBox_Checked_TextView)
                    .From(m => m.CheckBox_CheckedChange)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<bool>(
                            (model, view, value) => TestModelConsts.CheckBox_CheckedChange_Prefix + value))
                    .SourceToDestWay();

                // Spinner.SelectedItemPosition
                _container.CreateBind(_spinner_SelectedItemPosition.CreateBindProxy())
                    .From(m => m.Spinner_SelectedItemPosition)
                    .To(v => v.SelectedItemPosition)
                    .TwoWay();

                _container.CreateBind(_spinner_SelectedItemPosition_TextViewInfo)
                    .From(m => m.Spinner_SelectedItemPosition)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<int>(
                            (model, view, value) => TestModelConsts.Spinner_SelectedItemPosition_Prefix + value))
                    .SourceToDestWay();

                // Spinner.SelectedItem.JavaString
                _container.CreateBind(_spinner_SelectedItem_JavaString.CreateBindProxy())
                    .From(m => m.Spinner_SelectedItem_JavaString)
                    .To(v => v.SelectedItem)
                    .TwoWay();

                _container.CreateBind(_spinner_SelectedItem_JavaString_TextViewInfo)
                    .From(m => m.Spinner_SelectedItem_JavaString)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>(
                            (model, view, value) => TestModelConsts.Spinner_SelectedItem_JavaString_Prefix + value))
                    .SourceToDestWay();

                // Spinner.SelectedItem.String
                _container.CreateBind(_spinner_SelectedItem_String.CreateBindProxy())
                    .From(m => m.Spinner_SelectedItem_String)
                    .To(v => v.SelectedItem)
                    .TwoWay();

                _container.CreateBind(_spinner_SelectedItem_String_TextViewInfo)
                    .From(m => m.Spinner_SelectedItem_String)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<string>(
                            (model, view, value) => TestModelConsts.Spinner_SelectedItem_String_Prefix + value))
                    .SourceToDestWay();

                // Spinner.SelectedItem.Enum
                _container.CreateBind(_spinner_SelectedItem_Enum.CreateBindProxy())
                    .From(m => m.Spinner_SelectedItem_Enum)
                    .To(v => v.SelectedItem)
                    .TwoWay();

                _container.CreateBind(_spinner_SelectedItem_Enum_TextViewInfo)
                    .From(m => m.Spinner_SelectedItem_Enum)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<TestEnum>(
                            (model, view, value) => TestModelConsts.Spinner_SelectedItem_Enum_Prefix + value))
                    .SourceToDestWay();

                // Spinner.SelectedItem.Object
                _container.CreateBind(_spinner_SelectedItem_Object.CreateBindProxy())
                    .From(m => m.Spinner_SelectedItem_Object)
                    .To(v => v.SelectedItem)
                    .TwoWay();

                _container.CreateBind(_spinner_SelectedItem_Object_TextViewInfo)
                    .From(m => m.Spinner_SelectedItem_Object)
                    .To(v => v.Text,
                        config => config.SetterDataConverter<TestSubModel>(
                            (model, view, value) => TestModelConsts.Spinner_SelectedItem_Object_Prefix + value?.ToString()))
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

        private void InitializeScreen()
        {
            _testeButton.Click += (o, args) =>
            {
                _model.Spinner_SelectedItem_JavaString = "Wednesday";
                _model.Spinner_SelectedItem_String = "Wednesday";
                _model.Spinner_SelectedItem_Enum = TestEnum.ThirdValue;
                _model.Spinner_SelectedItem_Object = TestSubModel.GetAll().Last();
            };

            #region Spinner.SelectedItem.String

            var lSpinnerSelectedItemStringArray = new[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };

            var lSpinnerSelectedItemStringAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, lSpinnerSelectedItemStringArray);
            lSpinnerSelectedItemStringAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner_SelectedItem_String.Adapter = lSpinnerSelectedItemStringAdapter;

            #endregion

            #region Spinner.SelectedItem.Enum

            var lSpinnerSelectedItemEnumArray = new[]
            {
                TestEnum.FirstValue,
                TestEnum.SecondValue,
                TestEnum.ThirdValue
            };

            var lSpinnerSelectedItemEnumAdapter = new ArrayAdapter<TestEnum>(this, Android.Resource.Layout.SimpleSpinnerItem, lSpinnerSelectedItemEnumArray);
            lSpinnerSelectedItemEnumAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner_SelectedItem_Enum.Adapter = lSpinnerSelectedItemEnumAdapter;

            #endregion

            #region Spinner.SelectedItem.Object

            var lSpinnerSelectedItemObjectArray = TestSubModel.GetAll();

            var lSpinnerSelectedItemObjectAdapter = new ArrayAdapter<TestSubModel>(this, Android.Resource.Layout.SimpleSpinnerItem, lSpinnerSelectedItemObjectArray);
            lSpinnerSelectedItemObjectAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _spinner_SelectedItem_Object.Adapter = lSpinnerSelectedItemObjectAdapter;

            #endregion
        }
    }
}

