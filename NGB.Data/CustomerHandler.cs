using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NGB.Domain;

namespace NGB.Data
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
            var customerList = new List<Customer>();

            using (var context = new BeanContext())
            {
                customerList = context.Customer
                    .Include(c=>c.ContactEvents)
                    .ToList();
            }
            return customerList;

        }

        public List<Customer> FindCustomersByCompanyName(string companyName)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var context = new BeanContext())
            {
                context.Customer.Update(customer);
                context.SaveChanges();

            }
        }
    }
}
