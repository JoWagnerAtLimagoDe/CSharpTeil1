using RicisBatch.Job;
using System.Collections.Generic;

namespace RicisBatch.Step.ChunkStep
{
    public interface IProcessor<in P, out R> {

        IList<JobParameter> JobParameters { get; set; }
        R Process(P p);
        
    }
}
