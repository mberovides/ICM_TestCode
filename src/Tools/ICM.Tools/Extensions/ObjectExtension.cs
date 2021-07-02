using Newtonsoft.Json;
using System;

namespace ICM.Tools.Extensions
{
    public static class ObjectExtension
    {
        public static T DeserializeFromJson<T>(this string json)
            => string.IsNullOrEmpty(json) ? default
            : JsonConvert.DeserializeObject<T>(json);


        public static string SerializeToJson(this object obj)
            => obj == null ? string.Empty
            : JsonConvert.SerializeObject(obj);
    }

}
