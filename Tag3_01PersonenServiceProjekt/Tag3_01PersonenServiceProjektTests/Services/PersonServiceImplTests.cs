using NUnit.Framework;
using Tag3_01PersonenServiceProjekt.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Bundesbank.Repositories;
using Bundesbank.Repositories.Models;

namespace Tag3_01PersonenServiceProjekt.Services.Tests
{
    [TestFixture()]
    public class PersonServiceImplTests
    {

        private Mock<IPersonRepository> repoMock;
        private PersonServiceImpl objectUnderTest;

        [SetUp]
        public void setup()
        {
            var repo = new MockRepository(MockBehavior.Default);
            repoMock = repo.Create<IPersonRepository>();
            objectUnderTest = new PersonServiceImpl(repoMock.Object);
        }


        [Test()]
        public void Speichern_PersonParameterNull_ThrowsPersonenServiceException()
        {
            Assert.That(() => objectUnderTest.Speichern(null), Throws.TypeOf<PersonServiceException>().And.Message.EqualTo("Person must not be null"));
        }
        [Test()]
        public void Speichern_PersonVornameNull_ThrowsPersonenServiceException()
        {
            Person person = new Person(null, "Doe");
            Assert.That(() => objectUnderTest.Speichern(person), Throws.TypeOf<PersonServiceException>().And.Message.EqualTo("Firstname too short"));
        }
    }
}