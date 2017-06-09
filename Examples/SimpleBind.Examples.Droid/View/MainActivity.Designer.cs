using Android.Widget;
using SimpleBind.Core.ComponentMap;

namespace SimpleBind.Examples.Droid.View
{
    public partial class MainActivity
    {
        #region Componentes
#pragma warning disable 649

        // _tipoComponent_Propriedade_InfoAdicional

        [ComponentMap(Resource.Id.editText_Text_TextViewInfo)]
        private TextView _editText_Text_TextView;

        [ComponentMap(Resource.Id.editText_Text)]
        private EditText _editText_Text;

        [ComponentMap(Resource.Id.checkBox_Checked_TextViewInfo)]
        private TextView _checkBox_Checked_TextView;

        [ComponentMap(Resource.Id.checkBox_Checked)]
        private CheckBox _checkBox_Checked;

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