using System;
using System.Collections.Generic;
using System.Text;

namespace Tag1_01Composite.MeinBaum
{
    public class Leaf : AbstractNode
    {
        public Leaf(string label) : base(label)
        {
        }

        public override string ToString()
        {
            return $"Leaf: Name={Label}";
        }
    }
}
