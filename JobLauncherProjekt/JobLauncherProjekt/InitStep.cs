using System;
using System.Collections.Generic;
using System.Text;
using RicisBatch.Step;

namespace JobLauncherProjekt
{
    public class InitStep: AbstractStep
    {
        public override StepState Execute()
        {
           Console.WriteLine("Jetzt geht's los");
           return StepState.Success;
        }
    }
}
