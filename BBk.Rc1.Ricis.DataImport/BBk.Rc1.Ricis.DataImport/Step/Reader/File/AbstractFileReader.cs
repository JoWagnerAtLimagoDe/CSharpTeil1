using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File
{
    public abstract class AbstractFileReader<T>: AbstractReader<T>
    {
        public IStreamReaderResource Resource { get; }
       
        protected AbstractFileReader(IStreamReaderResource resource)
        {
            Resource = resource;

        }

        
    }
}
