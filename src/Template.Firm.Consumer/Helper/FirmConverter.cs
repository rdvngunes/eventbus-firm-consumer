using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Template.Services.Domain.CrmContext.Request;

namespace Template.Firm.Consumer.Helper
{
   public class FirmConverter
    {
        public virtual UpsertCrmFirmRequest Convert(UpsertCrmFirmRequest firm)
        {
            TimeZoneInfo tz = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                tz = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Istanbul");
            }
            else
            {
                tz = TimeZoneInfo.FindSystemTimeZoneById("Europe/Istanbul");
            }

            firm.PackageEndDateTime = firm.PackageEndDateTime == null
                ? firm.PackageEndDateTime
                : TimeZoneInfo.ConvertTime(firm.PackageEndDateTime ??
                                           default, tz, TimeZoneInfo.Utc);

            firm.FirmSummaryCreateDateTime = firm.FirmSummaryCreateDateTime == null
                ? firm.FirmSummaryCreateDateTime
                : TimeZoneInfo.ConvertTime(firm.FirmSummaryCreateDateTime ??
                                           default, tz, TimeZoneInfo.Utc);

            firm.PackageStartDateTime = firm.PackageStartDateTime == null
                ? firm.PackageStartDateTime
                : TimeZoneInfo.ConvertTime(firm.PackageStartDateTime ??
                                           default, tz, TimeZoneInfo.Utc);

            firm.UpdatedDateTime = firm.UpdatedDateTime == null
                ? firm.UpdatedDateTime
                : TimeZoneInfo.ConvertTime(firm.UpdatedDateTime ??
                                           default, tz, TimeZoneInfo.Utc);

            firm.Logo = firm.Logo
                        == null
                ? firm.Logo
                : "Logos\\" + GetFilePath(firm.Id, firm.Logo);

            return firm;
        }

        public string GetFilePath(int? firmId, string photoUrl)
        {
            return photoUrl == null
                ? null
                : firmId.ToString().PadLeft(6, '0').Reverse().ToList()
                      .Aggregate("", (current, item) => current + (item + "\\")) +
                  photoUrl;
        }

    }
}
