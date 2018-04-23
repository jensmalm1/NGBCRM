using System;
using System.Collections.Generic;
using System.Text;
using NGB.FrontEnd;
using NGB.Domain;
using Remotion.Linq.Clauses;

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

<<<<<<< HEAD
        public void UpdateContactLogForCustomer()
=======
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
=======
        public Customer UpdateContactLogForCustomer()
>>>>>>> 36d2052778b63a45ca081f8c3b687c330651aaa7
        {


           Customer customer= GetCustomerFromUser();
           var contactEvent=userInterface.CreateContactEvent();
            customer.ContactEvents.Add(contactEvent);
            //merge these later...
            customerHandler.UpdateCustomer(customer);

>>>>>>> 4cd4fe94439954bb509336f07ae0f9cbd8ec9c62
        }
    }
}
