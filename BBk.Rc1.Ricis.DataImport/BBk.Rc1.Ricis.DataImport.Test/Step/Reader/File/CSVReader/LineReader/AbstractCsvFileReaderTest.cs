using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;
using BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader.SupportingClasses;
using NUnit.Framework;

namespace BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader
{
    public class AbstractCsvFileReaderTest
    {
        private AbstractCsvFileReader<DummyPoco> _objectUnderTest;
        private ILineTokenizer _lineTokenizer;
        private StreamReader _resource;

        [SetUp]
        public void setUp()
        {
            _lineTokenizer = new DefaultCommaSeparatedLineTokenizer(",");
            
        }


        [Test]
        public void Read_NoHeadlines_Success()
        {
            // Arrange
            IStreamReaderResource stream = new StringStreamReaderResource("Hallo,1,20200516\nWelt,2,20200517");
            _objectUnderTest = new AbstractCsvFileReaderPostionDummyForTest(stream, _lineTokenizer, false);

            // Act
            IList<DummyPoco> pocos = _objectUnderTest.Read();

            Assert.That(pocos.Count, Is.EqualTo(2));

        }

        [Test]
        public void Read_WithHeadlines_Success()
        {
            // Arrange
            IStreamReaderResource stream = new StringStreamReaderResource("First,Second,Third\nHallo,1,20200516\nWelt,2,20200517");
            _objectUnderTest = new AbstractCsvFileReaderNamedDummyForTest(stream, _lineTokenizer, true);

            // Act
            IList<DummyPoco> pocos = _objectUnderTest.Read();

            Assert.That(pocos.Count, Is.EqualTo(2));

        }

       
    }
}
