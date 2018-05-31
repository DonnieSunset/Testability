using System;

namespace Interceptor.Helper
{
    internal class CacheItemPolicy
    {
        public DateTime AbsoluteExpiration { get; set; }
        public TimeSpan SlidingExpiration { get; set; }
    }
}