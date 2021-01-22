using System;
using System.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyDemoProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            //serviceCollection.TryAddSingleton<IDependency, DependencyImpl>();
            serviceCollection.TryAddSingleton<IMyService, MyServiceImpl>();
            serviceCollection.TryAddSingleton<IDependency>(new DependencyImpl());

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {


                var myService = (IMyService)serviceProvider.GetService(typeof(IMyService));
                myService.DoIt();

                //IDependency dependency = new DependencyImpl();
                //IMyService service = new MyServiceImpl(dependency);

                //service.DoIt();


                Console.WriteLine("Hello World!");
            }

    }
    }
}
