using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step.ChunkStep
{
    public interface IReader<out T>
    {
        void SetJobParameter(IDictionary<string, object> parameters);
        IEnumerable<T> GetEnumerator();
    }
}
