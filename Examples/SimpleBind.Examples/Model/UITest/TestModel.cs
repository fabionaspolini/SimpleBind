using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleBind.Examples.Model.UITest
{
    public class TestModel : INotifyPropertyChanged
    {
        private static string _editTextChanged = "Valor Inicial";

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}