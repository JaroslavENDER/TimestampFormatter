using System;

namespace Ender.TimestampFormatterCore
{
    public class TimestampFormatter : ITimestampFormatter
    {
        public string Format(DateTime timestamp)
        {
            var timespan = DateTime.Now - timestamp;

            if (timespan.TotalMinutes < 1)
                return "Только что";
            if (timespan.TotalHours < 1)
                return $"{(int)timespan.TotalMinutes} {GetTimeTitleString((int)timespan.TotalMinutes).Minutes} назад";
            if (timespan.TotalDays < 1)
                return $"{(int)timespan.TotalHours} {GetTimeTitleString((int)timespan.TotalHours).Hours} назад";
            if (timespan.TotalDays < 7)
                return $"{(int)timespan.TotalDays} {GetTimeTitleString((int)timespan.TotalDays).Days} назад";
            if ((int)timespan.TotalDays == 7)
                return "Неделю назад";

            return timestamp.ToLongDateString();
        }

        private TimeTitleString GetTimeTitleString(int time)
        {
            if (time > 10 && time < 20) return new TimeTitleString("минут", "часов", "дней");
            var t = time % 10;
            if (t == 1) return new TimeTitleString("минуту", "час", "день");
            if (t > 1 && t < 5) return new TimeTitleString("минуты", "часа", "дня");
            return new TimeTitleString("минут", "часов", "дней");
        }

        private struct TimeTitleString
        {
            public string Minutes { get; set; }
            public string Hours { get; set; }
            public string Days { get; set; }

            public TimeTitleString(string minutes, string hours, string days)
            {
                Minutes = minutes;
                Hours = hours;
                Days = days;
            }
        }
    }
}
