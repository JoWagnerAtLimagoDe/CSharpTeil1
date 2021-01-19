using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    public class SimpleAggregateWriter: AbstractWriter<int>
    {
        public override void Write(int t)
        {
            Console.WriteLine($"Anzahl der Zeilen ist {t}.");
        }
    }
}
