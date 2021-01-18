using System;
using RicisBatch.Step;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            ChunkStep<string, string> myChunkStep = new ChunkStep<string, string>();
            StepState ergebnis = myChunkStep
                .InitReader(new SimpleReader())
                .InitProcessor(new SimpleProcessor())
                .InitWriter(new SimpleWriter())
                .Execute();

            Console.WriteLine(ergebnis);
        }
    }
}

