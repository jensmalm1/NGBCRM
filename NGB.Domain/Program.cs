using System;

namespace NGB.Domain
{
    public enum PreferedContactType
    {
        Phone,
        EMail,
        Letter
    }
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public PreferedContactType PreferedContactType { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hopp!");
            Console.WriteLine("Gummi");
        }
    }
}
