using movies;
using NUnit.Framework;
using System;

namespace ValidatorTesting
{
    // NuGets below needed to be installed:
    //      nunit 3
    //      nunit 3 testadapter
    //      microsoft testing sdk

    [TestFixture]
    public class ValidatorTests
    {
        [TestCase(1993)]
        [TestCase(1994)]
        [TestCase(1995)]
        [TestCase(2022)]
        public void ValidValueTest(int yearOfRelease)
        {
            Movie m = new Movie();
            m.YearOfRelease = yearOfRelease;

            Assert.That(Validator.IsValid(nameof(m.YearOfRelease), m), Is.True);
            // or alternatively:
            // Assert.That(Validator.IsValid("YearOfRelease", m), Is.True);
        }

        [TestCase(1990)]
        [TestCase(1991)]
        [TestCase(1992)]
        [TestCase(1888)]
        public void InvalidValueTest(int yearOfRelease)
        {
            Movie m = new Movie();
            m.YearOfRelease = yearOfRelease;

            Assert.That(Validator.IsValid(nameof(m.YearOfRelease), m), Is.False);
        }

        [Test]
        public void MissingAttributeTest()
        {
            Movie m = new Movie();
            DemoClass dc = new DemoClass();

            Assert.Throws(typeof(ArgumentException), () => Validator.IsValid(nameof(m.Id), m));

            Assert.Throws(typeof(ArgumentException), () => Validator.IsValid(nameof(dc.Prop), dc));
        }
    }

    public class DemoClass
    {
        public int Prop { get; set; }
    }
}
