using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.CSVReader.LineReader;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using System;
using System.IO;
using BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources;

namespace BBk.Rc1.Ricis.RepoLend.Steps.Reader
{
    public class RepoLendCsvReader:AbstractCsvFileReader<RepoLendIO>
    {
        public RepoLendCsvReader(IStreamReaderResource source, ILineTokenizer tokenizer, bool headlines = true) : base(source, tokenizer, headlines)
        {
        }

        protected override RepoLendIO CovertFieldSetToObject(FieldSet fieldSet)
        {
            
            return new RepoLendIO
            {
                Guid = Guid.NewGuid(),
                Ab2 = fieldSet.ReadDecimal("AB2"),
                Ab1 = fieldSet.ReadDecimal("AB1") ,
                Beleg = fieldSet.ReadString("BELEG"),
                Datum = fieldSet.ReadDateTime("DATUM"),
                Datumab = fieldSet.ReadDateTime("DATUMAB"),
                Denr = fieldSet.ReadString("DENR"),
                Intrefrc = fieldSet.ReadString("INTREFRC"),
                Lfzb = fieldSet.ReadDateTime("LFZB"),
                Lfzv = fieldSet.ReadDateTime("LFZV"),
                Marktkurs = fieldSet.ReadDecimal("MARKTKURS"),
                Nennwert = fieldSet.ReadDecimal("NENNWERT"),
                Reart = fieldSet.ReadString("REART"),
                Reartbez = fieldSet.ReadString("REARTBEZ"),
                Snr = fieldSet.ReadString("SNR"),
                Snrbezk = fieldSet.ReadString("SNRBEZK"),
                Snrk = fieldSet.ReadString("SNRK"),
                Statb = fieldSet.ReadString("STATB"),
                Storno = fieldSet.ReadString("STORNO"),
                Whgu = fieldSet.ReadString("WHGU"),
                Wpbezk = fieldSet.ReadString("WPBEZK"),
                Wpnr = fieldSet.ReadString("WPNR"),
                Zeitab = fieldSet.ReadTime("ZEITAB"),
                Zs = fieldSet.ReadDecimal("ZS"),
                Zsmodb = fieldSet.ReadString("ZSMODB"),
                Zstage = fieldSet.ReadInteger("ZSTAGE"),
                SsmaTimeStamp = null

            };
        }

        public static RepoLendCsvReader GetInstance()
        {
            RepoLendCsvReader instance = new RepoLendCsvReader(
                new FileStreamReaderResource(@"C:\Users\JoachimWagner\Documents\Projekte\Buba\RC_UMSATZREPO_anonymisiert.csv"),
                new DefaultCommaSeparatedLineTokenizer(),
                true);
            return instance;
        }
    }
}
