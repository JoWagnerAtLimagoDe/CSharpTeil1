using System;
using System.Collections.Generic;
using System.Text;

namespace Tag3_01Template
{
    public class CharacterCounter : FileProcessor
    {
        private int counter = 0;
        public override void Process(char zeichen)
        {
            counter++;
        }

        public override void Close()
        {
            Console.WriteLine(counter);
        }
    }
}
