using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step
{
    public interface IStep
    {
        IList<JobParameter> JobParameters { get; set; }
        void Init();
        StepState Execute();

        void Dispose();
    }
}
