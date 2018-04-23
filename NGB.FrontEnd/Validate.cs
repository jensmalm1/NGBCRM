using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NGB.FrontEnd
{
    public enum StringType
    {
        CompanyName,
        PersonName,
        Email,
        PhoneNumber,
        MenuSelection
    }
    public class Validation
    {
        public bool Validate(StringType stringType, string stringToValidate)
        {
            var isValid = false;
            switch (stringType)
            {
                case StringType.CompanyName:
                    isValid = ValidateString(ValidateCompanyName, stringToValidate);
                    break;
                case StringType.PersonName:
                    isValid = ValidateString(ValidatePersonName, stringToValidate);
                    break;
                case StringType.Email:
                    isValid = ValidateString(ValidateEmail, stringToValidate);
                    break;
                case StringType.PhoneNumber:
                    isValid = ValidateString(ValidatePhoneNumber, stringToValidate);
                    break;
                case StringType.MenuSelection:
                    isValid = ValidateString(ValidateMenuSelection, stringToValidate);
                    break;
                default:
                    break;
            }
            return isValid;
        }

        private bool ValidateMenuSelection(string input)
        {
            return Regex.IsMatch(input, @"(^\d+$|[Qq])");
        }


        private bool ValidateString(Func<string, bool> validate, string stringToValidate)
        {
            if (String.IsNullOrEmpty(stringToValidate))
                return false;
            else
                return validate(stringToValidate);
        }
  

        private bool ValidateCompanyName(string input)
        {
                return true;
        }

        private bool ValidatePersonName(string input)
        {
           return Regex.IsMatch(input, @"^[a-zA-ZåäöÅÄÖ]+(([',. -][a-zA-ZåäöÅÄÖ ])?[a-zA-ZåäöÅÄÖ]*)*$");
        }


        private bool ValidatePhoneNumber(string input)
        {
            return Regex.IsMatch(input, @"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$");
        }
        private bool ValidateEmail(string input)
        {
            return Regex.IsMatch(input, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }
    }
}
