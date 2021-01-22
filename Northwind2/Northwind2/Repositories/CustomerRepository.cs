using System;
using System.Collections.Generic;
using System.Text;
using Northwind2.Entities;

namespace Northwind2.Repositories
{
    public class CustomerRepository:CrudRepository<Customer> , ICustomerRepository
    {
        public CustomerRepository(NorthwindContext _context) : base(_context)
        {
        }

        public IList<Customer> findCustomerByCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }
    }
}
