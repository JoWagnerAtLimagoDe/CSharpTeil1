using Newtonsoft.Json;
using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.Json
{
    public class JsonReader<T> : AbstractFileReader<T> 
        where T : class
    {

        public JsonReader(IStreamReaderResource resource): base(resource)
        {
            
        }

        public override T Read()
        {
            using (StreamReader reader = Resource.GetStreamReader())
            {
                return (T) new JsonSerializer().Deserialize(reader, typeof(T));
            }
        }

    }
}
