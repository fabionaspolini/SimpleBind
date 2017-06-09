using Android.Widget;
using SimpleBind.Core.ComponentMap;

namespace SimpleBind.Examples.Droid.View
{
    public partial class MainActivity
    {
        #region Componentes
#pragma warning disable 649

        [ComponentMap(Resource.Id.editText_TextChanged_TextViewInfo)]
        private TextView _editText_TextChanged_TextView;

        [ComponentMap(Resource.Id.editText_TextChanged)]
        private EditText _editText_TextChanged;

        [ComponentMap(Resource.Id.checkBox_CheckedChange_TextViewInfo)]
        private TextView _checkBox_CheckedChange_TextView;

        [ComponentMap(Resource.Id.checkBox_CheckedChange)]
        private CheckBox _checkBox_CheckedChange;

        // Spinner - Weekdays
        [ComponentMap(Resource.Id.spinner_ItemSelected_TextViewInfo)]
        private TextView _spinner_ItemSelected_TextViewInfo;

        [ComponentMap(Resource.Id.spinner_ItemSelected)]
        private Spinner _spinner_ItemSelected;

#pragma warning restore 649

        #endregion
    }
}