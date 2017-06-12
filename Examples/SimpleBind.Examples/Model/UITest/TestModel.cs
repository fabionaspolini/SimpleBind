using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable InconsistentNaming

namespace SimpleBind.Examples.Model.UITest
{
    public class TestModel : INotifyPropertyChanged
    {
        private string _editText_TextChanged = "Valor Inicial";
        private bool _checkBox_CheckedChange = true;
        private int _spinner_SelectedItemPosition = 2;
        private string _spinner_SelectedItem_JavaString = "Saturday";
        private string _spinner_SelectedItem_String = "Saturday";

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

        public int Spinner_SelectedItemPosition
        {
            get => _spinner_SelectedItemPosition;
            set
            {
                _spinner_SelectedItemPosition = value;
                OnPropertyChanged();
            }
        }

        public string Spinner_SelectedItem_JavaString
        {
            get => _spinner_SelectedItem_JavaString;
            set
            {
                _spinner_SelectedItem_JavaString = value;
                OnPropertyChanged();
            }
        }

        public string Spinner_SelectedItem_String
        {
            get => _spinner_SelectedItem_String;
            set
            {
                _spinner_SelectedItem_String = value;
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