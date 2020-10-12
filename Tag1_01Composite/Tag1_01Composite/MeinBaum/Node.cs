using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tag1_01Composite.MeinBaum
{
    public class Node : AbstractNode
    {
        private IList<AbstractNode> children { get; set; }
        public Node(string label) : base(label)
        {
            children = new List<AbstractNode>();
        }

        public override IList<AbstractNode> GetChildren()
        {
            return new ReadOnlyCollection<AbstractNode>(children);
        }

        public virtual void AppendChild(AbstractNode child)
        {
            child.Parent = this;
            children.Add(child);
        }


        public virtual void RemoveChild(AbstractNode child)
        {
            child.Parent = null;
            children.Remove(child);
        }

        public override string ToString()
        {
            return $"Node Name={Label}";
        }
    }
}
