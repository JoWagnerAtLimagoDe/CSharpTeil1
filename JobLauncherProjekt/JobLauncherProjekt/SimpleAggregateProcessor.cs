using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    public class SimpleAggregateProcessor: AbstractProcessor<IList<string>, int>
    {
        public override int Process(IList<string> p)
        {
            return p.Count;
        }
    }
}
