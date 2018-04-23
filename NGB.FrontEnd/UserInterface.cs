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
<<<<<<< HEAD
        ContactEvent CreateContactEvent();

=======
        void DisplayCustomer(Customer customer);
>>>>>>> 36d2052778b63a45ca081f8c3b687c330651aaa7
    }

}
