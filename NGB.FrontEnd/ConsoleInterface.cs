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
            Console.WriteLine($"Välj söktyp\n1.Företagsnamn\n2.Förnamn\n3.Efternamn");
            var number = int.Parse(Console.ReadLine());
            
            SearchableCustomerAttribute attribute;
            
            if (number==1)
            {
                attribute = SearchableCustomerAttribute.CompanyName;
            }
            else if (number == 2)
            {
                attribute = SearchableCustomerAttribute.FirstName;
            }
            else if(number == 3)
            {
                attribute = SearchableCustomerAttribute.LastName;
            }

            return attribute;
        }

        public string GetCompanyNameFromUser()
        {
            throw new NotImplementedException();
        }
        public string GetFirstNameFromUser()
        {
            Console.WriteLine("Var vänlig att ange ett förnamn");
            return Console.ReadLine();
        }

        public Customer SelectCustomer(List<Customer> customerList)
        {
            Console.WriteLine("Välj ett nummer");
            var number = Int32.Parse(Console.ReadLine());
            return customerList[number-1];
            
        }
        public Customer GetNewCustomerFromUser()
        {
            var customer = new Customer();

            customer.FirstName = ValidateInput("Skriv förnamn: ", StringType.PersonName);
            customer.Lastname = ValidateInput("Skriv efternamn: ", StringType.PersonName);
            customer.Email = ValidateInput("Skriv epostadress: ", StringType.Email);
            customer.PhoneNumber = ValidateInput("Ange telefonnummer ", StringType.PhoneNumber);
            customer.CompanyName = ValidateInput("Skriv in företagsnamn: ", StringType.CompanyName);
            
            customer.PreferedContactType = GetPreferredContactType();
           return customer;
        }

        public string ValidateInput(string question, StringType stringType)
        {
            string inputLine;
            while (true)
            {
                Console.Write(question);
                inputLine = Console.ReadLine();
                if (validation.Validate(stringType, inputLine))
                    break;
                else
                {
                    Console.WriteLine("Fel format");
                    continue;
                }
            }
            return inputLine;
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

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
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
