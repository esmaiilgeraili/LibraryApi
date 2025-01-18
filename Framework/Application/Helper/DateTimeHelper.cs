using System.Globalization;

namespace Framework.Application.Helper
{
    public static class DateTimeHelper
    {
        public static string ToShamsi(this DateTime @this, string format = "yyyy/MM/dd")
        {
            CultureInfo cultureInfo = new CultureInfo("fa-IR");
            cultureInfo.DateTimeFormat.Calendar = new PersianCalendar();
            return @this.ToString(format, cultureInfo);
        }
    }
}
