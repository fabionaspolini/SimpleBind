using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable InconsistentNaming

namespace SimpleBind.Examples.Model.UITest
{
    public class TestModel : INotifyPropertyChanged
    {
        private string _editText_TextChanged = "Valor Inicial";
        private bool _checkBox_CheckedChange = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EditText_TextChanged
        {
            get => _editText_TextChanged;
            set
            {
                _editText_TextChanged = value;
                OnPropertyChanged();
            }
        }

        public bool CheckBox_CheckedChange
        {
            get => _checkBox_CheckedChange;
            set
            {
                _checkBox_CheckedChange = value;
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