using System.Collections.Generic;
using RicisBatch.Job;

namespace RicisBatch.Step
{
    public abstract class AbstractStep:IStep
    {
        protected IDictionary<string, object> Parameters { get; private set; }

        public void Init()
        {
            Parameters = new Dictionary<string, object>();
        }

        public void Init(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }


        public void Dispose()
        {
            // Ok
        }

        public abstract StepState Execute();
        
    }
}
