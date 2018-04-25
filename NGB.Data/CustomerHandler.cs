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

        public void AddNewBeanType(BeanTypes beanTypes)
        {
            using (var context = new BeanContext())
            {
                context.BeanTypes.Add(beanTypes);
                context.SaveChanges();
            }
        }


        public List<Customer> ListAllCustomers()
        {
            var customerList = new List<Customer>();

            using (var context = new BeanContext())
            {
                customerList = context.Customer
                    .Include(c => c.ContactEvents)
                    .ToList();
            }
            return customerList;

        }

        public List<Customer> FindCustomersByCompanyName(string companyName)
        {
            var companyNameList = new List<Customer>();
            using (var context = new BeanContext())
            {
                var customersByName = context.Customer.Where(c => c.CompanyName.Contains(companyName)).Include(c => c.ContactEvents);
                foreach (var customer in customersByName)
                {
                    companyNameList.Add(customer);
                }

                return companyNameList;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var context = new BeanContext())
            {
                context.Customer.Update(customer);
                context.SaveChanges();

            }
        }

        public List<Customer> FindCustomerByFirstName(string firstName)
        {
            var firstNameList = new List<Customer>();
            using (var context = new BeanContext())
            {
                var customerByFirstName = context.Customer.Where(c => c.FirstName.Contains(firstName)).Include(c => c.ContactEvents);
                foreach (var customer in customerByFirstName)
                {
                    firstNameList.Add(customer);
                }

                return firstNameList;
            }
        }
        public List<Customer> FindCustomerByLastName(string lastName)
        {
            var lastNameList = new List<Customer>();
            using (var context = new BeanContext())
            {
                var customerByLastName = context.Customer.Where(c => c.Lastname.Contains(lastName)).Include(c => c.ContactEvents);
                foreach (var customer in customerByLastName)
                {
                    lastNameList.Add(customer);
                }

                return lastNameList;
            }
        }

    }
}
