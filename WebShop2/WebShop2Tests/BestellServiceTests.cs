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

        [SetUp]
        public void SetUp()
        {
            repositoryMock = new Mock<IBestellungenRepository>();
            bonitaetsServiceMock = new Mock<IBonitaetsService>();
            verfuegbarkeitsServiceMock = new Mock<IVerfuegbarkeitsService>();
            objectUnderTest = new BestellService(repositoryMock.Object, bonitaetsServiceMock.Object, verfuegbarkeitsServiceMock.Object);
        }

        [Test]
        public void ErfasseBestellung_ParameterNull_ThrowsBestellServiceException()
        {
            Assert.That(() => objectUnderTest.ErfasseBestellung(null),
                Throws.TypeOf<BestellServiceException>().With.Message.EqualTo("Parameter darf nicht null sein."));
        }

        [Test]
        public void ErfasseBestellung_UngueltigeKundennummer_ReturnsUngueltige_Kundennummer()
        {
            TblBestellung bestellung = new TblBestellung
            {
                Id = Guid.NewGuid().ToString(),
                Kundennummer = 1,
                Produkt = "Nagel",
                Status = null
            };
            var status = objectUnderTest.ErfasseBestellung(bestellung);
            Assert.That(status, Is.EqualTo(BestellStatus.Ungueltige_Kundennummer));
        }

    }
}
