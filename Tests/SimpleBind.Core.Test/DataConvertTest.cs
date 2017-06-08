using System;
using NUnit.Framework;

namespace SimpleBind.Core.Test
{
    [TestFixture]
    public class DataConvertTest
    {
        [SetUp]
        public void Init()
        {
            BindEngine.Initialize(new BindPlataformDefault());
        }

        /* Tipos básicos:
        - bool
        - byte
        - char
        - decimal
        - double
        - float
        - int
        - long
        - sbyte
        - short
        - string
        - DateTime */

        [Test]
        public void ToBoolTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(bool), true),
                true);

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(byte), Convert.ToByte(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(decimal), Convert.ToDecimal(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDecimal(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(double), Convert.ToDouble(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDouble(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(float), Convert.ToSingle(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToSingle(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(int), Convert.ToInt32(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(long), Convert.ToInt64(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt64(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(short), Convert.ToInt16(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt16(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(string), Convert.ToString("true", BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToString("true"), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(bool), true),
                true);

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(byte), Convert.ToByte(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(decimal), Convert.ToDecimal(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDecimal(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(double), Convert.ToDouble(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDouble(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(float), Convert.ToSingle(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToSingle(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(int), Convert.ToInt32(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(long), Convert.ToInt64(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt64(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(short), Convert.ToInt16(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt16(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(string), Convert.ToString("true", BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToString("true"), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(bool?), true),
                true);

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(byte?), Convert.ToByte(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(decimal?), Convert.ToDecimal(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDecimal(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(double?), Convert.ToDouble(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDouble(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(float?), Convert.ToSingle(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToSingle(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(int?), Convert.ToInt32(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(long?), Convert.ToInt64(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt64(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool>(typeof(short?), Convert.ToInt16(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt16(1), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(bool?), true),
                true);

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(byte?), Convert.ToByte(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(decimal?), Convert.ToDecimal(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDecimal(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(double?), Convert.ToDouble(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToDouble(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(float?), Convert.ToSingle(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToSingle(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(int?), Convert.ToInt32(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt32(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(long?), Convert.ToInt64(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt64(1), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<bool?>(typeof(short?), Convert.ToInt16(1, BindEngine.DefaultCultureInfo)),
                Convert.ToBoolean(Convert.ToInt16(1), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToByteTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(byte), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(decimal), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(double), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(float), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(int), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(long), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(short), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(sbyte), Convert.ToSByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(string), Convert.ToString("45", BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToString("45", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(byte), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(decimal), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(double), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(float), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(int), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(long), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(short), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(sbyte), Convert.ToSByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(string), Convert.ToString("45", BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToString("45", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(byte?), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(decimal?), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(double?), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(float?), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(int?), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(long?), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(short?), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte>(typeof(sbyte?), Convert.ToSByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSByte(32), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(byte?), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(decimal?), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(double?), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(float?), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(int?), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(long?), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(short?), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<byte?>(typeof(sbyte?), Convert.ToSByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToByte(Convert.ToSByte(32), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToCharTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(char), Convert.ToChar('S', BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToChar('S', BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(int), Convert.ToInt32(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt32(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(long), Convert.ToInt64(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt64(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(short), Convert.ToInt16(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt16(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(string), Convert.ToString("S", BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToString("S", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(char), Convert.ToChar('S', BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToChar('S', BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(int), Convert.ToInt32(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt32(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(long), Convert.ToInt64(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt64(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(short), Convert.ToInt16(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt16(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(string), Convert.ToString("S", BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToString("S", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(char?), Convert.ToChar('S', BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToChar('S', BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(int?), Convert.ToInt32(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt32(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(long?), Convert.ToInt64(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt64(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char>(typeof(short?), Convert.ToInt16(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt16(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(char?), Convert.ToChar('S', BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToChar('S', BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(int?), Convert.ToInt32(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt32(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(long?), Convert.ToInt64(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt64(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<char?>(typeof(short?), Convert.ToInt16(65, BindEngine.DefaultCultureInfo)),
                Convert.ToChar(Convert.ToInt16(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToDecimalTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<decimal?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDecimal(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToDoubleTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<double?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToDouble(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToFloatTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(string), Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToString("74123,32456", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<float?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToSingle(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToIntTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(byte), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(sbyte), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(string), Convert.ToString("74123", BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToString("74123", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(string), Convert.ToString("74123", BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToString("74123", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<int?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt32(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToLongTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(byte), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(sbyte), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(string), Convert.ToString("74123", BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToString("74123", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(byte), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(sbyte), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(string), Convert.ToString("74123", BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToString("74123", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<long?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt64(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToSByteTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(byte), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(decimal), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(double), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(float), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(int), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(long), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(short), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(string), Convert.ToString("45", BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToString("45", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(byte), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(decimal), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(double), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(float), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(int), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(long), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(short), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(string), Convert.ToString("45", BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToString("45", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(byte?), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(decimal?), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(double?), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(float?), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(int?), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(long?), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte>(typeof(short?), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(byte?), Convert.ToByte(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToByte(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(decimal?), Convert.ToDecimal(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDecimal(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(double?), Convert.ToDouble(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToDouble(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(float?), Convert.ToSingle(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToSingle(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(int?), Convert.ToInt32(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt32(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(long?), Convert.ToInt64(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt64(32), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<sbyte?>(typeof(short?), Convert.ToInt16(32, BindEngine.DefaultCultureInfo)),
                Convert.ToSByte(Convert.ToInt16(32), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToShortTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(byte), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(decimal), Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(double), Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(float), Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(int), Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(long), Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(sbyte), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(string), Convert.ToString("7423", BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToString("7423", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(byte), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(decimal), Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(double), Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(float), Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(int), Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(long), Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(sbyte), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(short), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(string), Convert.ToString("7423", BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToString("7423", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(decimal?), Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(double?), Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(float?), Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(int?), Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(long?), Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(byte?), Convert.ToByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(decimal?), Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDecimal(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(double?), Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToDouble(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(float?), Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSingle(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(int?), Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt32(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(long?), Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt64(7423.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(sbyte?), Convert.ToSByte(65, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToSByte(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<short?>(typeof(short?), Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToInt16(Convert.ToInt16(7413.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToStringTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(bool), Convert.ToBoolean(1, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToBoolean(1, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(byte), Convert.ToByte(45, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToByte(45, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(char), Convert.ToChar(65, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToChar(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(decimal), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(double), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(float), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(int), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(long), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(sbyte), Convert.ToSByte(50, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToSByte(50, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(short), Convert.ToInt16(200, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt16(200, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(string), Convert.ToString(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToString(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(DateTime), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(bool?), Convert.ToBoolean(1, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToBoolean(1, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(byte?), Convert.ToByte(45, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToByte(45, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(char?), Convert.ToChar(65, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToChar(65, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(decimal?), Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDecimal(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(double?), Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDouble(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(float?), Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToSingle(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(int?), Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt32(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(long?), Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt64(74123.32456, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(sbyte?), Convert.ToSByte(50, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToSByte(50, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(short?), Convert.ToInt16(200, BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToInt16(200, BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<string>(typeof(DateTime?), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToString(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }

        [Test]
        public void ToDateTimeTest()
        {
            #region Value to Value

            Assert.AreEqual(
                BindEngine.ToValue<DateTime>(typeof(DateTime), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<DateTime>(typeof(string), Convert.ToString("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToString("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<DateTime?>(typeof(DateTime), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            Assert.AreEqual(
                BindEngine.ToValue<DateTime?>(typeof(string), Convert.ToString("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToString("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Nullable<> to Value

            Assert.AreEqual(
                BindEngine.ToValue<DateTime>(typeof(DateTime?), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion

            #region Value to Nullable<>

            Assert.AreEqual(
                BindEngine.ToValue<DateTime?>(typeof(DateTime?), Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo)),
                Convert.ToDateTime(Convert.ToDateTime("2017-03-30T15:45:50", BindEngine.DefaultCultureInfo), BindEngine.DefaultCultureInfo));

            #endregion
        }
    }
}