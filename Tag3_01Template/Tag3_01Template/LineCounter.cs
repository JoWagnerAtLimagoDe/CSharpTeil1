using System;
using System.Collections.Generic;
using System.Text;

namespace Tag3_01Template
{
    public class LineCounter : FileProcessor
    {
        private int counter;

        public override void Init()
        {
            counter = 0;
        }

        public override void Process(char zeichen)
        {
            if (zeichen == '\n')
                counter++;
        }

        public override void Close()
        {
            Console.WriteLine(counter);
        }
    }
}
