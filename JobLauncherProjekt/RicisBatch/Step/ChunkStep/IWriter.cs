using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step.ChunkStep
{
    public interface IWriter<in T>
    {
        void SetJobParameter(IDictionary<string, object> parameters);
        void Write(T t);
    }
}
