using BBk.Rc1.Ricis.DataImport.Step.ReaderProcessorWriter;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using BBk.Rc1.Ricis.RepoLend.Steps.Processors;
using BBk.Rc1.Ricis.RepoLend.Steps.Reader;
using BBk.Rc1.Ricis.RepoLend.Steps.Writer;
using System.Collections.Generic;

namespace BBk.Rc1.Ricis.RepoLend.Steps
{
    public class RepoLendReaderProcessorWriterStep: ReaderProcessorWriter<IList<RepoLendIO>, IList<RepoLendIO>>
    {

        public static RepoLendReaderProcessorWriterStep GetInstance()
        {
            var step = new RepoLendReaderProcessorWriterStep();
            step
                .InitReader(RepoLendCsvReader.GetInstance())
                .InitProcessor(RepoLendCheckerProcessor.GetInstance())
                .InitWriter(RepoLendRepositoryWriter.GetInstance());
            return step;
        }
    }

   
}
