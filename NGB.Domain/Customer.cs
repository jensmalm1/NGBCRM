﻿namespace NGB.Domain
{
    public class Customer
    {
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
        Phone,
        Email,
        Letter
    }
}