namespace SimpleBind.Examples.Model
{
    public class TempDataString : BaseModel
    {
        private string _value1Str;
        private string _value2Str;
        private string _value3Str;
        private string _value4Str;
        private string _value5Str;

        public string Value1Str
        {
            get { return _value1Str; }
            set
            {
                _value1Str = value;
                OnPropertyChanged();
            }
        }

        public string Value2Str
        {
            get { return _value2Str; }
            set
            {
                _value2Str = value;
                OnPropertyChanged();
            }
        }

        public string Value3Str
        {
            get { return _value3Str; }
            set
            {
                _value3Str = value;
                OnPropertyChanged();
            }
        }

        public string Value4Str
        {
            get { return _value4Str; }
            set
            {
                _value4Str = value;
                OnPropertyChanged();
            }
        }

        public string Value5Str
        {
            get { return _value5Str; }
            set
            {
                _value5Str = value;
                OnPropertyChanged();
            }
        }
    }
}
