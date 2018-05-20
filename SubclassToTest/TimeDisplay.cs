using System;

namespace SubclassToTest
{
    public class TimeDisplay
    {
        public virtual DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public string DisplayCurrentTime()
        {
            var now = GetCurrentTime();

            if (now.Hour == 12 && now.Minute == 0)
            {
                return "Midnight";
            }
            else
            {
                return now.ToShortTimeString();
            }
        }
    }
}
