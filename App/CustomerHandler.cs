using System;
using System.Collections.Generic;
using System.Text;
using NGB.Data;
using NGB.Domain;

namespace NGB.App
{
    class CustomerHandler
    {
        public void AddNewCustomer(Customer customer)
        {
            using (var context = new BeanContext())
            {
                context.Customer.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
