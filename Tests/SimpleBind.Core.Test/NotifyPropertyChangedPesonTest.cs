using NUnit.Framework;
using System;
using SimpleBind.Examples.Model;
using SimpleBind.Examples.Model.Factory;

namespace SimpleBind.Core.Test
{
    [TestFixture]
    public class NotifyPropertyChangedPesonTest
    {
        private BindContainer<Person> _container;
        private Person _sourcePerson = new Person();
        private Person _destPerson;

        [SetUp]
        public void Init()
        {
            BindEngine.Initialize(new BindPlataformDefault());
        }

        [Test]
        public void DestToSourceTest()
        {
            CreateBinds(BindOrientarion.DestToSource);

            // Validar se o objeto destino foi sincronizado com os dados origem
            AssertEqualsValues();

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
            _destPerson = new Person();

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

            foreach (var lItem in _container.BindedItems)
            {
                var lBinded = (BindedItem<Person, Person>) lItem;
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
        }

        private void SetDestValues()
        {
            _destPerson.Id = 3;
            _destPerson.Name = "Fábio Monteiro Naspolini";
            _destPerson.Active = true;
            _destPerson.Age = 31;
            _destPerson.AgeShort = 32;
            _destPerson.AccountNumber = 147852369;
            _destPerson.BirthData = new DateTime(1970, 11, 24, 11, 35, 39);
            _destPerson.SalaryDecimal = 74123.32m;
            _destPerson.SalaryDouble = 74123.32f;
            _destPerson.SalaryFloat = 74123.32f;
            _destPerson.SexChar = 'M';
            _destPerson.SexEnum = Sex.Male;
        }

        private void AssertEqualsValues()
        {
            Assert.AreEqual(_sourcePerson.Id, _destPerson.Id);
            Assert.AreEqual(_sourcePerson.Name, _destPerson.Name);
            Assert.AreEqual(_sourcePerson.Active, _destPerson.Active);
            Assert.AreEqual(_sourcePerson.Age, _destPerson.Age);
            Assert.AreEqual(_sourcePerson.AgeShort, _destPerson.AgeShort);
            Assert.AreEqual(_sourcePerson.AccountNumber, _destPerson.AccountNumber);
            Assert.AreEqual(_sourcePerson.BirthData, _destPerson.BirthData);
            Assert.AreEqual(_sourcePerson.SalaryDecimal, _destPerson.SalaryDecimal);
            Assert.AreEqual(_sourcePerson.SalaryDouble, _destPerson.SalaryDouble);
            Assert.AreEqual(_sourcePerson.SalaryFloat, _destPerson.SalaryFloat);
            Assert.AreEqual(_sourcePerson.SexChar, _destPerson.SexChar);
            Assert.AreEqual(_sourcePerson.SexEnum, _destPerson.SexEnum);
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
            Assert.AreNotEqual(_sourcePerson.SexEnum, _destPerson.SexEnum);
        }
    }
}
