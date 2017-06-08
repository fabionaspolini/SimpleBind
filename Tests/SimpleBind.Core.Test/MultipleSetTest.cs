using NUnit.Framework;
using SimpleBind.Examples.Model;
using SimpleBind.Examples.Model.Factory;

namespace SimpleBind.Core.Test
{
    [TestFixture]
    public class MultipleSetTest
    {
        [SetUp]
        public void Init()
        {
            BindEngine.Initialize(new BindPlataformDefault());
        }

        [Test]
        public void DestToSourceTest()
        {
            var lSource = new TempDataString();
            var lDest = new Person();

            var lContainer = new BindContainer<TempDataString>(lSource);

            // SetterDataConverter
            lContainer.CreateBind(lDest)
                .From(s => s.Value1Str,
                    config => config.SetterDataConverter((source, dest, value) => ((int) value * -1).ToString() + "a"))
                .To(d => d.Id)
                .DestToSourceWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value2Str,
                    config => config.SetterDataConverter<int>((source, dest, value) => (value + 50).ToString() + "a"))
                .To(d => d.Id)
                .DestToSourceWay();

            // SetterMethod
            lContainer.CreateBind(lDest)
                .From(config => config.SetterMethod(
                    (source, dest, value) => source.Value3Str = ((int)value + 80).ToString() + "a"))
                .To(d => d.Id)
                .DestToSourceWay();

            lContainer.CreateBind(lDest)
                .From(config => config.SetterMethod<int>(
                    (source, dest, value) => source.Value4Str = (value + 100).ToString() + "a"))
                .To(d => d.Id)
                .DestToSourceWay();

            // Bind property
            lContainer.CreateBind(lDest)
                .From(s => s.Value5Str)
                .To(d => d.Id)
                .DestToSourceWay();

            lContainer.Apply();

            // Validar que os valores iniciais do objeto origem estão da mesma forma como foram criado
            Assert.AreEqual(lDest.Id, 0);

            // Modificar valores do destino origem e validar origem
            lDest.Id = 15;

            Assert.AreEqual(lDest.Id, 15);

            Assert.AreEqual(lSource.Value1Str, "-15a");
            Assert.AreEqual(lSource.Value2Str, "65a");
            Assert.AreEqual(lSource.Value3Str, "95a");
            Assert.AreEqual(lSource.Value4Str, "115a");
            Assert.AreEqual(lSource.Value5Str, "15");
        }

        [Test]
        public void SourceToDestTest()
        {
            var lSource = PersonFactory.CreatePerson1();
            var lDest = new TempDataString();

            var lContainer = new BindContainer<Person>(lSource);

            // SetterDataConverter
            lContainer.CreateBind(lDest)
                .From(s => s.Id)
                .To(d => d.Value1Str,
                    config => config.SetterDataConverter((source, dest, value) => ((int) value * -1).ToString() + "a"))
                .SourceToDestWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Id)
                .To(d => d.Value2Str,
                    config => config.SetterDataConverter<int>((source, dest, value) => (value + 50).ToString() + "a"))
                .SourceToDestWay();

            // SetterMethod
            lContainer.CreateBind(lDest)
                .From(s => s.Id)
                .To(config => config.SetterMethod(
                    (source, dest, value) => dest.Value3Str = ((int)value + 80).ToString() + "a"))
                .SourceToDestWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Id)
                .To(config => config.SetterMethod<int>(
                    (source, dest, value) => dest.Value4Str = (value + 100).ToString() + "a"))
                .SourceToDestWay();

            // Bind property
            lContainer.CreateBind(lDest)
                .From(s => s.Id)
                .To(d => d.Value5Str)
                .SourceToDestWay();

            lContainer.Apply();

            // Validar que os valores iniciais do objeto origem estão da mesma forma como foram criado
            Assert.AreEqual(lSource.Id, PersonFactory.Person1.Id);

            // Modificar valores do objeto origem e validar destino
            lSource.Id = 15;

            Assert.AreEqual(lSource.Id, 15);

            Assert.AreEqual(lDest.Value1Str, "-15a");
            Assert.AreEqual(lDest.Value2Str, "65a");
            Assert.AreEqual(lDest.Value3Str, "95a");
            Assert.AreEqual(lDest.Value4Str, "115a");
            Assert.AreEqual(lDest.Value5Str, "15");
        }
    }
}
