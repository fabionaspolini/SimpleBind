using NUnit.Framework;
using System;
using System.Globalization;
using SimpleBind.Examples.Model;
using SimpleBind.Examples.Model.Factory;

namespace SimpleBind.Core.Test
{
    [TestFixture]
    public class NotifyPropertyChangedPersonObjectTest
    {
        private BindContainer<Person> _container;
        private Person _sourcePerson = new Person();
        private PersonObject _destPerson;

        [SetUp]
        public void Init()
        {
            BindEngine.Initialize(new BindPlataformDefault());
        }

        [Test]
        public void DestToSourceTest()
        {
            CreateBinds(BindOrientarion.DestToSource);

            // Neste teste não há esta validação por conta dos vlores null
            //AssertEqualsValues();

            // Modificar valor no objeto destino e validar se foram aplicados ao origem
            SetDestValues();
            AssertEqualsValues();

            // Modificar valor objeto origem e validar se não foram aplicados ao destino
            SetSourceValues();
            AssertNotEqualsValues();
        }

        [Test]
        public void SourceToDestTest()
        {
            CreateBinds(BindOrientarion.SourceToDest);

            // Validar se o objeto destino foi sincronizado com os dados origem
            AssertEqualsValues();

            // Modificar valor objeto origem e validar se foram aplicados ao destino
            SetSourceValues();
            AssertEqualsValues();

            // Modificar valor no objeto destino e validar se não foram aplicados ao origem
            SetDestValues();
            AssertNotEqualsValues();
        }

        [Test]
        public void TwoWayTest()
        {
            CreateBinds(BindOrientarion.TwoWay);

            // Validar se o objeto destino foi sincronizado com os dados origem
            AssertEqualsValues();

            // Modificar valor objeto origem e validar se foram aplicados ao destino
            SetSourceValues();
            AssertEqualsValues();

            // Modificar valor no objeto destino e validar se foram aplicados ao origem
            SetDestValues();
            AssertEqualsValues();
        }

        private void CreateBinds(BindOrientarion orientarion)
        {
            _sourcePerson = PersonFactory.CreatePerson1();
            _destPerson = new PersonObject();

            _container = new BindContainer<Person>(_sourcePerson);
            _container.CreateBind(_destPerson).From(s => s.Id).To(d => d.Id);
            _container.CreateBind(_destPerson).From(s => s.Name).To(d => d.Name);
            _container.CreateBind(_destPerson).From(s => s.Active).To(d => d.Active);
            _container.CreateBind(_destPerson).From(s => s.Age).To(d => d.Age);
            _container.CreateBind(_destPerson).From(s => s.AgeShort).To(d => d.AgeShort);
            _container.CreateBind(_destPerson).From(s => s.AccountNumber).To(d => d.AccountNumber);
            _container.CreateBind(_destPerson).From(s => s.BirthData).To(d => d.BirthData);
            _container.CreateBind(_destPerson).From(s => s.SalaryDecimal).To(d => d.SalaryDecimal);
            _container.CreateBind(_destPerson).From(s => s.SalaryDouble).To(d => d.SalaryDouble);
            _container.CreateBind(_destPerson).From(s => s.SalaryFloat).To(d => d.SalaryFloat);
            _container.CreateBind(_destPerson).From(s => s.SexChar).To(d => d.SexChar);
            _container.CreateBind(_destPerson).From(s => s.SexEnum).To(d => d.SexEnum);
            _container.CreateBind(_destPerson).From(s => s.Nationality).To(d => d.Nationality);

            foreach (var lItem in _container.BindedItems)
            {
                var lBinded = (BindedItem<Person, PersonObject>) lItem;
                switch (orientarion)
                {
                    case BindOrientarion.SourceToDest:
                        lBinded.SourceToDestWay();
                        break;
                    case BindOrientarion.DestToSource:
                        lBinded.DestToSourceWay();
                        break;
                    case BindOrientarion.TwoWay:
                        lBinded.TwoWay();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(orientarion), orientarion, null);
                }
            }

            _container.Apply();
        }

        private void SetSourceValues()
        {
            _sourcePerson.Id = 2;
            _sourcePerson.Name = "Fábio Naspolini";
            _sourcePerson.Active = false;
            _sourcePerson.Age = 30;
            _sourcePerson.AgeShort = 30;
            _sourcePerson.AccountNumber = 123654789;
            _sourcePerson.BirthData = new DateTime(1980, 12, 31, 15, 12, 35);
            _sourcePerson.SalaryDecimal = 7894.32m;
            _sourcePerson.SalaryDouble = 7894.32f;
            _sourcePerson.SalaryFloat = 7894.32f;
            _sourcePerson.SexChar = 'F';
            _sourcePerson.SexEnum = Sex.Female;
            _sourcePerson.Nationality = Nationality.Brazilian;
        }

