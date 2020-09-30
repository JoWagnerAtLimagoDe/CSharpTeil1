using System;

namespace Tag3_01Template
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor processor = new CharacterCounter();
            processor.Run("c:\\tmp\\baerchen.txt");
        }
    }
}
