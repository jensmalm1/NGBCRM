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
            var companyNameList = new List<Customer>();
            using (var context = new BeanContext())
            {
                var cName = context.Customer.First(c => c.CompanyName == companyName);
                foreach (var name in companyNameList)
                {
                    companyNameList.Add(name);
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
                var fName = context.Customer.First(c => c.FirstName == firstName);
                foreach (var name in firstNameList)
                {
                    firstNameList.Add(name);
                }

                return firstNameList;
            }
        }
        public List<Customer> FindCustomerByLastName(string lastName)
        {
            var lastNameList = new List<Customer>();
            using (var context = new BeanContext())
            {
                var lName = context.Customer.First(c => c.LastName == lastName);
                foreach (var name in lastNameList)
                {
                    lastNameList.Add(name);
                }

                return flastNameList;
            }
        }
    }
}
