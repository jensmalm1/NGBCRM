﻿using System;
using System.Collections.Generic;
using System.Text;
using NGB.Domain;

namespace NGB.FrontEnd
{
    public class ConsoleInterface : UserInterface
    {

        public Customer GetNewCustomerFromUser()
        {
            var customer = new Customer();
            Console.Write("Skriv förnamn: ");
            customer.FirstName = Console.ReadLine();
            Console.Write("Skriv efternamn: ");
            customer.Surname = Console.ReadLine();
            Console.Write("Skriv epostadress: ");
            customer.Email = Console.ReadLine();
            Console.Write("Ange telefonnummer: ");
            customer.PhoneNumber = Console.ReadLine();
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