using System;

namespace DependencyDemoProjekt
{
    public class DependencyImpl: IDependency
    {
        public DependencyImpl()
        {
                
        }
        public void Foo()
        {
            Console.WriteLine("Hier ist foo aus Dependency");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose of DependencyImpl");
        }
    }
}
