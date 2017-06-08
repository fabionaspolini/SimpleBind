using NUnit.Framework;
using System;
using SimpleBind.Examples.Model;

namespace SimpleBind.Core.Test
{
    [TestFixture]
    public class SetterMethodTest
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
            var lDest = new TempDataInt();

            var lContainer = new BindContainer<TempDataString>(lSource);

            // SetterDataConverter
            lContainer.CreateBind(lDest)
                .From(s => s.Value1Str,
                    config => config.SetterDataConverter((source, dest, value) => ((int) value * -1).ToString() + "a"))
                .To(d => d.Value1Int)
                .DestToSourceWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value2Str,
                    config => config.SetterDataConverter<int>((source, dest, value) => (value + 50).ToString() + "a"))
                .To(d => d.Value2Int)
                .DestToSourceWay();

            // SetterMethod
            lContainer.CreateBind(lDest)
                .From(config => config.SetterMethod(
                    (source, dest, value) => source.Value3Str = ((int)value + 80).ToString() + "a"))
                .To(d => d.Value3Int)
                .DestToSourceWay();

            lContainer.CreateBind(lDest)
                .From(config => config.SetterMethod<int>(
                    (source, dest, value) => source.Value4Str = (value + 100).ToString() + "a"))
                .To(d => d.Value4Int)
                .DestToSourceWay();

            lContainer.Apply();

            // Validar que os valores iniciais do objeto origem estão da mesma forma como foram criado
            Assert.AreEqual(lDest.Value1Int, 0);
            Assert.AreEqual(lDest.Value2Int, 0);
            Assert.AreEqual(lDest.Value3Int, 0);
            Assert.AreEqual(lDest.Value4Int, 0);

            // Modificar valores do destino origem e validar origem
            lDest.Value1Int = 15;
            lDest.Value2Int = 15;
            lDest.Value3Int = 15;
            lDest.Value4Int = 15;

            Assert.AreEqual(lDest.Value1Int, 15);
            Assert.AreEqual(lDest.Value2Int, 15);
            Assert.AreEqual(lDest.Value3Int, 15);
            Assert.AreEqual(lDest.Value4Int, 15);

            Assert.AreEqual(lSource.Value1Str, "-15a");
            Assert.AreEqual(lSource.Value2Str, "65a");
            Assert.AreEqual(lSource.Value3Str, "95a");
            Assert.AreEqual(lSource.Value4Str, "115a");
        }

        [Test]
        public void SourceToDestTest()
        {
            var lSource = new TempDataInt();
            var lDest = new TempDataString();

            var lContainer = new BindContainer<TempDataInt>(lSource);

            // SetterDataConverter
            lContainer.CreateBind(lDest)
                .From(s => s.Value1Int)
                .To(d => d.Value1Str,
                    config => config.SetterDataConverter((source, dest, value) => ((int) value * -1).ToString() + "a"))
                .SourceToDestWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value2Int)
                .To(d => d.Value2Str,
                    config => config.SetterDataConverter<int>((source, dest, value) => (value + 50).ToString() + "a"))
                .SourceToDestWay();

            // SetterMethod
            lContainer.CreateBind(lDest)
                .From(s => s.Value3Int)
                .To(config => config.SetterMethod(
                    (source, dest, value) => dest.Value3Str = ((int)value + 80).ToString() + "a"))
                .SourceToDestWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value4Int)
                .To(config => config.SetterMethod<int>(
                    (source, dest, value) => dest.Value4Str = (value + 100).ToString() + "a"))
                .SourceToDestWay();

            lContainer.Apply();

            // Validar que os valores iniciais do objeto origem estão da mesma forma como foram criado
            Assert.AreEqual(lSource.Value1Int, 0);
            Assert.AreEqual(lSource.Value2Int, 0);
            Assert.AreEqual(lSource.Value3Int, 0);
            Assert.AreEqual(lSource.Value4Int, 0);

            // Modificar valores do objeto origem e validar destino
            lSource.Value1Int = 15;
            lSource.Value2Int = 15;
            lSource.Value3Int = 15;
            lSource.Value4Int = 15;

            Assert.AreEqual(lSource.Value1Int, 15);
            Assert.AreEqual(lSource.Value2Int, 15);
            Assert.AreEqual(lSource.Value3Int, 15);
            Assert.AreEqual(lSource.Value4Int, 15);

            Assert.AreEqual(lDest.Value1Str, "-15a");
            Assert.AreEqual(lDest.Value2Str, "65a");
            Assert.AreEqual(lDest.Value3Str, "95a");
            Assert.AreEqual(lDest.Value4Str, "115a");
        }

        [Test]
        public void TwoWayTest()
        {
            var lSource = new TempDataInt();
            var lDest = new TempDataString();

            var lContainer = new BindContainer<TempDataInt>(lSource);

            // SetterDataConverter
            lContainer.CreateBind(lDest)
                .From(s => s.Value1Int,
                    config => config.SetterDataConverter((source, dest, value) => Convert.ToInt32(value.ToString().Remove(value.ToString().Length - 1)) * -1))
                .To(d => d.Value1Str,
                    config => config.SetterDataConverter((source, dest, value) => ((int) value * -1).ToString() + "a"))
                .TwoWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value2Int,
                    config => config.SetterDataConverter<string>((source, dest, value) => Convert.ToInt32(value.Remove(value.Length - 1)) - 50))
                .To(d => d.Value2Str,
                    config => config.SetterDataConverter<int>((source, dest, value) => (value + 50).ToString() + "a"))
                .TwoWay();

            // SetterMethod
            lContainer.CreateBind(lDest)
                .From(s => s.Value3Int, config => config.SetterMethod(
                    (source, dest, value) => source.Value3Int = Convert.ToInt32(value.ToString().Remove(value.ToString().Length - 1)) - 80))
                .To(d => d.Value3Str, config => config.SetterMethod(
                    (source, dest, value) => dest.Value3Str = ((int) value + 80).ToString() + "a"))
                .TwoWay();

            lContainer.CreateBind(lDest)
                .From(s => s.Value4Int, config => config.SetterMethod<string>(
                    (source, dest, value) => source.Value4Int = Convert.ToInt32(value.Remove(value.Length - 1)) - 100))
                .To(d => d.Value4Str, config => config.SetterMethod<int>(
                    (source, dest, value) => dest.Value4Str = (value + 100).ToString() + "a"))
                .TwoWay();

            lContainer.Apply();

            // Validar que os valores iniciais do objeto origem estão da mesma forma como foram criado
            Assert.AreEqual(lSource.Value1Int, 0);
            Assert.AreEqual(lSource.Value2Int, 0);
            Assert.AreEqual(lSource.Value3Int, 0);
            Assert.AreEqual(lSource.Value4Int, 0);

            // Modificar valores do objeto origem e validar se refletiu no destino
            lSource.Value1Int = 15;
            lSource.Value2Int = 15;
            lSource.Value3Int = 15;
            lSource.Value4Int = 15;

            Assert.AreEqual(lDest.Value1Str, "-15a");
            Assert.AreEqual(lDest.Value2Str, "65a");
            Assert.AreEqual(lDest.Value3Str, "95a");
            Assert.AreEqual(lDest.Value4Str, "115a");

            Assert.AreEqual(lSource.Value1Int, 15);
            Assert.AreEqual(lSource.Value2Int, 15);
            Assert.AreEqual(lSource.Value3Int, 15);
            Assert.AreEqual(lSource.Value4Int, 15);

            // Modificar valores do objeto destino e validar se refletiu no origem
            lDest.Value1Str = "-25a";
            Assert.AreEqual(lSource.Value1Int, 25);
            Assert.AreEqual(lDest.Value1Str, "-25a");

            lDest.Value2Str = "80a";
            Assert.AreEqual(lSource.Value2Int, 30);
            Assert.AreEqual(lDest.Value2Str, "80a");

            lDest.Value3Str = "150a";
            Assert.AreEqual(lSource.Value3Int, 70);
            Assert.AreEqual(lDest.Value3Str, "150a");

            lDest.Value4Str = "200a";
            Assert.AreEqual(lSource.Value4Int, 100);
            Assert.AreEqual(lDest.Value4Str, "200a");
        }
    }
}
