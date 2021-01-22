using System;
using System.Collections.Generic;
using System.Text;
using Northwind2.Entities;
using Northwind2.Services;

namespace Northwind2
{
    public class MyApplication:IMyApplication
    {
        private readonly ICustomerService service;


        public MyApplication(ICustomerService service)
        {
            this.service = service;
        }

        public void run()
        {
            Customer c = new Customer
            {
                CustomerId = "BBANK",
                CompanyName = "Bundesbank",
                City = "Ffm",
                Phone = "12345"
            };
         
            service.speichern(c);
         
        }
    }
}
