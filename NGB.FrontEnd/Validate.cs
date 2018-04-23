using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NGB.FrontEnd
{
    public enum StringType
    {
        Epost,
        PhoneNumber
    }
    class Validate
    {
        public bool ValidateWhithType(StringType stringType, string stringToValidate)
        {
            var isValid = false;
            switch (stringType)
            {
                case StringType.Epost:
                    isValid = ValidateEmail(stringToValidate);
                    break;
                case StringType.PhoneNumber:
                    isValid = ValidatePhoneNo(stringToValidate);
                    break;
                default:
                    break;
            }
            return isValid;
        }

        public bool ValidatePhoneNo(string input)
        {
            return Regex.IsMatch(input, @"^\d{2,10}-?\d{1,8}$");
        }
        public bool ValidateEmail(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;
            else
            {
                return Regex.IsMatch(input, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            }

            
        }
    }
}
