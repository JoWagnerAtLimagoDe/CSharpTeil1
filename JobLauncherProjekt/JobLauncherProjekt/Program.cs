using System;
using System.Collections.Generic;
using RicisBatch.Job;
using RicisBatch.Step;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    class Program
    {
        static void Main(string[] args)
        {

            IJob myJob = new Job(new List<JobParameter>());
            myJob.RegisterParameter(new JobParameter("filename", "c:\\tmp\\210115_FX_Res.csv"));
            
            
            ChunkStep<FxRateItem, string> myChunkStep = new ChunkStep<FxRateItem, string>();
            myChunkStep
                .InitReader(new SimpleReader())
                .InitProcessor(new SimpleProcessor())
                .InitWriter(new SimpleWriter());


            myJob.RegisterStep(new InitStep());
            myJob.RegisterStep(myChunkStep);
            myJob.RegisterStep(new UndTschuessStep());


            myJob.Execute();
                

            Console.WriteLine("Ende");
        }
    }
}

