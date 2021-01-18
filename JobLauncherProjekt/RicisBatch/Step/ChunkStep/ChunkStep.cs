using System;
using System.Collections.Generic;
using System.Transactions;

namespace RicisBatch.Step.ChunkStep
{
    public class ChunkStep<R,W>:AbstractStep
    {
        private IReader<R> Reader { get; set; }
        private IProcessor<R,W> Processor { get; set; }
        private IWriter<W> Writer { get; set; }

        public ChunkStep<R, W> InitReader(IReader<R> reader)
        {
            Reader = reader;
            Reader.JobParameters = JobParameters;
            return this;
        }

        public ChunkStep<R, W> InitProcessor(IProcessor<R,W> processor)
        {
            Processor = processor;
            Processor.JobParameters = JobParameters;
            return this;
        }

        public ChunkStep<R, W> InitWriter(IWriter<W> writer)
        {
            Writer = writer;
            Writer.JobParameters = JobParameters;
            return this;
        }


        public override StepState Execute()
        {

            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    IEnumerable<R> enumerator = Reader.GetEnumerator();
                    foreach (R item in enumerator)
                    {
                        var ergebnis = Processor.Process(item);
                        if (ergebnis != null)
                        {
                            Writer.Write(ergebnis);
                        }
                        else
                        {
                            // Logge unverarbeitete Elemente
                        }
                    }
                    transactionScope.Complete();
                }
                return StepState.Success;
                    
            }
            catch (Exception e)
            {
                // Loggen
                return StepState.Failure;
            }
        }
    }
}
