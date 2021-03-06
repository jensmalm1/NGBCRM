﻿using System;
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
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Nummer", -10}{"Företag",-20}{"Kontaktperson", -20}{"Epost", -20}{"Telefonnummer", -20}{"Antalet händelser med kund",-20}");
            var count = 1;
            foreach (var customer in customerList)
            {
                Console.WriteLine($"{count, -10}{customer.CompanyName,-20}{customer.FirstName+ " "+customer.Lastname, -20}{customer.Email, -20}{customer.PhoneNumber, -20}{customer.ContactEvents.Count}");
                count++;
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
            
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
            Console.ForegroundColor = ConsoleColor.White;
            var number = GetInput("Välj ett nummer: ",StringType.MenuSelection);
            Console.ResetColor();

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
            }Console.Clear();
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

        private PreferredContactType GetPreferredContactType()
        {
            Console.WriteLine("Kontakttyp");
            var values = Enum.GetValues(typeof(PreferredContactType));
            string[] contactNames = new string[values.Length];
            for (int i = 0; i < contactNames.Length; i++)
            {
                contactNames[i] = ((PreferredContactType)i).ToString();
            }

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"({i+1}) {contactNames[i]}");
            }
            Console.Write("Ange önskad kontakttyp: ");
            int answer = Convert.ToInt32(Console.ReadLine()) - 1;
            return (PreferredContactType)Enum.ToObject(typeof(PreferredContactType), answer);

        }


        public ContactEvent CreateContactEvent(Customer customer)
        {
            Console.WriteLine();
            var contactEvent = new ContactEvent();
            Console.WriteLine($"Kund: {customer.CompanyName}");
            Console.Write("Ange rubrik för kontakthändelse: ");
            contactEvent.SummaryContent = Console.ReadLine();
            Console.Write("Beskriv kontakthändelsen: ");
            contactEvent.FullContent = Console.ReadLine();
            contactEvent.DateTime = GetTimeFromUser();
            Console.WriteLine();
            return contactEvent;
            
        }

        private DateTime GetTimeFromUser()
        {
            var dateInput = GetInput($"Ange datum (ÅÅÅÅ-MM-DD): ", StringType.Date);
            var timeInput = GetInput($"Ange tid (TT:MM): ", StringType.Time);
            return validation.CreateDateTime(dateInput, timeInput);
        }

        private void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("      _   __          __     ______                           __  _  \r\n     / | / /__  _  __/ /_   / ____/__  ____  ___  _________ _/ /_(_)___  ____ \r\n    /  |/ / _ \\| |/_/ __/  / / __/ _ \\/ __ \\/ _ \\/ ___/ __ `/ __/ / __ \\/ __ \\\r\n   / /|  /  __/>  </ /_   / /_/ /  __/ / / /  __/ /  / /_/ / /_/ / /_/ / / / /\r\n  /_/ |_/\\___/_/|_|\\__/   \\____/\\___/_/ /_/\\___/_/   \\__,_/\\__/_/\\____/_/ /_/ \r\n                                                                              \r\n                            ____  _   _                 \r\n                           / __ )(_)_(_)___  ____ _____ \r\n                          / __  / __ \\/ __ \\/ __ `/ __ \\\r\n                         / /_/ / /_/ / / / / /_/ / / / /\r\n                        /_____/\\____/_/ /_/\\__,_/_/ /_/ \r\n                                                        ");
            Console.ResetColor();
        }

        public void DisplaySalesPersonMenu()
        {
            DisplayLogo();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Säljmeny");
            Console.ResetColor();
            Console.WriteLine("(1) Uppdatera kontaktlogg för kund.");
            Console.WriteLine("(2) Sök kund.");
            Console.WriteLine("(3) Visa alla kunder.");
            Console.WriteLine("(4) Visa kontaktloggen för en kund.");
            Console.WriteLine("(5) Lägg till ny kund.");
            Console.WriteLine("(6) Visa favoritböna för kund");
            Console.WriteLine("-----------------------------------------------------");
        }


        public string GetMenuSelection()
        {
            while (true)
            { 
                Console.Write("Gör menyval (Q för att avbryta): ");
                var input = Console.ReadLine();

                if (validation.Validate(StringType.MenuSelection, input))
                {
                    Console.Clear();
                    return input;
                }
            } 
        }

        public void DisplayInvalidChoice()
        {
            Console.WriteLine("Ogiltigt val.");
        }

        public void DisplayPreferredBeanTypes(Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine($"Kund: {customer.CompanyName}");
            Console.WriteLine("Föredrar följande bönor: ");
            foreach (var BeanTypePreference in customer.BeanTypePreferenceses)
            {
                Console.WriteLine(BeanTypePreference.BeanTypes.Name);
            }

            Console.WriteLine();
        }
    }
}

