using System;

namespace JobLauncherProjekt
{
    public class FxRateItem
    {
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
