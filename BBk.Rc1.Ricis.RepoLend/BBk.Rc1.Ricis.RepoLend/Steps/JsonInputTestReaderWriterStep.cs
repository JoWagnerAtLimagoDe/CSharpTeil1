using BBk.Rc1.Ricis.DataImport.Step.ReaderProcessorWriter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BBk.Rc1.Ricis.DataImport.Step.Processors;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Json;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;
using BBk.Rc1.Ricis.DataImport.Step.Writer.Console;
using BBk.Rc1.Ricis.DataImport.Step.Writer.File.Json;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using BBk.Rc1.Ricis.RepoLend.Steps.Reader;

namespace BBk.Rc1.Ricis.RepoLend.Steps
{
    public class JsonInputTestReaderWriterStep : ReaderProcessorWriter<IList<RepoLendIO>, IList<RepoLendIO>>
    {
        public static JsonInputTestReaderWriterStep GetInstance()
        {
            var step = new JsonInputTestReaderWriterStep();
            step
                .InitReader(new JsonReader<IList<RepoLendIO>>(new FileStreamReaderResource(@"C:\Users\JoachimWagner\Documents\Projekte\Buba\RC_UMSATZREPO_anonymisiert.json")))
                .InitProcessor(new IdentityProcessor<IList<RepoLendIO>>())
                .InitWriter(new ConsoleWriter<IList<RepoLendIO>>());
            return step;
        }
    }
   

    
}
