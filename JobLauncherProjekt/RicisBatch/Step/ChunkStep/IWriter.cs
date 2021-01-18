using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step.ChunkStep
{
    public interface IWriter<in T>
    {
        IList<JobParameter> JobParameters { get; set; }
        void Write(T t);
    }
}
