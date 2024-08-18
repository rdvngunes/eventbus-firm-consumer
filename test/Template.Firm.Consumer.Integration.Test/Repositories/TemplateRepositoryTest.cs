using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Repositories;
using Microsoft.Extensions.Options;

namespace Template.Firm.Consumer.Integration.Test.Repositories
{
	[TestFixture]
	class TemplateRepositoryTest : RepositoryTestBase
	{
		private TemplateDbConfig _templateDbConfig;
		private OptionsWrapper<TemplateDbConfig> TemplateDbOptions;
		private TemplateRepository _templateRepository;

		[OneTimeSetUp]
		public async Task Setup()
		{
			await this.StartMssql();
			await this.InitDatabase();

			_templateDbConfig = new TemplateDbConfig() {
				ConnectionString = ConnectionString
			};
			TemplateDbOptions = new OptionsWrapper<TemplateDbConfig>(_templateDbConfig);
			_templateRepository = new TemplateRepository(TemplateDbOptions);
		}

		[OneTimeTearDown]
		public async Task TearDown()
		{
			await this.StopMssql();
		}

		[Test]
		public async Task ItShouldReturnTheSameFirmIdAsync()
		{
			var firmId = 54027;
			int expected = 54027;
			var firm = await _templateRepository.GetFirmAsync(firmId);
			Assert.AreEqual(expected, firm.Id);
		}

		[Test]
		public async Task ItShouldReturnNullIfFirmIdNullAsync()
		{
			var firmId = 55027;
			int? expected = null;
			var firm = await _templateRepository.GetFirmAsync(firmId);
			Assert.AreEqual(expected, firm);
		}
        [Test]
        public async Task ItShouldReturnTheSameDistrictId()
        {
            var firmId = 54027;
            int expected = 13014;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.DistrictId);
        }
        [Test]
        public async Task ItShouldReturnTheSameUpdatedDateTime()
        {
            var firmId = 54027;
            DateTime? expected = DateTime.Parse("2017-03-29 14:55:52.677") ;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.UpdatedDateTime);
        }
        [Test]
        public async Task ItShouldReturnTheSameUpdatedUser()
        {
            var firmId = 54027;
            string expected = "Dominique Le Doare";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.UpdatedUser);
        }
        [Test]
        public async Task ItShouldReturnTheSameMapLongtitude()
        {
            var firmId = 54027;
            decimal? expected = 29.006554000000050M;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.MapLongtitude);
        }
        [Test]
        public async Task ItShouldReturnTheSameMapLatitude()
        {
            var firmId = 54027;
            decimal? expected = 41.051276000000000M;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.MapLatitude);
        }
        [Test]
        public async Task ItShouldReturnTheSameChamberOfCommerceName()
        {
            var firmId = 54027;
            string expected = "İSTANBUL TİCARET ODASI";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.ChamberOfCommerceName);
        }
        [Test]
        public async Task ItShouldReturnTheSameLogo()
        {
            var firmId = 54027;
            string expected = "982e85df-2b21-4228-a63f-9db5db3ce650.jpg";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.Logo);
        }
        [Test]
        public async Task ItShouldReturnTheSameFirmSummaryCreateDateTime()
        {
            var firmId = 54027;
            DateTime? expected =DateTime.Parse("2014-01-27 17:44:20.437");
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.FirmSummaryCreateDateTime);
        }
        [Test]
        public async Task ItShouldReturnTheSameDistrict()
        {
            var firmId = 54027;
            string expected =null;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.District);
        }
        [Test]
        public async Task ItShouldReturnTheSameCounty()
        {
            var firmId = 54027;
            string expected =null;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.County);
        }
        [Test]
        public async Task ItShouldReturnTheSameTaxNo()
        {
            var firmId = 54027;
            double? expected =null;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.TaxNo);
        }
        [Test]
        public async Task ItShouldReturnTheSameCity()
        {
            var firmId = 54027;
            string expected =null;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.City);
        }
        [Test]
        public async Task ItShouldReturnTheSameRealEstateOrganizationName()
        {
            var firmId = 54027;
            string expected = "Bağımsız Emlak Ofisi";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.RealEstateOrganizationName);
        }
        [Test]
        public async Task ItShouldReturnTheSameChamberOfRealEstateName()
        {
            var firmId = 54027;
            string expected = "İSTANBUL EMLAK KOMİSYONCULARI";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.ChamberOfRealEstateName);
        }
        [Test]
        public async Task ItShouldReturnTheSamePackageEndDateTime()
        {
            var firmId = 54027;
            DateTime? expected =DateTime.Parse("2019-06-27 17:58:45.357");
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.PackageEndDateTime);
        }
        [Test]
        public async Task ItShouldReturnTheSamePackageStartDateTime()
        {
            var firmId = 54027;
            DateTime? expected =DateTime.Parse("2014-01-27 17:44:20.430");
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.PackageStartDateTime);
        }
        [Test]
        public async Task ItShouldReturnTheSamePackageRealtyQty()
        {
            var firmId = 54027;
            int? expected = 400;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.PackageRealtyQty);
        }
        [Test]
        public async Task ItShouldReturnTheSameWebsite()
        {
            var firmId = 54027;
            string expected = "www.expat-turkey.com";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.Website);
        }
        [Test]
        public async Task ItShouldReturnTheSameAdvisorQty()
        {
            var firmId = 54027;
            int? expected = 1;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.AdvisorQty);
        }
        [Test]
        public async Task ItShouldReturnTheSameStatus()
        {
            var firmId = 54027;
            string expected = "Aktif";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.Status);
        }
        [Test]
        public async Task ItShouldReturnTheSameName()
        {
            var firmId = 54027;
            string expected = "Dominique Marthe Louise Le Doare Atay";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.Name);
        }
        [Test]
        public async Task ItShouldReturnTheSameShortName()
        {
            var firmId = 54027;
            string expected = "Expat Turkey";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.ShortName);
        }
        [Test]
        public async Task ItShouldReturnTheSameTypeDescription()
        {
            var firmId = 54027;
            string expected = "Emlak Ofisi";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.TypeDescription);
        }
        [Test]
        public async Task ItShouldReturnTheSameEmail()
        {
            var firmId = 54027;
            string expected = "dominique@expat-turkey.com";
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.Email);
        }
        [Test]
        public async Task ItShouldReturnTheSameTaxOffice()
        {
            var firmId = 54027;
            string expected =null;
            var firm = await _templateRepository.GetFirmAsync(firmId);
            Assert.AreEqual(expected, firm.TaxOffice);
        }

    }
}
