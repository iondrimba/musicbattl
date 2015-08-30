using System;
using System.Globalization;

namespace MusicBattlBLL
{
    public static class DateUtils
    {
        public static void GetWeek( DateTime now , CultureInfo cultureInfo , out DateTime begining , out DateTime end )
        {
            if( now == null )
                throw new ArgumentNullException("now");
            if( cultureInfo == null )
                throw new ArgumentNullException("cultureInfo");

            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

            int offset = firstDayOfWeek - now.DayOfWeek;
            if( offset != 1 )
            {
                DateTime weekStart = now.AddDays(offset);
                DateTime endOfWeek = weekStart.AddDays(6);
                begining = weekStart;
                end = endOfWeek;
            }
            else
            {
                begining = now.AddDays(-6);
                end = now;
            }
        }

        public static void GetMonth( DateTime dateTime , CultureInfo cultureInfo , out DateTime firstDayOfTheMonth , out DateTime lastDayOfTheMonth )
        {
            firstDayOfTheMonth = new DateTime(dateTime.Year , dateTime.Month , 1);

            lastDayOfTheMonth = firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
    }
}