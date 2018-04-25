using System.Collections.Generic;

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
        public PreferredContactType PreferredContactType { get; set; }
    }


    public enum PreferredContactType
    {
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