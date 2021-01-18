using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step.ChunkStep
{
    public interface IReader<out T>
    {
        IList<JobParameter> JobParameters { get; set; }
        IEnumerable<T> GetEnumerator();
    }
}
