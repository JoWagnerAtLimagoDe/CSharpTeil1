using NUnit.Framework;
using Bundesbank.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bundesbank.Collections.Tests
{
    [TestFixture()]
    public class StapelTests
    {
      public Stapel objectUnderTest { get; set; }

       [SetUp]
       public void SetUp()
        {
            objectUnderTest = new Stapel();
        }

        [Test]
      public void IsEmpty_EmptyStack_returnsTrue() {
            // Arrange
          

            // Action
            bool ergebnis = objectUnderTest.IsEmpty;

            // Assertion
            Assert.IsTrue(ergebnis);
      }

        [Test]
        public void IsEmpty_NotEmptyStack_returnsFalse()
        {
            // Arrange

            objectUnderTest.Push(new object());

            // Action
            bool ergebnis = objectUnderTest.IsEmpty;

            // Assertion
            Assert.IsFalse(ergebnis);
        }

    }
}