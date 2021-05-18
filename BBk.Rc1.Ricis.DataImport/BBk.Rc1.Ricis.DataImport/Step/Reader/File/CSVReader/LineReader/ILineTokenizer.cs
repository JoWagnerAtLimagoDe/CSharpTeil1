namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader
{
    public interface ILineTokenizer
    {
        FieldSet Tokenize(string line);
    }
}
