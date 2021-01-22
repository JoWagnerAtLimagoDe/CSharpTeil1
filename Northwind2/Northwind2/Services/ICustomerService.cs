using System;
using System.Collections.Generic;
using System.Text;
using Northwind2.Entities;

namespace Northwind2.Services
{
    public interface ICustomerService
    {

        void speichern(Customer customer);
    }
}
