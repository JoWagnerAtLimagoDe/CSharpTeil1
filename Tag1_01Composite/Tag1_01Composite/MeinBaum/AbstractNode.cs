using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tag1_01Composite.MeinBaum
{
    public abstract class AbstractNode
    {
        public string Label { get; set; }
        public AbstractNode Parent { get; set; }

        public AbstractNode(string label)
        {
            Label = label;
            Parent = null;
        }

        public virtual IList<AbstractNode> GetChildren()
        {
            return new List<AbstractNode>().AsReadOnly();
        }

        public override string ToString()
        {
            return $"AbstractNode Name={Label}";
        }
    }
}
