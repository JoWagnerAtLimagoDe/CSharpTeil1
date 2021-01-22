using System;

namespace DependencyDemoProjekt
{
    public class MyServiceImpl: IMyService
    {
        private IDependency Dependency { get; }

        public MyServiceImpl(IDependency dependency)
        {
            this.Dependency = dependency;
        }

        public void DoIt()
        {
            Dependency.Foo();
        }
    }
}
