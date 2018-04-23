using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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


        public List<Customer> ListAllCustomers()
        {
            var customerlist = new List<Customer>();

            using (var context = new BeanContext())
            {
                customerlist = context.Customer
                    .Include(c=>c.ContactLog)
                    .ToList();
            }
            return customerlist;

        }

    }
}
