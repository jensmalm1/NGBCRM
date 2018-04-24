﻿using System.Collections.Generic;

namespace NGB.Domain
{
    public class Customer
    {
        public List<ContactEvent> ContactEvents { get; set; } = new List<ContactEvent>();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public PreferedContactType PreferedContactType { get; set; }
    }


    public enum PreferedContactType
    {
        //Todo: in english when choosing how to be contacted, rest is in swedish
        Phone,
        Email,
        Letter
    }


    public enum SearchableCustomerAttribute
    {
        CompanyName,
        FirstName,
        LastName
    }
}