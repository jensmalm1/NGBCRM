﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using NGB.Data;
using NGB.FrontEnd;
using NGB.Domain;
using Remotion.Linq.Clauses;
using NGB.Data;

namespace NGB.App
{
    class App
    {
        private CustomerHandler customerHandler;
        private UserInterface userInterface;

        public void Run()
        {
            customerHandler = new CustomerHandler();
            userInterface = new ConsoleInterface();

            SalesPersonMenu();
        }

        public Customer GetCustomerFromUser()
        {
            var customerList = new List<Customer>();
            while (true)
            {
                SearchableCustomerAttribute customerSearchMethod = userInterface.GetCustomerSearchAttributeFromUser();
                var searchString = userInterface.GetInput(customerSearchMethod);
                switch (customerSearchMethod)
                {
                    case SearchableCustomerAttribute.CompanyName:
                        customerList = customerHandler.FindCustomersByCompanyName(searchString);
                        break;
                    case SearchableCustomerAttribute.FirstName:
                        customerList = customerHandler.FindCustomerByFirstName(searchString);
                        break;
                    case SearchableCustomerAttribute.LastName:
                        customerList = customerHandler.FindCustomerByLastName(searchString);
                        break;
                }

                if (customerList.Count > 0)
                    break;
                Console.WriteLine("Hittade inga kunder. Försök igen! ");
            }

            if (customerList.Count == 1)
                return customerList[0];
            userInterface.DisplayCustomerList(customerList);
            return userInterface.SelectCustomer(customerList);
        }

        public void SalesPersonMenu()
        {
            bool continueInMenu = true;
            while (continueInMenu)
            {
                userInterface.DisplaySalesPersonMenu();
                string menuSelection = userInterface.GetMenuSelection();
                switch (menuSelection)
                {
                    case "1":
                        Customer customerToUpdate = GetCustomerFromUser();
                        customerToUpdate.ContactEvents.Add(userInterface.CreateContactEvent(customerToUpdate));
                        customerHandler.UpdateCustomer(customerToUpdate);
                        break;
                    case "2":
                        userInterface.DisplayCustomer(GetCustomerFromUser());
                        break;
                    case "3":
                        userInterface.DisplayCustomerList(customerHandler.ListAllCustomers());
                        break;
                    case "4":
                        var customer = GetCustomerFromUser();
                        userInterface.DisplayCustomerContactLog(customer);
                        break;
                    case "5":
                        customerHandler.AddNewCustomer(userInterface.GetNewCustomerFromUser());
                        break;
                    case "6":
                        userInterface.DisplayPreferredBeanTypes(GetCustomerFromUser());
                        break;

                    case "q":
                    case "Q":
                        continueInMenu = false;
                        break;
                    default:
                        userInterface.DisplayInvalidChoice();
                        break;
                }

            }
            
        }

        public void UpdateContactLogForCustomer()
        {

        }
    }
}
