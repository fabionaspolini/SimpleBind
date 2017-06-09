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

        // Spinner.SelectedItem
        [ComponentMap(Resource.Id.spinner_SelectedItem_TextViewInfo)]
        private TextView _spinner_SelectedItem_TextViewInfo;

        [ComponentMap(Resource.Id.spinner_SelectedItem)]
        private Spinner _spinner_SelectedItem;

        // Spinner.SelectedItemPosition
        [ComponentMap(Resource.Id.spinner_SelectedItemPosition_TextViewInfo)]
        private TextView _spinner_SelectedItemPosition_TextViewInfo;

        [ComponentMap(Resource.Id.spinner_SelectedItemPosition)]
        private Spinner _spinner_SelectedItemPosition;

#pragma warning restore 649

        #endregion
    }
}