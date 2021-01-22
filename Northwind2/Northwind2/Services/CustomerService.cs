using System;
using System.Collections.Generic;
using System.Text;
using Northwind2.Entities;
using Northwind2.Repositories;

namespace Northwind2.Services
{
    public class CustomerService: ICustomerService
    {

        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public void speichern(Customer customer)
        {
            if (customer.CompanyName == null)
                throw new Exception("Upps");
            
            repository.Insert(customer);
            repository.Save();
        }
    }
}
