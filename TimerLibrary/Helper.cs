namespace TimerLibrary
{
    using System;
    using System.Globalization;

    public static class Helper
    {
        public static int ConvertDateTimeStringToSeconds(this string date)
        {
            string digitValue = date.Substring(0, date.Length - 1);

            int time = int.Parse(digitValue) * 60;

            if (date[1] == 'h')
            {
                time *= 60;
            }

            return time;
        }

        public static string ConvertDateTimeToString(this DateTime? date, string format)
        {
            string dateEnd = null;

            if (date.HasValue)
            {
                dateEnd = date.Value.ToString(format, CultureInfo.InvariantCulture);
            }

            return dateEnd;
        }
    }
}
