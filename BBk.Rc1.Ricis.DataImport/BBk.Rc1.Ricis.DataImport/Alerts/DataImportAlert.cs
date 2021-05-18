using System;
using System.Collections.Generic;

namespace BBk.Rc1.Ricis.DataImport.Alerts
{
    public class DataImportAlert
    {
        public Guid AlertId { get; set; }
        public AlertLevel Level { get; set; }
        public Type IOType { get; set; } //evtl. String des Namens ausreichend? (für code first)
        public List<AlertField> AlertFields { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        // Alternative zu Alert Message: Alert Code als Key eines Alert Message Dictionary

        public override string ToString() => $"{Level}, {Time}, {Message}";
    }
}
