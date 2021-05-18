using System;
using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader.SupportingClasses
{
    public class AbstractCsvFileReaderPostionDummyForTest: AbstractCsvFileReader<DummyPoco>
    {
        public AbstractCsvFileReaderPostionDummyForTest(IStreamReaderResource source, ILineTokenizer tokenizer, bool headlines) : base(source, tokenizer, headlines)
        {
        }

        protected override DummyPoco CovertFieldSetToObject(FieldSet fieldSet)
        {
            return new DummyPoco
            {
                First = fieldSet.ReadString(0) ,
                Second = fieldSet.ReadInteger(1) ,
                Third = fieldSet.ReadDateTime(2) 
            };
        }
    }
}
