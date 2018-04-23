using System;
using System.Collections.Generic;
using System.Text;
using NGB.Data;
using NGB.Domain;

namespace NGB.App
{
    public class CustomerHandler
    {
        public void AddNewCustomer(Customer customer)
        {
            using (var context = new BeanContext())
            {
                context.Customer.Add(customer);
                context.SaveChanges();
            }
        }

        public void ListAllCustomers()
        {
            var customerlist = new List<Customer>();

            using (var context = new BeanContext())
            {
                foreach (var customer in customerlist)
                {
                    customerlist.Add(customer);
                }
            }
            
        }

    }
}
