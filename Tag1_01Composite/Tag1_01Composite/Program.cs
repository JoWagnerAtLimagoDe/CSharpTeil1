using System;
using Tag1_01Composite.MeinBaum;

namespace Tag1_01Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node("root");

            Node e1_1 = new Node("e1_1");
            root.AppendChild(e1_1);

            Node e1_2 = new Node("e1_2");
            root.AppendChild(e1_2);

            Node e2_1 = new Node("e2_1");
            e1_1.AppendChild(e2_1);

            Node e2_2 = new Node("e2_2");
            e1_1.AppendChild(e2_2);


            Node e2_3 = new Node("e2_3");
            e1_2.AppendChild(e2_3);

            Node e2_4 = new Node("e2_4");
            e1_2.AppendChild(e2_4);

            Leaf e2_5 = new Leaf("e2_5");
            e1_2.AppendChild(e2_5);
            Travers(root,0);
        }

        private static void Travers(AbstractNode node, int ebene)
        {
            for (int i = 0; i < ebene; i++)
                Console.Write("\t");
            Console.WriteLine(node);
            ebene++;
            foreach (AbstractNode item in node.GetChildren())
            {
                Travers(item, ebene);
            }
        }
    }
}
