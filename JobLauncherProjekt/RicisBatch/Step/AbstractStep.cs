using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step
{
    public abstract class AbstractStep:IStep
    {
        public IList<JobParameter> JobParameters { get; set; } = new List<JobParameter>();
        public void Init()
        {
            // Ok
        }

        public void Dispose()
        {
            // Ok
        }

        public abstract StepState Execute();
        
    }
}
