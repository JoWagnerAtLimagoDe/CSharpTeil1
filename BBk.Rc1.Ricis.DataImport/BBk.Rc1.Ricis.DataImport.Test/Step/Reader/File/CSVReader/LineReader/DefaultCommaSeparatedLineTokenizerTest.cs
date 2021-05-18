using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using NUnit.Framework;

namespace BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader
{
    public class DefaultCommaSeparatedLineTokenizerTest
    {
        private DefaultCommaSeparatedLineTokenizer _objectUnderTest;
        [SetUp]
        public void Setup()
        {


            _objectUnderTest = new DefaultCommaSeparatedLineTokenizer(",");

        }

        [Test]
        public void Tokenize_HappyDay_Success()
        {
            FieldSet set = _objectUnderTest.Tokenize("abc,4711,20200516");

            var first = set.ReadString(0);
            var second = set.ReadInteger(1) ;
            var third = set.ReadDateTime(2) ;

            Assert.That(first, Is.EqualTo("abc"));

            Assert.That(second, Is.EqualTo(4711));

            Assert.That(third.Day, Is.EqualTo(16));
            Assert.That(third.Month, Is.EqualTo(5));
            Assert.That(third.Year, Is.EqualTo(2020));
        }
       

    }
}
