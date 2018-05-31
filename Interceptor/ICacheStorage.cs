using System;

namespace Interceptor
{
    public interface ICacheStorage
    {
        void Remove(string key);
        void Store(string key, object data);
        void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration);
        T Retrieve<T>(string key);
    }
}
