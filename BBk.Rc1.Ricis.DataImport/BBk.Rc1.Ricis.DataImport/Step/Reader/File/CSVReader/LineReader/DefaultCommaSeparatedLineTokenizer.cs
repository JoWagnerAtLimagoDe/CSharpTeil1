namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader
{
    public class DefaultCommaSeparatedLineTokenizer:ILineTokenizer
    {
        public string Delimiter { get; set; } 
        public DefaultCommaSeparatedLineTokenizer(string delimiter = ";")
        {
            Delimiter = delimiter;
        }

        public virtual FieldSet Tokenize(string line)
        {
            return new FieldSet(line.Split(Delimiter));
        }
    }
}
