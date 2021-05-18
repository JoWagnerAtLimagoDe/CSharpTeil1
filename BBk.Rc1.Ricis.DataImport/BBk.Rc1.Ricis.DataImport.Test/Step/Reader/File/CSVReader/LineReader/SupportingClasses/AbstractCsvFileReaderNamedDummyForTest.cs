using System;
using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.DataImport.Test.Step.Reader.File.CSVReader.LineReader.SupportingClasses
{
    public class AbstractCsvFileReaderNamedDummyForTest: AbstractCsvFileReader<DummyPoco>
    {
        public AbstractCsvFileReaderNamedDummyForTest(IStreamReaderResource source, ILineTokenizer tokenizer, bool headlines) : base(source, tokenizer, headlines)
        {
        }

        protected override DummyPoco CovertFieldSetToObject(FieldSet fieldSet)
        {
            return new DummyPoco
            {
                First = fieldSet.ReadString("First") ,
                Second = fieldSet.ReadInteger("Second"),
                Third = fieldSet.ReadDateTime("Third") 
            };
        }
    }
}
