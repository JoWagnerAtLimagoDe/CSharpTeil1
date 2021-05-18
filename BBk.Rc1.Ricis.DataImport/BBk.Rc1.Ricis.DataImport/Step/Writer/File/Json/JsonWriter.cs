using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Writer.File.Resources;
using Newtonsoft.Json;

namespace BBk.Rc1.Ricis.DataImport.Step.Writer.File.Json
{
    public class JsonWriter<T> : AbstractWriter<T> 
        where T : class
    {
        public IStreamWriterResource Resource { get; set; }

        public JsonWriter(IStreamWriterResource resource)
        {
            Resource = resource;
        }

        public override void Write(T t)
        {
            using (StreamWriter writer = Resource.GetStreamWriter())
            {
                new JsonSerializer().Serialize(writer, t, typeof(T));
            }

        }

       
    }
}
