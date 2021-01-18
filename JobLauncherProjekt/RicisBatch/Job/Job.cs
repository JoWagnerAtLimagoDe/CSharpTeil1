using RicisBatch.Step;
using System;
using System.Collections.Generic;

namespace RicisBatch.Job
{
    public class Job:IJob
    {
        private readonly IList<JobParameter> Parameters;
        private readonly IList<IStep> Steps = new List<IStep>();

        public Job(IList<JobParameter> parameters)
        {
            Parameters = parameters;
        }
        public IList<JobParameter> GetParameters()
        {
            return Parameters;
        }

        public IJob RegisterStep(IStep step)
        {
            step.JobParameters = Parameters;
            Steps.Add(step);
            return this;
        }

        public IJob RegisterParameter(JobParameter parameter)
        {
            Parameters.Add(parameter);
            return this;
        }

        public void Execute()
        {
            foreach (var step in Steps)
            {
                step.Init();
                
                if (step.Execute() != StepState.Success)
                    throw new Exception("Upps"); // Todo Fix This

                step.Dispose();
            }
        }

        public void Init()
        {
            
        }

        public void Dispose()
        {
           
        }
    }
}
