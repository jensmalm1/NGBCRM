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
            
            Customer customer = userInterface.GetNewCustomerFromUser();
            customerHandler.AddNewCustomer(customer);

        }

        public void GetCustomerFromUser()
        {
            var customerSearchMethod = userInterface.GetCustomerSearchMethodFromUser();
            switch (customerSearchMethod)
            {
                case CompanyName:
                    var companyName = userInterface.GetCompanyNameFromUser();
                    var customerList = customerHandler.FindCustomersByCompanyName(companyName);
                    userInterface.DisplayCustomerList(customerList);
                    return userInterface.SelectCustomer(customerList);
            }

        }
    }
}
