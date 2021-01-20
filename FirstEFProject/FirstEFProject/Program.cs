using System;
using System.Linq;
using FirstEFProject.Persistence;
using FirstEFProject.Persistence.Model;

namespace FirstEFProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using var context = new EntityFrameworkContext();
            
            context.Database.EnsureCreated();
            
            
            var john = new Person
            {
                PersonId = Guid.NewGuid(),
                Vorname = "John",
                Nachname = "Doe"
            };

            context.PersonSet.Add(john);

            var anzahl = context.SaveChanges();
            Console.WriteLine(anzahl);

            var personenSet = context.PersonSet.ToList();
            Console.WriteLine(personenSet);
        }
    }
}
