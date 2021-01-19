using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    public class SimpleReaderAggregateReader: AbstractReader<IList<string>>
    {
        public override IEnumerable<IList<string>> GetEnumerator()
        { 
            yield return (IList<string>)Parameters["aggregatorList"];
        }
    }
}
