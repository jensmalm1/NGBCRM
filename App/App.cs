using System;
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
    //todo:Maybe clear console once in a while or use different colors to make information more clear
    class App
    {
        private CustomerHandler customerHandler;
        private UserInterface userInterface;

        public void Run()
        {
            customerHandler = new CustomerHandler();
            userInterface = new ConsoleInterface();


            SalespersonMenu();

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
        //Todo:Salesperson is 2 words => SalesPerson (or change word alltogether)
        public void SalespersonMenu()
        {
            bool quit = true;
            while (quit)
            {
                userInterface.DisplaySalespersonMenu();
                string menuSelection = userInterface.GetMenuSelection();
                switch (menuSelection)
                {
                    //todo: Create a "return to main menu" option?
                    case "1":
                        UpdateContactLogForCustomer();
                        break;
                    //todo: svårt kanske men att kunna söka på endast några bokstäver, typ  söka "and" skulle ge träff "andersson" osv...
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
                    case "q":
                    case "Q":
                        quit = false;
                        break;
                        //todo: can use cw instead of DisplayText since is it only used once.
                    default:
                        userInterface.DisplayText("Ogiltigt val.");
                       // Console.WriteLine("Ogiltigt val.");
                        break;
                }

            }
            
        }

        public void UpdateContactLogForCustomer()
        {
            Customer customer = GetCustomerFromUser();
            customer.ContactEvents.Add(userInterface.CreateContactEvent());
            customerHandler.UpdateCustomer(customer);
        }
    }
}
