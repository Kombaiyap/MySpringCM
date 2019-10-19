using SpringCMTests.Enums;
using System;

namespace SpringCMTests.Utilities
{
    static class EnumParser
    {
        public static BrowserName ParseToEnum(this string browserName)
        {
            Enum.TryParse(browserName, out BrowserName browserNameEnum);
            return browserNameEnum;
        }
    }
}
