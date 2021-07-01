using Newtonsoft.Json;
using System;

namespace ICM.Tools.Extensions
{
    public static class ObjectExtension
    {
        public static T DeserializeFromJson<T>(this string json)
        {
            if (string.IsNullOrEmpty(json)) return default;
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                return default;
            }
        }

        public static string SerializeToJson(this object obj)
        {
            if (obj == null) return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }

    }
}
