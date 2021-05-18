using System.Collections.Generic;
using System.IO;
using System.Linq;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader
{
    public abstract class AbstractCsvFileReader<T>: AbstractFileReader<IList<T>>
    {



        public ILineTokenizer Tokenizer { get; set; }
        public bool Headlines { get;  }

        private string[] Names { get; set; }

        private StreamReader _reader = null;

        protected AbstractCsvFileReader(IStreamReaderResource source, ILineTokenizer tokenizer, bool headlines = false):base(source)
        {
            Tokenizer = tokenizer;
            Headlines = headlines;
        }

        private IEnumerable<T> ReadLines()
        {

            string line;
            
            line = _reader.ReadLine();
            if (Headlines)
                ReadNames(Tokenizer.Tokenize(line));
            else
            {
                yield return ConversionWrapper(line);
            }

            while ((line = _reader.ReadLine()) != null)
            {
                yield return ConversionWrapper(line);
                
            }
           
        }

        private T ConversionWrapper(string  line)
        {
            var fieldSet = Tokenizer.Tokenize(line);
            fieldSet.Names = Names;
            return CovertFieldSetToObject(fieldSet);
        }
        public override IList<T> Read()
        {
            using (_reader = Resource.GetStreamReader())
            {
                return ReadLines().ToList();
            }
        }

        protected abstract T CovertFieldSetToObject(FieldSet fieldSet);

        private void ReadNames(FieldSet set)
        {
            List<string> names = new List<string>();
            for(var i = 0; i < set.ColumnCount; i++)
                names.Add(set.ReadString(i));
            Names = names.ToArray();
        }

       
    }

   
}
