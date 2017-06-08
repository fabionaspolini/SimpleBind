using System;

namespace SimpleBind.Examples.Model
{
    public class PersonNullable : BaseModel
    {
        private int? _id;
        private string _name;
        private DateTime? _birthData;
        private decimal? _salaryDecimal;
        private double? _salaryDouble;
        private float? _salaryFloat;
        private bool? _active;
        private long? _accountNumber;
        private char? _sexChar;
        private Sex? _sexEnum;
        private byte? _age;
        private short? _ageShort;
        private Nationality? _nationality;

        public int? Id
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

        public DateTime? BirthData
        {
            get { return _birthData; }
            set
            {
                _birthData = value;
                OnPropertyChanged();
            }
        }

        public decimal? SalaryDecimal
        {
            get { return _salaryDecimal; }
            set
            {
                _salaryDecimal = value;
                OnPropertyChanged();
            }
        }

        public double? SalaryDouble
        {
            get { return _salaryDouble; }
            set
            {
                _salaryDouble = value;
                OnPropertyChanged();
            }
        }

        public float? SalaryFloat
        {
            get { return _salaryFloat; }
            set
            {
                _salaryFloat = value;
                OnPropertyChanged();
            }
        }

        public bool? Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }

        public long? AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = value;
                OnPropertyChanged();
            }
        }

        public char? SexChar
        {
            get { return _sexChar; }
            set
            {
                _sexChar = value;
                OnPropertyChanged();
            }
        }

        public Sex? SexEnum
        {
            get { return _sexEnum; }
            set
            {
                _sexEnum = value;
                OnPropertyChanged();
            }
        }

        public byte? Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public short? AgeShort
        {
            get { return _ageShort; }
            set
            {
                _ageShort = value;
                OnPropertyChanged();
            }
        }

        public Nationality? Nationality
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
