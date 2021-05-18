using System;
using System.Globalization;
using System.Numerics;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using NUnit.Framework;

namespace BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader
{
    public class FileSetTest
    {

        private FieldSet _objectUnderTest;
        [SetUp]
        public void Setup()
        {
            string[] tokens =
            {
                null,
                "Hallo", 
                bool.TrueString, 
                byte.MaxValue.ToString(), 
                sbyte.MaxValue.ToString(), 
                short.MaxValue.ToString(),
                ushort.MaxValue.ToString(),
                int.MaxValue.ToString(),
                uint.MaxValue.ToString(),
                long.MaxValue.ToString(),
                ulong.MaxValue.ToString(),
                float.MaxValue.ToString(new NumberFormatInfo()),
                double.MaxValue.ToString(new NumberFormatInfo()),
                BigInteger.One.ToString(),
                "20200514",
                "18:38:00"
            };

            _objectUnderTest = new FieldSet(tokens)
            {
                Names = CreateNames()
            };
        }

        [Test]
        public void ReadStringByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadString(100));
         
        }
        [Test]
        public void ReadStringByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadString(0, "*EMPTY*");
            Assert.That(value, Is.EqualTo("*EMPTY*"));
        }

        [Test]
        public void ReadStringByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadString(1);
            Assert.That(value, Is.EqualTo("Hallo"));
        }
        [Test]
        public void ReadStringByName_ColumnValueIsValid_returnsColumnValue()
        {
           
            var value = _objectUnderTest.ReadString("String");
            Assert.That(value, Is.EqualTo("Hallo"));
        }


        [Test]
        public void ReadBoolByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadBool(100));

        }
        [Test]
        public void ReadBoolByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadBool(0,false);
            Assert.That(value, Is.EqualTo(false));
        }

        [Test]
        public void ReadBoolByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadBool(2);
            Assert.That(value, Is.EqualTo(true));
        }
        [Test]
        public void ReadBoolByName_ColumnValueIsValid_returnsColumnValue()
        {
            
            var value = _objectUnderTest.ReadBool("Bool");
            Assert.That(value, Is.EqualTo(true));
        }
        [Test]
        public void ReadByteByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>_objectUnderTest.ReadByte(100));

        }
        [Test]
        public void ReadByteByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadByte(0, 10);
            Assert.That(value, Is.EqualTo(10));
        }

        [Test]
        public void ReadByteByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadByte(3);
            Assert.That(value, Is.EqualTo(byte.MaxValue));
        }
        [Test]
        public void ReadByteByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadByte("Byte");
            Assert.That(value, Is.EqualTo(byte.MaxValue));
        }
        [Test]
        public void ReadSByteByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadSByte(100));

        }
        [Test]
        public void ReadSByteByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadSByte(0, 3);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void ReadSByteByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadSByte(4, 3);
            Assert.That(value, Is.EqualTo(SByte.MaxValue));
        }
        [Test]
        public void ReadSByteByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadSByte("SByte");
            Assert.That(value, Is.EqualTo(SByte.MaxValue));
        }
        [Test]
        public void ReadShortByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadShort(100));

        }
        [Test]
        public void ReadShortByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadShort(0, 3);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void ReadShortByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadShort(5);
            Assert.That(value, Is.EqualTo(short.MaxValue));
        }
        [Test]
        public void ReadShortByName_ColumnValueIsValid_returnsColumnValue()
        {
           
            var value = _objectUnderTest.ReadShort("Short");
            Assert.That(value, Is.EqualTo(short.MaxValue));
        }
        [Test]
        public void ReadUShortByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadUShort(100));

        }
        [Test]
        public void ReadUShortByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadUShort(0, 3);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void ReadUShortByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadUShort(6, 3);
            Assert.That(value, Is.EqualTo(ushort.MaxValue));
        }
        [Test]
        public void ReadUShortByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadUShort("UShort", 3);
            Assert.That(value, Is.EqualTo(ushort.MaxValue));
        }

        [Test]
        public void ReadIntByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadInteger(100));

        }
        [Test]
        public void ReadIntByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadInteger(0, 3);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void ReadIntByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadInteger(7);
            Assert.That(value, Is.EqualTo(int.MaxValue));
        }
        [Test]
        public void ReadIntByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadInteger("Int");
            Assert.That(value, Is.EqualTo(int.MaxValue));
        }
      
        [Test]
        public void ReadLongByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadLong(0, 3);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void ReadLongByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadLong(9);
            Assert.That(value, Is.EqualTo(long.MaxValue));
        }
        [Test]
        public void ReadLongByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadLong("Long");
            Assert.That(value, Is.EqualTo(long.MaxValue));
        }
        [Test]
        public void ReadULongByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadULong(100));

        }
        [Test]
        public void ReadULongByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadULong(0, ulong.MaxValue);
            Assert.That(value, Is.EqualTo(ulong.MaxValue));
        }

        [Test]
        public void ReadULongByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadULong(10);
            Assert.That(value, Is.EqualTo(ulong.MaxValue));
        }
        [Test]
        public void ReadULongByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadULong("ULong");
            Assert.That(value, Is.EqualTo(ulong.MaxValue));
        }
        [Test]
        public void ReadFloatByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadFloat(100));

        }
        [Test]
        public void ReadFloatByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadFloat(0, (float?)3.0);
            Assert.That(value, Is.EqualTo(3.0));
        }

        [Test]
        public void ReadFloatByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadFloat(11);
            Assert.That(value, Is.EqualTo(float.MaxValue));
        }
        [Test]
        public void ReadFloatByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadFloat("Float");
            Assert.That(value, Is.EqualTo(float.MaxValue));
        }
        [Test]
        public void ReadDoubleByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadDouble(100));

        }
        [Test]
        public void ReadDoubleByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadDouble(0, 0.3);
            Assert.That(value, Is.EqualTo(0.3));
        }

        [Test]
        public void ReadDoubleByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadDouble(12);
            Assert.That(value, Is.EqualTo(double.MaxValue));
        }
        [Test]
        public void ReadDoubleByName_ColumnValueIsValid_returnsColumnValue()
        {
            _objectUnderTest.Names = CreateNames();
            var value = _objectUnderTest.ReadDouble("Double");
            Assert.That(value, Is.EqualTo(double.MaxValue));
        }
        [Test]
        public void ReadBigIntegerByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadBigInteger(100));

        }
        [Test]
        public void ReadBigIntegerByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadBigInteger(0, BigInteger.One);
            Assert.That(value, Is.EqualTo(BigInteger.One));
        }

        [Test]
        public void ReadBigIntegerByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadBigInteger(13);
            Assert.That(value, Is.EqualTo(BigInteger.One));
        }
        [Test]
        public void ReadBigIntegerByName_ColumnValueIsValid_returnsColumnValue()
        {
            _objectUnderTest.Names = CreateNames();
            var value = _objectUnderTest.ReadBigInteger("BigInteger");
            Assert.That(value, Is.EqualTo(BigInteger.One));
        }
        [Test]
        public void ReadDateTimeByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadDateTime(100));

        }
        [Test]
        public void ReadDateTimeByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadDateTime(0, DateTime.MaxValue);
            Assert.That(value, Is.EqualTo(DateTime.MaxValue));
            
        }

        [Test]
        public void ReadDateTimeByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadDateTime(14);
            Assert.That(value.Day, Is.EqualTo(14));
            Assert.That(value.Month, Is.EqualTo(5));
            Assert.That(value.Year, Is.EqualTo(2020));
        }
        [Test]
        public void ReadDateTimeByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadDateTime("DateTime");
            Assert.That(value.Day, Is.EqualTo(14));
            Assert.That(value.Month, Is.EqualTo(5));
            Assert.That(value.Year, Is.EqualTo(2020));
        }
        [Test]
        public void ReadTimeByPosition_IllegalPosition_throwsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => _objectUnderTest.ReadTime(100));

        }
        [Test]
        public void ReadTimeByPosition_ColumnValueIsNull_returnsDefaultValue()
        {
            var value = _objectUnderTest.ReadTime(0, TimeSpan.MaxValue);
            Assert.That(value, Is.EqualTo(TimeSpan.MaxValue));
        }

        [Test]
        public void ReadTimeByPosition_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadTime(15);
            
            Assert.That(value.Hours, Is.EqualTo(18));
            Assert.That(value.Minutes, Is.EqualTo(38));
            Assert.That(value.Seconds, Is.EqualTo(0));
        }
        [Test]
        public void ReadTimeByName_ColumnValueIsValid_returnsColumnValue()
        {
            var value = _objectUnderTest.ReadTime("Time");

            Assert.That(value.Hours, Is.EqualTo(18));
            Assert.That(value.Minutes, Is.EqualTo(38));
            Assert.That(value.Seconds, Is.EqualTo(0));
        }


        private string[] CreateNames()
        {
            string [] names = 
            {
                "Empty",
                "String", 
                "Bool", 
                "Byte", 
                "SByte", 
                "Short",
                "UShort",
                "Int",
                "UInt",
                "Long",
                "ULong",
                "Float",
                "Double",
                "BigInteger",
                "DateTime",
                "Time"
            };
            return names;
        }

    }
}
