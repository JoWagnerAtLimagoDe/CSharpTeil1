using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using RicisBatch.Step;

namespace JobLauncherProjekt
{
    public class UndTschuessStep:AbstractStep
    {
        public override StepState Execute()
        {
            Console.WriteLine("....und Tschüss");
            return StepState.Success;
        }
    }
}
