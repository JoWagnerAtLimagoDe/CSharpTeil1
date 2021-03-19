using NUnit.Framework;
using Moq;
using System;
using WebShop.Services.Impl;
using WebShop.Repositories;
using WebShop.Services;
using WebShop.Entities;

namespace WebShopTests
{
    [TestFixture]
    public class BestellServiceTests
    {
        private BestellService objectUnderTest;
        private Mock<IBestellungenRepository> repositoryMock;
        private Mock<IBonitaetsService> bonitaetsServiceMock;
        private Mock<IVerfuegbarkeitsService> verfuegbarkeitsServiceMock;
        private readonly TblBestellung validBestellung = new TblBestellung
        {
            Id = Guid.NewGuid().ToString(),
            Kundennummer = 3,
            Produkt = "Nagel",
            Status = null
        };

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IBestellungenRepository>(MockBehavior.Strict);
            bonitaetsServiceMock = new Mock<IBonitaetsService>(MockBehavior.Strict);
            verfuegbarkeitsServiceMock = new Mock<IVerfuegbarkeitsService>(MockBehavior.Strict);
            objectUnderTest = new BestellService(repositoryMock.Object, bonitaetsServiceMock.Object, verfuegbarkeitsServiceMock.Object);
        }

        [Test]
        public void ErfasseBestellung_ParameterNull_ThrowsBestellServiceException()
        {
            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(null),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Parameter darf nicht null sein."));
        }

        [Test]
        public void ErfasseBestellung_UngueltigeKundennummer_ThrowsBestellServiceExceptio()
        {
            /* Arrange */
            TblBestellung bestellung = new TblBestellung
            {
                Id = Guid.NewGuid().ToString(),
                Kundennummer = 1,
                Produkt = "Nagel",
                Status = null
            };

            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(bestellung),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Ungültige Kundennummer."));
        }

        [Test]
        public void ErfasseBestellung_VerfuegbarkeitsServiceThrowsTimeoutException_ThrowsBestellServiceException()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Throws(new TimeoutException());

            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(validBestellung),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Lager antwortet nicht."));
        }

        [Test]
        public void ErfasseBestellung_VerfuegbarkeitsServiceThrowsUnexpectedException_ThrowsBestellServiceException()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Throws(new NullReferenceException());

            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(validBestellung),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Problem im aufgerufenen Service."));
        }

        [Test]
        public void ErfasseBestellung_VerfuegbarkeitsServiceTakesParameterAndProduktIsNotAvailable_ReturnsNicht_Lieferbar()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(false);
            repositoryMock.Setup(rm => rm.Insert(It.IsAny<TblBestellung>()));
            repositoryMock.Setup(rm => rm.Save());

            /* Act */
            var status = objectUnderTest.ErfasseBestellung(validBestellung);

            /* Assert */
            verfuegbarkeitsServiceMock.Verify(vsm => vsm.IsAvailable(validBestellung.Produkt), Times.Once());
            Assert.That(status, Is.EqualTo(BestellStatus.NichtLieferbar));           
        } // hier eigentlich besser zwei Tests

        [Test]
        public void ErfasseBestellung_ProduktIsNotAvailable_BestellungIsPassedToRepo()
        {
            /* Arrange */
            string dbStatus = "";
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(false);
            repositoryMock.Setup(rm => rm.Insert(It.IsAny<TblBestellung>())).Callback<TblBestellung>(b => dbStatus = b.Status);
            repositoryMock.Setup(rm => rm.Save());

            /* Act */
            var status = objectUnderTest.ErfasseBestellung(validBestellung);

            /* Assert */
            Assert.That(dbStatus, Is.EqualTo(Enum.GetName(typeof(BestellStatus),BestellStatus.NichtLieferbar)));
            repositoryMock.Verify(rm => rm.Insert(validBestellung), Times.Once());
        }

        [Test]
        public void ErfasseBestellung_BonitaetsServiceThrowsArithmeticException_ThrowsBestellServiceException()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Throws(new ArithmeticException());

            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(validBestellung),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("S&P antwortet nicht."));
        }

        [Test]
        public void ErfasseBestellung_BonitaetsServiceThrowsUnexpectedException_ThrowsBestellServiceException()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Throws(new InvalidOperationException());

            /* Act & Assert */
            Assert.That(() => objectUnderTest.ErfasseBestellung(validBestellung),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Problem im aufgerufenen Service."));
        }

        [Test]
        public void ErfasseBestellung_BonitaetsServiceTakesParameterAndKundennummerIsNotSolvent_ReturnsNachnahme()
        {
            /* Arrange */
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Returns(false);
            repositoryMock.Setup(rm => rm.Insert(It.IsAny<TblBestellung>()));
            repositoryMock.Setup(rm => rm.Save());

            /* Act */
            var status = objectUnderTest.ErfasseBestellung(validBestellung);

            /* Assert */
            bonitaetsServiceMock.Verify(bsm => bsm.IsSolvent(validBestellung.Kundennummer), Times.Once());
            Assert.That(status, Is.EqualTo(BestellStatus.Nachnahme));
        } // hier eigentlich besser zwei Tests

        [Test]
        public void ErfasseBestellung_KundennummerIsNotSolvent_BestellungIsPassedToRepo()
        {
            /* Arrange */
            string dbStatus = "";
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Returns(false);
            repositoryMock.Setup(rm => rm.Insert(It.IsAny<TblBestellung>())).Callback<TblBestellung>(b => dbStatus = b.Status);
            repositoryMock.Setup(rm => rm.Save());

            /* Act */
            var status = objectUnderTest.ErfasseBestellung(validBestellung);

            /* Assert */
            Assert.That(dbStatus, Is.EqualTo(Enum.GetName(typeof(BestellStatus), BestellStatus.Nachnahme)));
            repositoryMock.Verify(rm => rm.Insert(validBestellung), Times.Once());
        }

        [Test]
        public void ErfasseBestellung_ProduktIsAvailableAndKundennummerIsSolvent_BestellungIsPassedToRepo()
        {
            /* Arrange */
            string dbStatus = "";
            verfuegbarkeitsServiceMock.Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Returns(true);
            repositoryMock.Setup(rm => rm.Insert(It.IsAny<TblBestellung>())).Callback<TblBestellung>(b => dbStatus = b.Status);
            repositoryMock.Setup(rm => rm.Save());

            /* Act */
            var status = objectUnderTest.ErfasseBestellung(validBestellung);

            /* Assert */
            Assert.That(dbStatus, Is.EqualTo(Enum.GetName(typeof(BestellStatus), BestellStatus.Rechnung)));
            repositoryMock.Verify(rm => rm.Insert(validBestellung), Times.Once());
        }

        [Test]
        public void ErfasseBestellung_ProduktIsAvailableAndKundennummerIsSolvent_CallsInSequence()
        {
            /* Arrange */
            var sequence = new MockSequence();
            verfuegbarkeitsServiceMock.InSequence(sequence).Setup(vsm => vsm.IsAvailable(It.IsAny<string>())).Returns(true);
            bonitaetsServiceMock.InSequence(sequence).Setup(bsm => bsm.IsSolvent(It.IsAny<int>())).Returns(true);
            repositoryMock.InSequence(sequence).Setup(rm => rm.Insert(It.IsAny<TblBestellung>()));
            repositoryMock.InSequence(sequence).Setup(rm => rm.Save());

            /* Act & Assert */
            Assert.DoesNotThrow(() => objectUnderTest.ErfasseBestellung(validBestellung));
        }

        /* Es fehlen noch einige Tests! */
    }   
}
