using System;
using System.Collections.Generic;
using System.Text;
using Northwind2.Entities;

namespace Northwind2.Repositories
{
    public interface ICustomerRepository: ICrudRepository<Customer> 
    {
            
        IList<Customer> findCustomerByCompanyName(string companyName);
    }
}
