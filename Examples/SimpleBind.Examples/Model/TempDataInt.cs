namespace SimpleBind.Examples.Model
{
    public class TempDataInt : BaseModel
    {
        private int _value1Int;
        private int _value2Int;
        private int _value3Int;
        private int _value4Int;

        public int Value1Int
        {
            get { return _value1Int; }
            set
            {
                _value1Int = value;
                OnPropertyChanged();
            }
        }

        public int Value2Int
        {
            get { return _value2Int; }
            set
            {
                _value2Int = value;
                OnPropertyChanged();
            }
        }

        public int Value3Int
        {
            get { return _value3Int; }
            set
            {
                _value3Int = value;
                OnPropertyChanged();
            }
        }

        public int Value4Int
        {
            get { return _value4Int; }
            set
            {
                _value4Int = value;
                OnPropertyChanged();
            }
        }
    }
}
