using NUnit.Framework;
using Bundesbank.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using Tag1_02StapelMitNUnit;

namespace Bundesbank.Collections.Tests
{
    [TestFixture()]
    public class StapelTests
    {
      private Stapel objectUnderTest { get; set; }

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

        [Test]
        public void Push_HappyDay_Success()
        {
            // Arrange
            object v = new Object();


            // Action
            objectUnderTest.Push(v);

            //  Assertion
            Assert.AreSame(v, objectUnderTest.Pop());

        }

        [Test]
        public void Push_FillUpToLimit_noExceptionIsThrown()
        {
            // Arrange


            // Action
            fillUpToLimit();

            //  Assertion
            // No Excpetion is thrown

        }

        [Test]
        public void Push_Overflow_throwsStapelException()
        {
            // Arrange
            fillUpToLimit();


            // Action
            StapelException se = Assert.Throws<StapelException> (() => objectUnderTest.Push(new object()));
            Assert.AreEqual("Overflow", se.Message);


        }
        [Test]
        public void Push_Overflow_throwsStapelException_Alternative()
        {
            try
            {
                // Arrange
                fillUpToLimit();


                // Action
                objectUnderTest.Push(new object());
                Assert.Fail("Upps");
            }
            catch (StapelException e)
            {
                Assert.AreEqual("Overflow", e.Message);
                
            }
        

        }

        private void fillUpToLimit()
        {
            for (int i = 0; i < 10; i++)
                objectUnderTest.Push(new object());
        }
    }
}