using System;

namespace JobLauncherProjekt
{
    public class FxRateItem
    {
        public FxRateItem()
        {
            
        }
        public FxRateItem(string name, string remarks, DateTime date, double value)
        {
            Name = name;
            Remarks = remarks;
            Date = date;
            Value = value;
        }

        public string Name { get; set; }
        public string Remarks { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Remarks)}: {Remarks}, {nameof(Date)}: {Date}, {nameof(Value)}: {Value}";
        }
    }
}
