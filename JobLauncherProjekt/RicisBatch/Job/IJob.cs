using System.Collections.Generic;
using RicisBatch.Step;

namespace RicisBatch.Job

{
    public interface IJob
    {
        IList<JobParameter> GetParameters();
        IJob RegisterStep(IStep step);
        IJob RegisterParameter(JobParameter parameter);
        void Execute();
        void Init();
        void Dispose();
    }
}
