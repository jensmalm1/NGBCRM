﻿using System;
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
    }

}
