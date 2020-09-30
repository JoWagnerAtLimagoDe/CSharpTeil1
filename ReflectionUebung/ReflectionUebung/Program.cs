using System;

namespace ReflectionUebung
{
    class Program
    {
        static void Main(string[] args)
        {
            Object obj = new CreateAndFillObject().process("ReflectionUebung.Person");
            Console.WriteLine(obj);
        }
    }
}
