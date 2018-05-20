﻿using System;

namespace SubclassToTest
{
    public class TimeDisplay
    {
        public virtual DateTime GetCurrentTime()
        {
            return TimeProvider.Instance.GetTime();
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
