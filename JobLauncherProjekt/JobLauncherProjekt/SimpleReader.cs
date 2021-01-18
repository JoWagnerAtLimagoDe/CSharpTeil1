using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Job;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    public class SimpleReader: IReader<string>
    {
        public IList<JobParameter> JobParameters { get; set; }
        public IEnumerable<string> GetEnumerator()
        {
            IList<string> strings = new List<string>();
            strings.Add("Eins");
            strings.Add("Zwei");
            strings.Add("Drei");
            strings.Add("Vier");
            strings.Add("Fünf");

            //return strings;
            
            foreach (var s in strings)
            {
                yield return s;
            }
            
            yield return "zwei";
            yield return "drei"; 
            yield return "vier";
            yield return "fünf";
        }
    }
}
