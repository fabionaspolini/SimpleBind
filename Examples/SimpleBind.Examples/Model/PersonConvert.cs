namespace SimpleBind.Examples.Model
{
    public class PersonConvert : BaseModel
    {
        private string _id;
        private string _name;
        private string _birthData;
        private string _salaryDecimal;
        private string _salaryDouble;
        private string _salaryFloat;
        private string _active;
        private string _accountNumber;
        private string _sexChar;
        private string _sexEnum;
        private string _age;
        private string _ageShort;
        private int _nationality;

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string BirthData
        {
            get { return _birthData; }
            set
            {
                _birthData = value;
                OnPropertyChanged();
            }
        }

        public string SalaryDecimal
        {
            get { return _salaryDecimal; }
            set
            {
                _salaryDecimal = value;
                OnPropertyChanged();
            }
        }

        public string SalaryDouble
        {
            get { return _salaryDouble; }
            set
            {
                _salaryDouble = value;
                OnPropertyChanged();
            }
        }

        public string SalaryFloat
        {
            get { return _salaryFloat; }
            set
            {
                _salaryFloat = value;
                OnPropertyChanged();
            }
        }

        public string Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = value;
                OnPropertyChanged();
            }
        }

        public string SexChar
        {
            get { return _sexChar; }
            set
            {
                _sexChar = value;
                OnPropertyChanged();
            }
        }

        public string SexEnum
        {
            get { return _sexEnum; }
            set
            {
                _sexEnum = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string AgeShort
        {
            get { return _ageShort; }
            set
            {
                _ageShort = value;
                OnPropertyChanged();
            }
        }

        public int Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                OnPropertyChanged();
            }
        }
    }
}
