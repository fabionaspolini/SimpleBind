using System;

namespace SimpleBind.Examples.Model.Factory
{
    public static class PersonFactory
    {
        public static readonly Person Person1 = CreatePerson1();

        public static Person CreatePerson1()
        {
            return new Person
            {
                Id = 1,
                Name = "Fábio",
                Active = true,
                Age = 28,
                AgeShort = 28,
                AccountNumber = 123456789012345,
                BirthData = new DateTime(1989, 3, 17),
                SalaryDecimal = 1234.56m,
                SalaryDouble = 1234.56,
                SalaryFloat = 1234.56f,
                SexChar = 'M'
            };
        }
    }
}
