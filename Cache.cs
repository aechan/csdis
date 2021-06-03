using System;
using System.Collections.Concurrent;

namespace CSDis
{
    class Cache
    {
        public static Cache GetInstance()
        {
            if (_instance == null)
                _instance = new Cache();
            return _instance;
        }

        public bool GetCacheValue(string key, out string value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void PutCacheValue(string key, string value)
        {
            _cache[key] = value;
        }

        public bool DeleteCacheValue(string key, out string value)
        {
            return _cache.TryRemove(key, out value);
        }

        private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
        private static Cache _instance;
    }
}