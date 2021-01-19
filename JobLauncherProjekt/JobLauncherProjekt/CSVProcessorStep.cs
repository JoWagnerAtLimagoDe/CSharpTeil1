using RicisBatch.Step.ChunkStep;

namespace JobLauncherProjekt
{
    public class CSVProcessorStep: ChunkStep<FxRateItem, string>
    {
        public CSVProcessorStep()
        {
            //{
            CompositeProcessor<FxRateItem, string> c = new CompositeProcessor<FxRateItem, string>();
            c.AddProcessor(new SimpleProcessor());
            c.AddProcessor(new ToUpperProcessor());
            
            
            InitReader(new SimpleReader());
            InitProcessor(c);
            InitWriter(new SimpleWriter());
        }
    }
}
