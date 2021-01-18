using RicisBatch.Step.ChunkStep;
using System;
using System.Collections.Generic;
using RicisBatch.Job;

namespace JobLauncherProjekt
{
    public class SimpleWriter:IWriter<string>
    {
        public IList<JobParameter> JobParameters { get; set; }
        public void Write(string t)
        {
            Console.WriteLine(t);
            
        }
    }
}
