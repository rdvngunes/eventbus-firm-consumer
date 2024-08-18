using Template.Core.Service;
using Template.Services.Domain.CrmContext.Request;
using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Repositories;
using Template.Firm.Consumer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Template.Firm.Consumer.Integration.Test.Services
{
    public class FirmServiceTest : ServiceTestBase
    {
        [SetUp]
        public void SetupAsync()
        {
            this.StartService();
        }

        [Test]
        public async Task ItShouldReturnTrueWhenServiceReturnOk()
        {
            //Given
            FluentMockServer server = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://localhost:5001" },
                StartAdminInterface = true
            });

            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>()
            {
                Succeeded = true,
            };

            UpsertCrmFirmRequest upsertCrmFirmRequest = new UpsertCrmFirmRequest()
            {
                TypeDescription = "Emlak Ofisi",
                ShortName = "Marım Emlak Ofisi",
                Name = "Marım Emlak Ofisi!",
                Status = "Aktif",
                AdvisorQty = 6,
                Website = "www.marim.net",
                PackageRealtyQty = 50,
                PackageStartDateTime = DateTime.ParseExact("2012-01-12 15:46:21", "yyyy-MM-dd HH:m:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                PackageEndDateTime = DateTime.ParseExact("2021-02-06 02:16:19", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                ChamberOfRealEstateName = "İSTANBUL EMLAK KOMİSYONCULARI",
                RealEstateOrganizationName = "TURYAP",
                Email = "emlaktest@gmail.com",
                City = "Zonguldak",
                County = "Devrek",
                District = "Yassıören (Köroğlu)",
                FirmSummaryCreateDateTime = DateTime.ParseExact("2011-02-23 13:57:01", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                Logo = null,
                ChamberOfCommerceName = "İSTANBUL TİCARET ODASI",
                Id = 33417,
                MapLatitude = null,
                MapLongtitude = null,
                UpdatedUser = "Şebnem Şahin",
                UpdatedDateTime = DateTime.ParseExact("2019-02-25 14:23:22", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                DistrictId = 141378,
                TaxNo = null,
                TaxOffice = null
            };

            //when
            server
              .Given(Request
              .Create()
              .WithPath("/firm")
             .WithBody("{\"TypeDescription\":\"Emlak Ofisi\",\"ShortName\":\"Marım Emlak Ofisi\",\"Name\":\"Marım Emlak Ofisi!\",\"Status\":\"Aktif\",\"AdvisorQty\":6,\"Website\":\"www.marim.net\",\"PackageRealtyQty\":50,\"PackageStartDateTime\":\"2012-01-12T13:46:21Z\",\"PackageEndDateTime\":\"2021-02-05T23:16:19Z\",\"ChamberOfRealEstateName\":\"İSTANBUL EMLAK KOMİSYONCULARI\",\"RealEstateOrganizationName\":\"TURYAP\",\"Email\":\"emlaktest@gmail.com\",\"City\":\"Zonguldak\",\"County\":\"Devrek\",\"District\":\"Yassıören (Köroğlu)\",\"FirmSummaryCreateDateTime\":\"2011-02-23T11:57:01Z\",\"Logo\":null,\"ChamberOfCommerceName\":\"İSTANBUL TİCARET ODASI\",\"Id\":33417,\"MapLatitude\":null,\"MapLongtitude\":null,\"UpdatedUser\":\"Şebnem Şahin\",\"UpdatedDateTime\":\"2019-02-25T11:23:22Z\",\"DistrictId\":141378,\"TaxNo\":null,\"TaxOffice\":null}")
              .UsingPost())
              .RespondWith(Response.Create()
                          .WithStatusCode(200)
                          .WithHeader("Content-Type", "application/json")
                          .WithBody(Newtonsoft.Json.JsonConvert.SerializeObject(serviceResponse))
                          );


            //Then
            Assert.DoesNotThrowAsync(() => FirmService.UpsertFirmOnCrmAsync(upsertCrmFirmRequest));

        }

        [Test]
        public async Task ItShouldNotThrowsExceptionWhenServiceReturnOkAsync()
        {
            //Given
            FluentMockServer server = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://localhost:5001" },
                StartAdminInterface = true
            });

            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>()
            {
                Succeeded = false,
            };

            UpsertCrmFirmRequest upsertCrmFirmRequest = new UpsertCrmFirmRequest()
            {
                TypeDescription = "Emlak Ofisi",
                ShortName = "Marım Emlak Ofisi",
                Name = "Marım Emlak Ofisi!",
                Status = "Aktif",
                AdvisorQty = 6,
                Website = "www.marim.net",
                PackageRealtyQty = 50,
                PackageStartDateTime = DateTime.ParseExact("2012-01-12 15:46:21", "yyyy-MM-dd HH:m:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                PackageEndDateTime = DateTime.ParseExact("2021-02-06 02:16:19", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                ChamberOfRealEstateName = "İSTANBUL EMLAK KOMİSYONCULARI",
                RealEstateOrganizationName = "TURYAP",
                Email = "emlaktest@gmail.com",
                City = "Zonguldak",
                County = "Devrek",
                District = "Yassıören (Köroğlu)",
                FirmSummaryCreateDateTime = DateTime.ParseExact("2011-02-23 13:57:01", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                Logo = null,
                ChamberOfCommerceName = "İSTANBUL TİCARET ODASI",
                Id = 33417,
                MapLatitude = null,
                MapLongtitude = null,
                UpdatedUser = "Şebnem Şahin",
                UpdatedDateTime = DateTime.ParseExact("2019-02-25 14:23:22", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToUniversalTime(),
                DistrictId = 141378,
                TaxNo = null,
                TaxOffice = null
            };

            //when
            server
              .Given(Request
              .Create()

              .WithPath("/firm")
             .WithBody("{\"TypeDescription\":\"Emlak Ofisi\",\"ShortName\":\"Marım Emlak Ofisi\",\"Name\":\"Marım Emlak Ofisi!\",\"Status\":\"Aktif\",\"AdvisorQty\":6,\"Website\":\"www.marim.net\",\"PackageRealtyQty\":50,\"PackageStartDateTime\":\"2012-01-12T13:46:21Z\",\"PackageEndDateTime\":\"2021-02-05T23:16:19Z\",\"ChamberOfRealEstateName\":\"İSTANBUL EMLAK KOMİSYONCULARI\",\"RealEstateOrganizationName\":\"TURYAP\",\"Email\":\"emlaktest@gmail.com\",\"City\":\"Zonguldak\",\"County\":\"Devrek\",\"District\":\"Yassıören (Köroğlu)\",\"FirmSummaryCreateDateTime\":\"2011-02-23T11:57:01Z\",\"Logo\":null,\"ChamberOfCommerceName\":\"İSTANBUL TİCARET ODASI\",\"Id\":33417,\"MapLatitude\":null,\"MapLongtitude\":null,\"UpdatedUser\":\"Şebnem Şahin\",\"UpdatedDateTime\":\"2019-02-25T11:23:22Z\",\"DistrictId\":141378,\"TaxNo\":null,\"TaxOffice\":null}")
              .UsingPost())
              .RespondWith(Response.Create()
                          .WithStatusCode(200)
                          .WithHeader("Content-Type", "application/json")
                          .WithBody(Newtonsoft.Json.JsonConvert.SerializeObject(serviceResponse))
                          );
            //Then
            Assert.False(await FirmService.UpsertFirmOnCrmAsync(upsertCrmFirmRequest));
            server.Stop();
        }

    }
}

