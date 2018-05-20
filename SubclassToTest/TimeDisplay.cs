using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubclassToTest
{
    public class TimeDisplay
    {
        public string GetCurrentTime()
        {
            var now = TimeProvider.Instance.GetTime();

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
