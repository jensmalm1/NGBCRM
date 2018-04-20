namespace NGB.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public PreferedContactType PreferedContactType { get; set; }
    }

    public enum PreferedContactType
    {
        Phone,
        EMail,
        Letter
    }
}