using RicisBatch.Job;
using RicisBatch.Step.ChunkStep;
using System.Collections.Generic;

namespace JobLauncherProjekt
{
    public class SimpleProcessor:IProcessor<string,string>
    {
        public IList<JobParameter> JobParameters { get; set; }

        public string Process(string p)
        {
            return p.ToUpper();
        }
    }
}
