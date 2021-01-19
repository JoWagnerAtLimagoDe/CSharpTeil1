using System.Collections.Generic;
using RicisBatch.Step;

namespace RicisBatch.Job

{
    public interface IJob
    {
       
        IJob Step(IStep step);
        IJob RegisterParameter(string key, object value);
        void Execute();
        void Init();
        void Dispose();
    }
}
