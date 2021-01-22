using System;

namespace DependencyDemoProjekt
{
    public interface IDependency:IDisposable
    {
        void Foo();
    }
}
