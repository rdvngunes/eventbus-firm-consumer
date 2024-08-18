using System;
using System.Collections.Generic;
using System.Text;
using Template.Services.Domain.CrmContext.Request;
using Template.Firm.Consumer.Helper;
using NUnit.Framework;

namespace Template.Firm.Consumer.Unit.Test
{
   public class FirmConverterTest
    {
        private FirmConverter _converter = new FirmConverter();
        [Test]
        public void FirmConverter_Should_Success_When_Convert_Run()
        {
            //Given
            var firmUser = new UpsertCrmFirmRequest
            {
                Id = 1,
                Logo = "ed5836d0-2256-426a-903a-a00ba7f2d8cd.jpg",
                PackageEndDateTime = Convert.ToDateTime("2020-03-29 09:02:25"),
                FirmSummaryCreateDateTime = Convert.ToDateTime("2020-03-29 09:02:25"),
                PackageStartDateTime = Convert.ToDateTime("2020-03-29 09:02:25"),
                UpdatedDateTime = Convert.ToDateTime("2020-03-29 09:02:25"),
            };

            //When
            var result = _converter.Convert(firmUser);

            //Then
            Assert.AreEqual("Logos\\1\\0\\0\\0\\0\\0\\ed5836d0-2256-426a-903a-a00ba7f2d8cd.jpg", result.Logo);
            Assert.AreEqual(Convert.ToDateTime("2020-03-29 06:02:25"), result.FirmSummaryCreateDateTime);
            Assert.AreEqual(Convert.ToDateTime("2020-03-29 06:02:25"), result.PackageEndDateTime);
            Assert.AreEqual(Convert.ToDateTime("2020-03-29 06:02:25"), result.UpdatedDateTime);
            Assert.AreEqual(Convert.ToDateTime("2020-03-29 06:02:25"), result.UpdatedDateTime);
        }

        [Test]
        public void It_Should_Return_Correct_Path_When_PhotoUrl_is_Not_Null()
        {
            //Given
            UpsertCrmFirmUserRequest firmUserRequest = null;
            var firmId = 2302241;
            var photoUrl = "ed5836d0-2256-426a-903a-a00ba7f2d8cd.jpg";

            //when
            var result = _converter.GetFilePath(firmId, photoUrl);
            //then
            var expected = "1\\4\\2\\2\\0\\3\\2\\ed5836d0-2256-426a-903a-a00ba7f2d8cd.jpg";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void It_Should_Return_Null_When_PhotoUrl_is_Null()
        {
            //Given
            UpsertCrmFirmUserRequest firmUserRequest = null;
            var firmId = 2302241;
            string photoUrl = null;

            //when
            var result = _converter.GetFilePath(firmId, photoUrl);
            //then
            Assert.IsNull(result);
        }
    }
}
