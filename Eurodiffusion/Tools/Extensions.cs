namespace Eurodiffusion
{
    using System.Collections.Generic;
    public static class DictionaryExtensions
    {
        public static void Addition(this Dictionary<string, int> dict, string key, int value)
        {
            if (!dict.TryAdd(key, value))
                dict[key] += value;
        }
        public static void Addition(this Dictionary<string, int> dict, KeyValuePair<string, int> valuePair)
        {
            if (!dict.TryAdd(valuePair.Key, valuePair.Value))
                dict[valuePair.Key] += valuePair.Value;
        }
    }
}
