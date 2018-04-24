using System;
using System.Collections.Generic;
using NGB.Domain;

namespace NGB.FrontEnd
{
    public interface UserInterface
    {
        Customer GetNewCustomerFromUser();
        SearchableCustomerAttribute GetCustomerSearchAttributeFromUser();
        string GetCompanyNameFromUser();
        void DisplayCustomerList(List<Customer> customerList);
        Customer SelectCustomer(List<Customer> customerList);
        void DisplayCustomer(Customer customer);
        void DisplaySalespersonMenu();
        string GetMenuSelection();
        ContactEvent CreateContactEvent();
        string GetFirstNameFromUser();


        void DisplayText(string text);
    }

}
