using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;

namespace RicisBatch.Step.ChunkStep
{
    public class ChunkStep<R,W>:AbstractStep
    {
        private IReader<R> Reader { get; set; }
        private IProcessor<R,W> Processor { get; set; }
        private IWriter<W> Writer { get; set; }

        private readonly ILogger logger; 
        
        public ChunkStep()
        {
            //ILoggerFactory loggerFactory = new LoggerFactory();

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
           

            logger = loggerFactory.CreateLogger< ChunkStep<R, W>>();
            
        }
       
        
        
        public ChunkStep<R, W> InitReader(IReader<R> reader)
        {
            Reader = reader;
            Reader.JobParameters = JobParameters;
            logger.Log(LogLevel.Information, "Reader wurde registriert");
            return this;
        }

        public ChunkStep<R, W> InitProcessor(IProcessor<R,W> processor)
        {
            Processor = processor;
            Processor.JobParameters = JobParameters;
            logger.Log(LogLevel.Information, "Processor wurde registriert");
            return this;
        }

        public ChunkStep<R, W> InitWriter(IWriter<W> writer)
        {
            Writer = writer;
            Writer.JobParameters = JobParameters;
            logger.Log(LogLevel.Information, "Writer wurde registriert");
            return this;
        }


        public override StepState Execute()
        {

            try
            {
                return Transactionsklammer();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e, "Transaction rollback");
                
                return StepState.Failure;
            }
        }

        private StepState Transactionsklammer()
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                ExcecuteImpl();

                transactionScope.Complete();
            }
            logger.Log(LogLevel.Information, "Transaction commited");
            return StepState.Success;
        }

        private void ExcecuteImpl()
        {
            logger.Log(LogLevel.Debug, "Starte Verarbeitung");
            foreach (R item in Reader.GetEnumerator())
            {
                var ergebnis = Processor.Process(item);
                if (ergebnis != null)
                {
                    Writer.Write(ergebnis);
                }
                else
                {
                    logger.Log(LogLevel.Warning,  $"Element {item} wurde nicht verarbeitet");
                }
                
            }
            logger.Log(LogLevel.Debug, "Beende Verarbeitung");
        }
    }
}
