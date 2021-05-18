using BBk.Rc1.Ricis.DataImport.Step.Processors;
using BBk.Rc1.Ricis.DataImport.Step.Reader;
using BBk.Rc1.Ricis.DataImport.Step.Writer;

namespace BBk.Rc1.Ricis.DataImport.Step.ReaderProcessorWriter
{
    public class ReaderProcessorWriter<R, W> : AbstractStep
    {
        private IReader<R> Reader { get; set; }
        private IProcessor<R, W> Processor { get; set; } 
        private IWriter<W> Writer { get; set; }

        public ReaderProcessorWriter<R, W> InitReader(IReader<R> reader)
        {
            Reader = reader;
            return this;
        }

        public ReaderProcessorWriter<R, W> InitProcessor(IProcessor<R, W> processor)
        {
            Processor = processor;
            return this;
        }

        public ReaderProcessorWriter<R, W> InitWriter(IWriter<W> writer)
        {
            Writer = writer;
            return this;
        }

        public override void Execute()
        {
            Writer.Write(Processor.Process(Reader.Read()));
        }
    }
}
