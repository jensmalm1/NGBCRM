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
        PhoneNumber
    }
    class Validate
    {
        public bool ValidateWhithType(StringType stringType, string stringToValidate)
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
                default:
                    break;
            }
            return isValid;
        }

        
        public bool ValidateString(Func<string, bool> validate, string stringToValidate)
        {
            if (String.IsNullOrEmpty(stringToValidate))
                return false;
            else
                return validate(stringToValidate);
        }
  

        public bool ValidateCompanyName(string input)
        {
                return true;
        }

        public bool ValidatePersonName(string input)
        {
           return Regex.IsMatch(input, @"^[a-zA-ZåäöÅÄÖ]+(([',. -][a-zA-ZåäöÅÄÖ ])?[a-zA-ZåäöÅÄÖ]*)*$");
        }


        public bool ValidatePhoneNumber(string input)
        {
            return Regex.IsMatch(input, @"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$");
        }
        public bool ValidateEmail(string input)
        {
            return Regex.IsMatch(input, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        }
    }
}
