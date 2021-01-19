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
            
            logger.Log(LogLevel.Information, "Reader wurde registriert");
            return this;
        }

        public ChunkStep<R, W> InitProcessor(IProcessor<R,W> processor)
        {
            Processor = processor;
            
            logger.Log(LogLevel.Information, "Processor wurde registriert");
            return this;
        }

        public ChunkStep<R, W> InitWriter(IWriter<W> writer)
        {
            Writer = writer;
            
            logger.Log(LogLevel.Information, "Writer wurde registriert");
            return this;
        }

        
        public override StepState Execute()
        {

            try
            {
                ExcecuteImpl();
                return StepState.Success;
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e, "Fehler beim Verarbeiten des Chunkstep");
                
                return StepState.Failure;
            }
        }


        private void ExcecuteImpl()
        {
            logger.Log(LogLevel.Debug, "Starte Verarbeitung");
            Reader.SetJobParameter(Parameters);
            Processor.SetJobParameter(Parameters);
            Writer.SetJobParameter(Parameters);
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
