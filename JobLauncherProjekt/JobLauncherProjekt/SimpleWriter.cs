using RicisBatch.Step.ChunkStep;
using System;
using System.Collections.Generic;
using RicisBatch.Job;

namespace JobLauncherProjekt
{
    public class SimpleWriter:AbstractWriter<string>
    {
       
        
        
        public override  void Write(string t)
        {
            Console.WriteLine(t);
           ( (IList<string>)Parameters["aggregatorList"]).Add(t);
            
        }
    }
}
