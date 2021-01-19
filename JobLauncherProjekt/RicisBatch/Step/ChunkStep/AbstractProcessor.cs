using System;
using System.Collections.Generic;
using System.Text;

namespace RicisBatch.Step.ChunkStep
{
    public abstract class AbstractProcessor<P, R> : IProcessor<P, R>
    {

        protected IDictionary<string, object> Parameters { get; private set; }

        public void SetJobParameter(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }

        public abstract R Process(P p);
    }
}
