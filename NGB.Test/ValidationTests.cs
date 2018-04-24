using System.ComponentModel;
using NUnit.Framework;
using NGB.FrontEnd;

namespace NGB.Test
{
    [TestFixture]
    public class ValidationTests
    {
        private string goodEmail1 = "anna@gmail.com";
        private string goodEmail2 = "lisa.svensson@gmail.com";
        private string goodEmail3 = "nisse79@hotmail.com";
        private string goodEmail4 = "SEBastIAN@TELia.sE";
        private string goodEmail5 = "bob-!#$%&@mofidunt.gov";
        private string goodEmail6 = "cecilia@multiple.domain.hosts.uk";
        private string goodEmail7 = "adnan.felix.theresa@gmail.com";
        private string goodEmail8 = "tybalt_capulet@verona.it";

        private string badEmail1 = "anna@gmail-";
        private string badEmail2 = "@gmail.com";
        private string badEmail3 = "lisa@.com";
        private string badEmail4 = "nisse.@asdf.com";
        private string badEmail5 = "felixia@-gmail.com";
        private string badEmail6 = ".@epost.nu";
        private string badEmail7 = "mohammed..alhadim@aljazira.uae";
        private string badEmail8 = "elin.gmail.com";



        [Test]
        public void GoodEmailValidationTest()
        {
            var v = new Validation();
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail1)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail2)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail3)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail4)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail5)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail6)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail7)));
            Assert.That(true, Is.EqualTo(v.Validate(StringType.Email, goodEmail8)));
        }

        [Test]
        public void BadEmailValidationTest()
        {
            var v = new Validation();
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail1)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail2)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail3)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail4)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail5)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail6)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail7)));
            Assert.That(false, Is.EqualTo(v.Validate(StringType.Email, badEmail8)));
        }
    }
}