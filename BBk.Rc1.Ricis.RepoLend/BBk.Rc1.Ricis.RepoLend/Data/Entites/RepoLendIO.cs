using System;
using System.ComponentModel.DataAnnotations;

namespace BBk.Rc1.Ricis.RepoLend.Data.Entites
{
    public class RepoLendIO
    {
        [Key]
        public Guid Guid { get; set; }
        public string Beleg { get; set; }
        public DateTime Datumab { get; set; }
        public TimeSpan Zeitab { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Lfzv { get; set; }
        public DateTime Lfzb { get; set; }
        public int Zstage { get; set; }
        public string Snr { get; set; }
        public string Denr { get; set; }
        public string Storno { get; set; }
        public string Reart { get; set; }
        public string Reartbez { get; set; }
        public string Wpnr { get; set; }
        public string Wpbezk { get; set; }
        public string Snrk { get; set; }
        public string Snrbezk { get; set; }
        // ISO 4217-Währung eventuell als enumeration abbilden
        public string Whgu { get; set; }
        public decimal Ab1 { get; set; }
        public decimal Ab2 { get; set; }
        public decimal Zs { get; set; }
        public string Zsmodb { get; set; }
        public string Statb { get; set; }
        public string Intrefrc { get; set; }
        public decimal Marktkurs { get; set; }
        public decimal Nennwert { get; set; }
        [Timestamp]
        public byte[] SsmaTimeStamp { get; set; }

        public override string ToString()
        {
            return $"{nameof(Guid)}: {Guid}, {nameof(Beleg)}: {Beleg}, {nameof(Datumab)}: {Datumab}, {nameof(Zeitab)}: {Zeitab}, {nameof(Datum)}: {Datum}, {nameof(Lfzv)}: {Lfzv}, {nameof(Lfzb)}: {Lfzb}, {nameof(Zstage)}: {Zstage}, {nameof(Snr)}: {Snr}, {nameof(Denr)}: {Denr}, {nameof(Storno)}: {Storno}, {nameof(Reart)}: {Reart}, {nameof(Reartbez)}: {Reartbez}, {nameof(Wpnr)}: {Wpnr}, {nameof(Wpbezk)}: {Wpbezk}, {nameof(Snrk)}: {Snrk}, {nameof(Snrbezk)}: {Snrbezk}, {nameof(Whgu)}: {Whgu}, {nameof(Ab1)}: {Ab1}, {nameof(Ab2)}: {Ab2}, {nameof(Zs)}: {Zs}, {nameof(Zsmodb)}: {Zsmodb}, {nameof(Statb)}: {Statb}, {nameof(Intrefrc)}: {Intrefrc}, {nameof(Marktkurs)}: {Marktkurs}, {nameof(Nennwert)}: {Nennwert}, {nameof(SsmaTimeStamp)}: {SsmaTimeStamp}";
        }
    }
}
