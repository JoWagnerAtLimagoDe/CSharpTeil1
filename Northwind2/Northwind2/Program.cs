using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.DependencyInjection;
using Northwind2.Entities;
using Northwind2.Repositories;
using Northwind2.Services;


namespace Northwind2
{

  
    
    class Program
    {
        static void Main(string[] args)
        {
            new Program().run();
        }

        private void run()
        {
            var serviceCollection = new ServiceCollection();

            RegisterServices(serviceCollection);

            using var serviceProvider = serviceCollection.BuildServiceProvider();


            var app = (IMyApplication)serviceProvider.GetService(typeof(IMyApplication));
            app.run();
        }

        private static void RegisterServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<NorthwindContext, NorthwindContext>();
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<IMyApplication, MyApplication>();
            
        }

       
    }
    }


