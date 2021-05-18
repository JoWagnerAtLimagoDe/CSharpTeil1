using System.Collections.Generic;
using BBk.Rc1.Ricis.DataImport.Step;

namespace BBk.Rc1.Ricis.DataImport.Job
{
    public class Job: IJob
    {

        private readonly List<IStep> _steps = new List<IStep>();

        public void AddStep(IStep step)
        {
            _steps.Add(step);
        }

        public virtual void Dispose()
        {
            // Ok
        }

        public void RemoveStep(IStep step)
        {
            _steps.Remove(step);
        }

        public void RunAllSteps()
        {
            foreach (var step in _steps)
            {
                step.Init();
                step.Execute();
                step.Dispose();
            }
        }
    }
}
