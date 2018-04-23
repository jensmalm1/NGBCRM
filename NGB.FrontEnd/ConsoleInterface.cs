using System;
using System.Collections.Generic;
using System.Text;
using NGB.Domain;
using NGB.FrontEnd;

namespace NGB.FrontEnd
{

    public class ConsoleInterface : UserInterface
    {
        Validation validation = new Validation();

        public void DisplayCustomer(Customer customer)
        {
            var customers = new List<Customer>();
            DisplayCustomerList(customers);
        }

        public void DisplayCustomerList(List<Customer> customerList)
        {
            Console.WriteLine("Kundlista");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"{"Företag",-20}{"Kontaktperson", -20}{"Epost", -20}{"Telefonnummer", -20}");
            foreach (var customer in customerList)
            {
                Console.WriteLine($"{customer.CompanyName,-20}{customer.FirstName+ " "+customer.Lastname, -20}{customer.Email, -20}{customer.PhoneNumber, -20}");
            }
            Console.WriteLine("--------------------------------------------------------------------------");

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
            var validate = new Validation();

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


        public ContactEvent CreateContactEvent()
        {
            var contactEvent = new ContactEvent();
            Console.Write("Ange rubrik för kontakthändelse: ");
            contactEvent.SummaryContent = Console.ReadLine();
            Console.Write("Beskriv kontakten: ");
            contactEvent.FullContent = Console.ReadLine();
            contactEvent.DateTime = DateTime.Now;
            return contactEvent;
        }

        public void DisplaySalespersonMenu()
        {
            Console.WriteLine("Säljmeny");
            Console.WriteLine("(1) Uppdatera kontaktlogg för kund.");
            Console.WriteLine("(2) Sök kund.");
            Console.WriteLine("(3) Visa alla kunder.");
            Console.WriteLine("(4) Lägg till ny kund.");
        }

        public string GetMenuSelection()
        {
            while (true)
            {
                Console.Write("Gör menyval (Q för att avbryta): ");
                var input = Console.ReadLine();
                if (validation.Validate(StringType.MenuSelection, input))
                    return input;
            }
        }
    }
}
