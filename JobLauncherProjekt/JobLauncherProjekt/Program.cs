using System;
using System.Collections.Generic;
using System.Reflection;
using RicisBatch;
using RicisBatch.Job;
using RicisBatch.Step;
using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    class Program
    {
        static void Main(string[] args)
        {

            new Job()
                .RegisterParameter("filename", "c:\\tmp\\210115_FX_Res.csv")
                .RegisterParameter("maxvalue", "100.0")
                .RegisterParameter("aggregatorList", new List<string>())
                .Step(new InitStep())
                .Step(new CSVProcessorStep())
                .Step(CreateAggregateStep())
                .Step(new UndTschuessStep())
                .Execute();
                

            Console.WriteLine("Ende");
        }

        private static ChunkStep<IList<string>, int> CreateAggregateStep()
        {
            ChunkStep<IList<string>, int> myAggregateStep = new ChunkStep<IList<string>, int>();
            myAggregateStep
                .InitReader(new SimpleReaderAggregateReader())
                .InitProcessor(new SimpleAggregateProcessor())
                .InitWriter(new SimpleAggregateWriter());
            return myAggregateStep;
        }

       
    }

    class MyLoggingAdvice : IBeforeAdvice
    {
        public void Process(object target, MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine(targetMethod.Name + " wurde gerufen. #########################");
        }
    }
    class MyOtherLoggingAdvice : IBeforeAdvice
    {
        public void Process(object target, MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine(targetMethod.Name + " wurde gerufen. ----------------------------");
        }
    }
}

