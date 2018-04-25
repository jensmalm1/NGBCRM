using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NGB.Domain;
using NGB.Data;

namespace NGB.App
{
    class AddTestData
    {
        Customer customer = new Customer();

        public void AddTestBeanTypes()
        {
            CustomerHandler customerHandler = new CustomerHandler();

            BeanTypes beanTypes = new BeanTypes();
            beanTypes.Name = "Ekologist";
            customerHandler.AddNewBeanType(beanTypes);

            BeanTypes beanTypes1 = new BeanTypes();
            beanTypes1.Name = "Afrika";
            customerHandler.AddNewBeanType(beanTypes1);

            BeanTypes beanTypes2 = new BeanTypes();
            beanTypes2.Name = "Sydamerika";
            customerHandler.AddNewBeanType(beanTypes2);

            BeanTypes beanTypes3 = new BeanTypes();
            beanTypes3.Name = "Lättrost";
            customerHandler.AddNewBeanType(beanTypes3);

            BeanTypes beanTypes4 = new BeanTypes();
            beanTypes4.Name = "Mellanrost";
            customerHandler.AddNewBeanType(beanTypes4);

            BeanTypes beanTypes5 = new BeanTypes();
            beanTypes5.Name = "Mörkrost";
            customerHandler.AddNewBeanType(beanTypes5);

        }

        public void AddTestCustomer()
        {
            CustomerHandler customerHandler = new CustomerHandler();
            Customer customer4 = new Customer();

            customer4.FirstName = $"Arvid";
            customer4.Lastname = $"Bönan";
            customer4.Email = $"arvid@hem.se";
            customer4.PhoneNumber = $"031-78045000";
            customer4.CompanyName = $"Bean boy";
            customer4.PreferredContactType = PreferredContactType.Email;
            customerHandler.AddNewCustomer(customer4);

            Customer customer2 = new Customer();
            customer2.FirstName = $"Ida";
            customer2.Lastname = $"Coffie";
            customer2.Email = $"ida@hem.se";
            customer2.PhoneNumber = $"031-8744560";
            customer2.CompanyName = $"Coffie Home";
            customer2.PreferredContactType = PreferredContactType.Email;
            AddTestEvents(customer2);
            customerHandler.AddNewCustomer(customer2);

            customer.FirstName = $"Jens";
            customer.Lastname = $"Kaffeson";
            customer.Email = $"jens@hem.se";
            customer.PhoneNumber = $"08-4870154";
            customer.CompanyName = $"Kaffeson AB";
            customer.PreferredContactType = PreferredContactType.Phone;
            customerHandler.AddNewCustomer(customer);

            Customer customer3 = new Customer();
            customer3.FirstName = $"Anders";
            customer3.Lastname = $"Bsoon";
            customer3.Email = $"anders@hem.se";
            customer3.PhoneNumber = $"08-586 1501";
            customer3.CompanyName = $"Kaffe å Gott";
            customer3.PreferredContactType = PreferredContactType.Letter;
            AddTestEvents(customer3);

            customerHandler.AddNewCustomer(customer3);

        }

        public void AddTestEvents(Customer customer)
        {
            ContactEvent contactEvent = new ContactEvent();

            if (customer.FirstName == "Anders")
            {
                contactEvent.DateTime = DateTime.Now;
                contactEvent.SummaryContent = "Frågade om nästa leverans";
                contactEvent.FullContent = "Kunden frågade när nästa leverans är. Kaffet är nästan slut";
                customer.ContactEvents.Add(contactEvent);

            }
            else if (customer.FirstName == "Ida")
            {
                contactEvent.DateTime = DateTime.Now;
                contactEvent.SummaryContent = "Frågade om order";
                contactEvent.FullContent = "Kunden väntar på sin order och undrar när den kommer";
                customer.ContactEvents.Add(contactEvent);

            }

        }
    }
}
