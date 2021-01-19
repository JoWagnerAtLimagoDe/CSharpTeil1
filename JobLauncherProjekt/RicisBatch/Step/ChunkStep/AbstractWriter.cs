using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Step.ChunkStep;

namespace RicisBatch.Step.ChunkStep
{
    public abstract class AbstractWriter<T>: IWriter<T>

    {
        protected IDictionary<string, object> Parameters { get; private set; }

        public void SetJobParameter(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }

        public abstract void Write(T t);
    }
}
