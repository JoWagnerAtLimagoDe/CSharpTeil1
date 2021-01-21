using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Northwind2.Entities;

namespace Northwind2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindContext context = new NorthwindContext())
            {


                var abfrage = from c in context.Customers select c;


                var list = abfrage.Skip(10).Take(10).ToList();

                foreach (var customer in list)
                {
                    Console.WriteLine(customer);
                }

            }
            
            
            
            
            
        }
    }
}
