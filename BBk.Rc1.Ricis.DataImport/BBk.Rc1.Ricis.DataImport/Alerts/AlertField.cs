using System;
using System.Reflection;

namespace BBk.Rc1.Ricis.DataImport.Alerts
{
    public class AlertField
    {
        public Guid IOGuid { get; set; }
        public PropertyInfo PropertyInfo { get; set; } //evtl. String des Namens ausreichend? (für code first)
    }
}
