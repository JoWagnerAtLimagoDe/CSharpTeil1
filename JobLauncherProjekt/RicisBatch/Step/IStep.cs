using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step
{
    public interface IStep
    {
        void Init(IDictionary<string, object> parameters);
        void Init();
        StepState Execute();

        void Dispose();
    }
}
