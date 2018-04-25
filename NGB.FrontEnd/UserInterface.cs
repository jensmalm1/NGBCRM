using System;
using System.Collections.Generic;
using NGB.Domain;

namespace NGB.FrontEnd
{
    public interface UserInterface
    {
        Customer GetNewCustomerFromUser();
        SearchableCustomerAttribute GetCustomerSearchAttributeFromUser();
        string GetInput(string question, StringType type);
        string GetInput(SearchableCustomerAttribute attribute);
        void DisplayCustomerList(List<Customer> customerList);
        Customer SelectCustomer(List<Customer> customerList);
        void DisplayCustomer(Customer customer);
        void DisplaySalesPersonMenu();
        string GetMenuSelection();
        ContactEvent CreateContactEvent(Customer customer);

        void DisplayCustomerContactLog(Customer customer);
        void DisplayInvalidChoice();
        void DisplayPreferredBeanTypes(Customer customer);
    }

}
