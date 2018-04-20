namespace NGB.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
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