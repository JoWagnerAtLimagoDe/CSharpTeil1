using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Channels;

namespace Tag3_01Template
{
    public abstract class FileProcessor
    {

        public void Run(string filename)
        {
            using(StreamReader input = new StreamReader(filename))
            {
                Init();
                int zeichen;

                while ((zeichen = input.Read()) != -1)
                {
                    Process((char)zeichen);
                }

                Close();
            }

           
        }

        public virtual void Close()
        {
            
        }

        public abstract void Process(char zeichen);
        public virtual void Init()
        {

        }
    }
}
