using BBk.Rc1.Ricis.DataImport.Step.Processors;
using BBk.Rc1.Ricis.DataImport.Step.ReaderProcessorWriter;
using BBk.Rc1.Ricis.DataImport.Step.Writer.File.Json;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using BBk.Rc1.Ricis.RepoLend.Steps.Reader;
using System.Collections.Generic;
using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Writer.File.Resources;

namespace BBk.Rc1.Ricis.RepoLend.Steps
{
    public class JsonOutputTestReaderWriterStep:ReaderProcessorWriter<IList<RepoLendIO>, IList<RepoLendIO>>
    {
        public static JsonOutputTestReaderWriterStep GetInstance()
        {
            var step = new JsonOutputTestReaderWriterStep();
            step
                .InitReader(RepoLendCsvReader.GetInstance())
                .InitProcessor(new IdentityProcessor<IList<RepoLendIO>>())
                .InitWriter(new JsonWriter<IList<RepoLendIO>>(new FileStreamWriterResource(@"C:\Users\JoachimWagner\Documents\Projekte\Buba\RC_UMSATZREPO_anonymisiert.json")));
            return step;
        }
    }
}