        private void SetDestValues()
        {
            _destPerson.Id = 3;
            _destPerson.Name = "Fábio Monteiro Naspolini";
            _destPerson.Active = true.ToString();
            _destPerson.Age = 31;
            _destPerson.AgeShort = 32;
            _destPerson.AccountNumber = "147852369";
            _destPerson.BirthData = new DateTime(1970, 11, 24, 11, 35, 39).ToString(CultureInfo.InvariantCulture);
            _destPerson.SalaryDecimal = 74123.32m;
            _destPerson.SalaryDouble = 74123.32;
            _destPerson.SalaryFloat = 74123.32f;
            _destPerson.SexChar = 'M'.ToString();
            _destPerson.SexEnum = Sex.Male.ToString();
            _destPerson.Nationality = Nationality.USA.ToString();
        }

        private void AssertEqualsValues()
        {
            Assert.AreEqual(_sourcePerson.Id.ToString(), _destPerson.Id?.ToString());
            Assert.AreEqual(_sourcePerson.Name, _destPerson.Name);
            Assert.AreEqual(_sourcePerson.Active.ToString(), _destPerson.Active?.ToString());
            Assert.AreEqual(_sourcePerson.Age.ToString(), _destPerson.Age?.ToString());
            Assert.AreEqual(_sourcePerson.AgeShort.ToString(), _destPerson.AgeShort?.ToString());
            Assert.AreEqual(_sourcePerson.AccountNumber.ToString(), _destPerson.AccountNumber?.ToString());

            if (_destPerson.BirthData is DateTime)
                Assert.AreEqual(_sourcePerson.BirthData.ToString(CultureInfo.InvariantCulture), ((DateTime)_destPerson.BirthData).ToString(CultureInfo.InvariantCulture));
            else
                Assert.AreEqual(_sourcePerson.BirthData.ToString(CultureInfo.InvariantCulture), _destPerson.BirthData?.ToString());


            if (_destPerson.SalaryDecimal is decimal)
                Assert.AreEqual(_sourcePerson.SalaryDecimal.ToString(CultureInfo.InvariantCulture), ((decimal)_destPerson.SalaryDecimal).ToString(CultureInfo.InvariantCulture));
            else
                Assert.AreEqual(_sourcePerson.SalaryDecimal.ToString(CultureInfo.InvariantCulture), _destPerson.SalaryDecimal?.ToString());

            if (_destPerson.SalaryDouble is double)
                Assert.AreEqual(_sourcePerson.SalaryDouble.ToString(CultureInfo.InvariantCulture), ((double)_destPerson.SalaryDouble).ToString(CultureInfo.InvariantCulture));
            else
                Assert.AreEqual(_sourcePerson.SalaryDouble.ToString(CultureInfo.InvariantCulture), _destPerson.SalaryDouble?.ToString());

            if (_destPerson.SalaryFloat is float)
                Assert.AreEqual(_sourcePerson.SalaryFloat.ToString(CultureInfo.InvariantCulture), ((float)_destPerson.SalaryFloat).ToString(CultureInfo.InvariantCulture));
            else
                Assert.AreEqual(_sourcePerson.SalaryFloat.ToString(CultureInfo.InvariantCulture), _destPerson.SalaryFloat?.ToString());

            Assert.AreEqual(_sourcePerson.SexChar.ToString(), _destPerson.SexChar?.ToString());
            Assert.AreEqual(_sourcePerson.SexEnum.ToString(), _destPerson.SexEnum.ToString());
            Assert.AreEqual(_sourcePerson.Nationality.ToString(), _destPerson.Nationality.ToString());
        }

        private void AssertNotEqualsValues()
        {
            Assert.AreNotEqual(_sourcePerson.Id, _destPerson.Id);
            Assert.AreNotEqual(_sourcePerson.Name, _destPerson.Name);
            Assert.AreNotEqual(_sourcePerson.Active, _destPerson.Active);
            Assert.AreNotEqual(_sourcePerson.Age, _destPerson.Age);
            Assert.AreNotEqual(_sourcePerson.AgeShort, _destPerson.AgeShort);
            Assert.AreNotEqual(_sourcePerson.AccountNumber, _destPerson.AccountNumber);
            Assert.AreNotEqual(_sourcePerson.BirthData, _destPerson.BirthData);
            Assert.AreNotEqual(_sourcePerson.SalaryDecimal, _destPerson.SalaryDecimal);
            Assert.AreNotEqual(_sourcePerson.SalaryDouble, _destPerson.SalaryDouble);
            Assert.AreNotEqual(_sourcePerson.SalaryFloat, _destPerson.SalaryFloat);
            Assert.AreNotEqual(_sourcePerson.SexChar, _destPerson.SexChar);
            Assert.AreNotEqual(_sourcePerson.Nationality.ToString(), _destPerson.Nationality.ToString());
        }
    }
}
