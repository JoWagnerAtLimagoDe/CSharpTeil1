using System;
using BBk.Rc1.Ricis.DataImport.Step;

namespace BBk.Rc1.Ricis.DataImport.Job
{
    public interface IJob: IDisposable
    {
        void AddStep(IStep step);
        void RemoveStep(IStep step);

        void RunAllSteps();
    }
}
