using System;
using System.Collections.Generic;
using System.Text;

namespace RicisBatch.Step.ChunkStep
{
    public abstract class AbstractReader<T>: IReader<T>
    {
        protected IDictionary<string, object> Parameters { get; private set; }

        public void SetJobParameter(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }

      

        public abstract IEnumerable<T> GetEnumerator();
    }
}
