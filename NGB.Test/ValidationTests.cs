using System.ComponentModel;
using NUnit.Framework;

namespace NGB.Test
{
    [TestFixture]
    public class ValidationTests
    {
        private string goodEmail1 = "anna@gmail.com";
        private string goodEmail2 = "lisa.svensson@gmail.com";
        private string goodEmail3 = "nisse79@hotmail.com";
        private string goodEmail4 = "SEBastIAN@TELia.sE";
        private string goodEmail5 = "bob!#$%&'*+-/=?^_`{|}~;@mofidunt.gov";
        private string goodEmail6 = "cecilia@multiple.domain.hosts.uk";
        private string goodEmail7 = "adnan.felix.theresa@gmail.com";
        private string goodEmail8 = "tybalt_capulet@verona.it";

        private string badEmail1 = "anna@gmail.";
        private string badEmail2 = "@gmail.com";
        private string badEmail3 = "lisa@.com";
        private string badEmail4 = "nisse.@asdf.com";
        private string badEmail5 = "felixia@-gmail.com";
        private string badEmail6 = ".@epost.nu";
        private string badEmail7 = "mohammed..alhadim@aljazira.uae";
        private string badEMail8 = "elin.gmail.com";







        [Test]
        public void EmailValidationTest()
        {
           
            
        }
        
    }
}