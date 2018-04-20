using System;
using System.Collections.Generic;
using System.Text;
using NGB.FrontEnd;
using NGB.Domain;

namespace NGB.App
{
    class App
    {
        public void Run()
        {
            UserInterface userInterface = new ConsoleInterface();
            var handler = new CustomerHandler();

            Customer customer = userInterface.GetNewCustomerFromUser();
            handler.AddNewCustomer(customer);

        }
    }
}
