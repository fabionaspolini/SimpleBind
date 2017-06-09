using System.ComponentModel;
using System.Runtime.CompilerServices;
// ReSharper disable InconsistentNaming

namespace SimpleBind.Examples.Model.UITest
{
    public class TestModel : INotifyPropertyChanged
    {
        private string _editText_TextChanged = "Valor Inicial";
        private bool _checkBox_CheckedChange = true;
        private string _spinner_Weekdays = "Monday";
        private int _spinner_Weekdays_Position = 1;

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

        public string Spinner_Weekdays
        {
            get => _spinner_Weekdays;
            set
            {
                _spinner_Weekdays = value;
                OnPropertyChanged();
            }
        }

        public int Spinner_Weekdays_Position
        {
            get => _spinner_Weekdays_Position;
            set
            {
                _spinner_Weekdays_Position = value;
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