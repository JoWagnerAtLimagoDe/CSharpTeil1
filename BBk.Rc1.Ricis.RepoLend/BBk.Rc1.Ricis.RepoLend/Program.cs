using BBk.Rc1.Ricis.DataImport;
using BBk.Rc1.Ricis.DataImport.Job;
using BBk.Rc1.Ricis.RepoLend.Steps;
using System;

namespace BBk.Rc1.Ricis.RepoLend
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IJob job = new Job())
            {
                job.AddStep(DeleteRepoLendTableStep.GetInstance());
                job.AddStep(RepoLendReaderProcessorWriterStep.GetInstance());
                job.AddStep(JsonOutputTestReaderWriterStep.GetInstance());
                job.AddStep(JsonInputTestReaderWriterStep.GetInstance());
                job.RunAllSteps();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
