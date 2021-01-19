using RicisBatch.Job;
using RicisBatch.Step.ChunkStep;
using System.Collections.Generic;

namespace JobLauncherProjekt
{
    public class SimpleProcessor:AbstractProcessor<FxRateItem,string>
    {
       

        public override  string Process(FxRateItem item)
        {
            
            return item.ToString();
        }
    }
}
