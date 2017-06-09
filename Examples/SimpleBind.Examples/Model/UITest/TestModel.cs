using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleBind.Examples.Model.UITest
{
    public class TestModel : INotifyPropertyChanged
    {
        private string _editTextChanged = "Valor Inicial";
        private bool _checkBoxCheckedChange = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EditTextChanged
        {
            get => _editTextChanged;
            set
            {
                _editTextChanged = value;
                OnPropertyChanged();
            }
        }

        public bool CheckBox_CheckedChange
        {
            get => _checkBoxCheckedChange;
            set
            {
                _checkBoxCheckedChange = value;
                OnPropertyChanged();
            }
        }

        #region Métodos

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}