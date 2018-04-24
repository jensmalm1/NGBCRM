using System;
using System.Collections.Generic;
using System.Text;
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

            while (true)
            {
                SalespersonMenu();
            }
        }

        public Customer GetCustomerFromUser()
        {
            SearchableCustomerAttribute customerSearchMethod = userInterface.GetCustomerSearchAttributeFromUser();
            switch (customerSearchMethod)
            {
                case SearchableCustomerAttribute.CompanyName:
                    var companyName = userInterface.GetCompanyNameFromUser();
                    var customerList = customerHandler.FindCustomersByCompanyName(companyName);
                    userInterface.DisplayCustomerList(customerList);
                    return userInterface.SelectCustomer(customerList);
            }

            return null;

        }

        public void SalespersonMenu()
        {
            userInterface.DisplaySalespersonMenu();
            string menuSelection = userInterface.GetMenuSelection();
            switch (menuSelection)
            {
                case "1":
                    UpdateContactLogForCustomer();
                    break;
                case "2":
                    userInterface.DisplayCustomer(GetCustomerFromUser());
                    break;
                case "3":
                    userInterface.DisplayCustomerList(customerHandler.ListAllCustomers());
                    break;
                case "4":
                    customerHandler.AddNewCustomer(userInterface.GetNewCustomerFromUser());
                    break;
            }
        }

        public void UpdateContactLogForCustomer()
        {
            Customer customer= GetCustomerFromUser();
            customer.ContactEvents.Add(userInterface.CreateContactEvent());
            customerHandler.UpdateCustomer(customer);
        }
    }
}
