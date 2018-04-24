﻿using System;
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

        public void AddTestCustomer()
        {
            CustomerHandler customerHandler = new CustomerHandler();
            Customer customer = new Customer();

            customer.FirstName = $"Arvid";
            customer.Lastname = $"Bönan";
            customer.Email = $"arvid@hem.se";
            customer.PhoneNumber = $"031-78045000";
            customer.CompanyName = $"Bean boy";
            customer.PreferedContactType = PreferedContactType.Email;
            customerHandler.AddNewCustomer(customer);

            customer.FirstName = $"Ida";
            customer.Lastname = $"Coffie";
            customer.Email = $"ida@hem.se";
            customer.PhoneNumber = $"031-8744560";
            customer.CompanyName = $"Coffie Home";
            customer.PreferedContactType = PreferedContactType.Email;
            AddTestEvents(customer);
            customerHandler.AddNewCustomer(customer);

            customer.FirstName = $"Jens";
            customer.Lastname = $"Kaffeson";
            customer.Email = $"jens@hem.se";
            customer.PhoneNumber = $"08-4870154";
            customer.CompanyName = $"Kaffeson AB";
            customer.PreferedContactType = PreferedContactType.Phone;
            customerHandler.AddNewCustomer(customer);

            customer.FirstName = $"Anders";
            customer.Lastname = $"Bsoon";
            customer.Email = $"anders@hem.se";
            customer.PhoneNumber = $"08-586 1501";
            customer.CompanyName = $"Kaffe å Gott";
            customer.PreferedContactType = PreferedContactType.Letter;
            AddTestEvents(customer);

            customerHandler.AddNewCustomer(customer);

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