using RicisBatch.Step;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace RicisBatch.Job
{
    public class Job:IJob
    {
        private readonly IDictionary<string, object> Parameters;
        private readonly IList<IStep> Steps = new List<IStep>();

        public Job()
        {
            Parameters = new Dictionary<string, object>();
        }
        
        public Job(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }
        public IDictionary<string, object> GetParameters()
        {
            return Parameters;
        }

        public IJob Step(IStep step)
        {
            
            Steps.Add(step);
            return this;
        }

        public IJob RegisterParameter(string key, object value)
        {
            Parameters.Add(key,value);
            return this;
        }

        public void Execute()
        {
            foreach (var step in Steps)
            {
                step.Init(Parameters);

                using (var scope = new TransactionScope())
                {
                    if (step.Execute() != StepState.Success)
                        throw new Exception("Upps"); // Todo Fix This
                        
                    scope.Complete();
                   
                }

               
                //StepState result = (StepState) Ext.Atomic(() => step.Execute());

                //if (result!= StepState.Success)
                //    throw new Exception("Upps"); // Todo Fix This

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
