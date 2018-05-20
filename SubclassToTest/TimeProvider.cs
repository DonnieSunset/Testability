using System;

namespace SubclassToTest
{
    /// <summary>
    /// Singleton Class
    /// </summary>
    public class TimeProvider
    {
        protected static TimeProvider soleInstance = null;

        protected TimeProvider()
        {
        }

        public static TimeProvider Instance
        {
            get
            {
                if (soleInstance == null) soleInstance = new TimeProvider();
                return soleInstance;
            }
        }

        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }

}
