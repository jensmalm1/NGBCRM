using System;
using System.Collections.Generic;
using System.Text;
using NGB.Domain;

namespace NGB.FrontEnd
{
    public class ConsoleInterface : UserInterface
    {
        public ContactEvent CreateNewContactEvent()
        {

            var contactEvent=new ContactEvent();
            Console.WriteLine("Vilken kund vill du skapa kontaktlog för? Ange Efternamn");
            return = Console.ReadLine();
            
            

        }

        public void DisplayCustomerList(List<Customer> customerList)
        {
            Console.WriteLine("Kundlista");
            foreach (var customer in customerList)
            {
                Console.WriteLine(@$"{customer.CompanyName,-10} {customer.FirstName, -10} {customer.Lastname} {customer.Email, -10} {customer.PhoneNumber, -10}");
            }
        }

        public SearchableCustomerAttribute GetCustomerSearchAttributeFromUser()
        {
            throw new NotImplementedException();
        }

        public string GetCompanyNameFromUser()
        {
            throw new NotImplementedException();
        }

        public Customer SelectCustomer(List<Customer> customerList)
        {
            throw new NotImplementedException();
        }
        public Customer GetNewCustomerFromUser()
        {
            var customer = new Customer();
            Console.Write("Skriv förnamn: ");
            customer.FirstName = Console.ReadLine();
            Console.Write("Skriv efternamn: ");
            customer.Lastname = Console.ReadLine();
            Console.Write("Skriv epostadress: ");
            customer.Email = Console.ReadLine();
            Console.Write("Ange telefonnummer: ");
            customer.PhoneNumber = Console.ReadLine();
            Console.Write("Skriv in företagsnamn");
            customer.CompanyName = Console.ReadLine();
            customer.PreferedContactType = GetPreferredContactType();
            return customer;
        }

        private PreferedContactType GetPreferredContactType()
        {
            Console.WriteLine("Kontakttyp");
            var values = Enum.GetValues(typeof(PreferedContactType));
            string[] contactNames = new string[values.Length];
            for (int i = 0; i < contactNames.Length; i++)
            {
                contactNames[i] = ((PreferedContactType)i).ToString();
            }

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"({i+1} {contactNames[i]}");
            }
            Console.Write("Ange önskad kontakttyp: ");
            int answer = Convert.ToInt32(Console.ReadLine()) - 1;
            return (PreferedContactType)Enum.ToObject(typeof(PreferedContactType), answer);

        }
    }
}
