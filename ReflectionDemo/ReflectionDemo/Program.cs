using System;
using System.Collections;
using System.Reflection;
using Tiere;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Schwein);
            type = new Schwein().GetType();
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            type = currentAssem.GetType("Tiere.Schwein");
            Console.WriteLine(type.Name);
            object obj = Activator.CreateInstance(type);
            Console.WriteLine(obj);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach(MethodInfo info in methodInfos)
            {
                Console.WriteLine(info.Name);

            }

            MethodInfo mi = type.GetMethod("Fressen",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            _ = mi.Invoke(obj, new object[] { }); 
            Console.WriteLine(obj);
            
        }
    }
}
