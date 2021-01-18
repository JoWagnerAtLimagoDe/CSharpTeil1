using RicisBatch.Job;
using RicisBatch.Step.ChunkStep;
using System.Collections.Generic;

namespace JobLauncherProjekt
{
    public class SimpleProcessor:IProcessor<FxRateItem,string>
    {
        public IList<JobParameter> JobParameters { get; set; }

        public string Process(FxRateItem item)
        {
            if (item.Value > 100) return null;
            return item.ToString();
        }
    }
}
