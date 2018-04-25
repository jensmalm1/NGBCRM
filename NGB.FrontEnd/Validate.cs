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
        MenuSelection,
        Date,
        Time
    }
    public class Validation
    {
        public bool Validate(StringType stringType, string stringToValidate)
        {
            var isValid = false;
            if (CheckIfStringIsNullOrEmpty(stringToValidate))
                return false;
            else
            {
                switch (stringType)
                {
                    case StringType.CompanyName:
                        isValid = ValidateCompanyName(stringToValidate);
                        break;
                    case StringType.PersonName:
                        isValid = ValidatePersonName (stringToValidate);
                        break;
                    case StringType.Email:
                        isValid = ValidateEmail (stringToValidate);
                        break;
                    case StringType.PhoneNumber:
                        isValid = ValidatePhoneNumber (stringToValidate);
                        break;
                    case StringType.MenuSelection:
                        isValid = ValidateMenuSelection (stringToValidate);
                        break;
                    case StringType.Date:
                        isValid = ValidateDate (stringToValidate);
                        break;
                    case StringType.Time:
                        isValid = ValidateTime (stringToValidate);
                        break;
                    default:
                        break;
                }
            }
            return isValid;
        }

        private bool ValidateDate(string input)
        {
            try
            {
                CreateDateTime(input, null);
            }
            catch (ArgumentException e)
            {
                return false;
            }

            return true;
        }
        private bool ValidateTime(string input)
        {
            try
            {
                CreateDateTime(null, input);
            }
            catch (ArgumentException e)
            {
                return false;
            }

            return true;
        }

        private bool ValidateMenuSelection(string input)
        {
            return Regex.IsMatch(input, @"(^\d+$|[Qq])");
        }

        //Todo: Rename method to CheckIfStringIsNullOrEmpty.

        private bool CheckIfStringIsNullOrEmpty(string stringToValidate)
        {
            if (String.IsNullOrEmpty(stringToValidate))
                return true;
            else
                return false;
        }

        //private bool ValidateString(Func<string, bool> validate, string stringToValidate)
        //{
        //    if (String.IsNullOrEmpty(stringToValidate))
        //        return false;
        //    else
        //        return validate(stringToValidate);
        //}
  

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
            try
            {
                var addr = new System.Net.Mail.MailAddress(input);
                return addr.Address == input;
            }
            catch
            {
                return false;
            }
        }

        //public bool ValidateAttribute(StringType stringType, string stringToValidate)
        //{
        //    var isValid = false;
        //    switch (stringType)
        //    {
        //        case StringType.CompanyName:
        //            isValid = ValidateString(ValidateCompanyName, stringToValidate);
        //            break;
        //        case StringType.PersonName:
        //            isValid = ValidateString(ValidatePersonName, stringToValidate);
        //            break;
        //        case StringType.Email:
        //            isValid = ValidateString(ValidateEmail, stringToValidate);
        //            break;
        //        case StringType.PhoneNumber:
        //            isValid = ValidateString(ValidatePhoneNumber, stringToValidate);
        //            break;
        //        case StringType.MenuSelection:
        //            isValid = ValidateString(ValidateMenuSelection, stringToValidate);
        //            break;
        //        default:
        //            break;
        //    }
        //    return isValid;
        //}

        public DateTime CreateDateTime(string dateInput, string timeInput)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            try
            {
                if (dateInput != null)
                {
                    var dateArray = dateInput.Split('-');
                    year = Convert.ToInt32(dateArray[0]);
                    month = Convert.ToInt32(dateArray[1]);
                    day = Convert.ToInt32(dateArray[2]);
                }

                if (timeInput != null)
                {
                    var timeArray = timeInput.Split(':');
                    hour = Convert.ToInt32(timeArray[0]);
                    minute = Convert.ToInt32(timeArray[1]);
                }

                return new DateTime(year, month, day, hour, minute, 0);
            }
            catch
            {
                throw new ArgumentException();
            }
        }
        //return Regex.IsMatch(input, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zåäöA-ZÅÄÖ]((\.(?!\.))|[-!#\$%&'\*\+\/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zåäöA-ZÅÄÖ])@))" +
        //@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-0-9a-zA-Z]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$");



    }

}
