using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            var customers = new List<Customer>{customer};
            DisplayCustomerList(customers);
        }

        public void DisplayCustomerContactLog(Customer customer)
        {
            Console.WriteLine($"Kontaktlogg för {customer.CompanyName}");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"{"Nummer",-10}{"Datum",-25}{"Rubrik",-40}");
            var count = 1;
            foreach (var contaktEvent in customer.ContactEvents)
            {
                Console.WriteLine($"{count,-10}{contaktEvent.DateTime,-25}{contaktEvent.SummaryContent,-40}");
                Console.WriteLine();
                Console.WriteLine($"{contaktEvent.FullContent}");
                count++;
            }
            Console.WriteLine("--------------------------------------------------------------------------");


        }

        public void DisplayCustomerList(List<Customer> customerList)
        {
            Console.WriteLine("Kundlista");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"{"Nummer", -10}{"Företag",-20}{"Kontaktperson", -20}{"Epost", -20}{"Telefonnummer", -20}");
            var count = 1;
            foreach (var customer in customerList)
            {
                Console.WriteLine($"{count, -10}{customer.CompanyName,-20}{customer.FirstName+ " "+customer.Lastname, -20}{customer.Email, -20}{customer.PhoneNumber, -20}");
                count++;
            }
            Console.WriteLine("--------------------------------------------------------------------------");

        }
        public SearchableCustomerAttribute GetCustomerSearchAttributeFromUser()
        {
            while (true)
            {
                Console.WriteLine($"Sökbara uppgifter\n1.Företagsnamn\n2.Förnamn\n3.Efternamn");
                var number = GetInput("Ange sökuppgift: ", StringType.MenuSelection);
            
                if (number == "1")
                {
                    return SearchableCustomerAttribute.CompanyName;
                }
                if (number == "2")
                {
                    return SearchableCustomerAttribute.FirstName;
                }
                if (number == "3")
                {
                    return SearchableCustomerAttribute.LastName;
                }
            }
        }
        public Customer SelectCustomer(List<Customer> customerList)
        {
            var number = GetInput("Välj ett nummer: ",StringType.MenuSelection);
            return customerList[Convert.ToInt32(number)-1];
            
        }
        public Customer GetNewCustomerFromUser()
        {
            var customer = new Customer();
            customer.FirstName = GetInput("Skriv förnamn: ", StringType.PersonName);
            customer.Lastname = GetInput("Skriv efternamn: ", StringType.PersonName);
            customer.Email = GetInput("Skriv epostadress: ", StringType.Email);
            customer.PhoneNumber = GetInput("Ange telefonnummer: ", StringType.PhoneNumber);
            customer.CompanyName = GetInput("Skriv in företagsnamn: ", StringType.CompanyName);

            customer.PreferredContactType = GetPreferredContactType();
            return customer;
        }

        public string GetInput(string question, StringType stringType)
        {
            string inputLine;
            while (true)
            {
                Console.Write(question);
                inputLine = Console.ReadLine().Trim();
                if (validation.Validate(stringType, inputLine))
                    break;
                Console.WriteLine("Fel format");
            }
            return inputLine;
        }

        public string GetInput(SearchableCustomerAttribute attribute)
        {
            switch (attribute)
            {
                case SearchableCustomerAttribute.CompanyName:
                    return GetInput("Ange företagsnamn: ", StringType.CompanyName);
                case SearchableCustomerAttribute.FirstName:
                    return GetInput("Ange förnamn: ", StringType.PersonName);
                case SearchableCustomerAttribute.LastName:
                    return GetInput("Ange efternamn: ", StringType.PersonName);
            }

            return "";
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
                Console.WriteLine($"({i+1}) {contactNames[i]}");
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
            Console.Write("Beskriv kontakthändelsen: ");
            contactEvent.FullContent = Console.ReadLine();
            contactEvent.DateTime = GetTimeFromUser();
            return contactEvent;
        }

        private DateTime GetTimeFromUser()
        {
            var dateInput = GetInput($"Ange datum (ÅÅÅÅ-MM-DD): ", StringType.Date);
            var timeInput = GetInput($"Ange tid (TT:MM): ", StringType.Time);
            return validation.CreateDateTime(dateInput, timeInput);
        }

        public void DisplaySalesPersonMenu()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Säljmeny");
            Console.WriteLine("(1) Uppdatera kontaktlogg för kund.");
            Console.WriteLine("(2) Sök kund.");
            Console.WriteLine("(3) Visa alla kunder.");
            Console.WriteLine("(4) Visa kontaktloggen för en kund.");
            Console.WriteLine("(5) Lägg till ny kund.");
            Console.WriteLine("-----------------------------------------------------");
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

        public void DisplayInvalidChoice()
        {
            Console.WriteLine("Ogiltigt val.");
        }
    }
}

