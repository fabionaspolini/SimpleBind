using Android.Widget;
using SimpleBind.Core.ComponentMap;

namespace SimpleBind.Examples.Droid.View
{
    public partial class MainActivity
    {
        #region Componentes
#pragma warning disable 649

        [ComponentMap(Resource.Id.editTextChanged_TextView)]
        private TextView _editTextChanged_TextView;

        [ComponentMap(Resource.Id.editTextChanged)]
        private EditText _editTextChanged;

#pragma warning restore 649
        #endregion
    }
}