using RicisBatch.Job;
using System.Collections.Generic;

namespace RicisBatch.Step.ChunkStep
{
    public interface IProcessor<in P, out R>
    {

        void SetJobParameter(IDictionary<string, object> parameters);
        R Process(P p);
        
    }
}
