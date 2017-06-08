namespace SimpleBind.Examples.Model
{
    public class PersonObject : BaseModel
    {
        private object _id;
        private object _name;
        private object _birthData;
        private object _salaryDecimal;
        private object _salaryDouble;
        private object _salaryFloat;
        private object _active;
        private object _accountNumber;
        private object _sexChar;
        private object _sexEnum;
        private object _age;
        private object _ageShort;
        private object _nationality;

        public object Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public object Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public object BirthData
        {
            get { return _birthData; }
            set
            {
                _birthData = value;
                OnPropertyChanged();
            }
        }

        public object SalaryDecimal
        {
            get { return _salaryDecimal; }
            set
            {
                _salaryDecimal = value;
                OnPropertyChanged();
            }
        }

        public object SalaryDouble
        {
            get { return _salaryDouble; }
            set
            {
                _salaryDouble = value;
                OnPropertyChanged();
            }
        }

        public object SalaryFloat
        {
            get { return _salaryFloat; }
            set
            {
                _salaryFloat = value;
                OnPropertyChanged();
            }
        }

        public object Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public object AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = value;
                OnPropertyChanged();
            }
        }

        public object SexChar
        {
            get { return _sexChar; }
            set
            {
                _sexChar = value;
                OnPropertyChanged();
            }
        }

        public object SexEnum
        {
            get { return _sexEnum; }
            set
            {
                _sexEnum = value;
                OnPropertyChanged();
            }
        }

        public object Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public object AgeShort
        {
            get { return _ageShort; }
            set
            {
                _ageShort = value;
                OnPropertyChanged();
            }
        }

        public object Nationality
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
