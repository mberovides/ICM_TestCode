using System.Linq;
using ICM.Tools.Extensions;

namespace ICM.Tools.WebTools.Extensions
{
    public static class HttpExtension
    {
        private static string[] ToParamList(this System.Collections.Generic.IDictionary<string, object> data)
           => data?
               .Where(x => !string.IsNullOrEmpty(x.Key))
               .Where(x => x.Value != null)
               .OrderBy(x => x.Key)
               .Select(x => $"{x.Key}={x.Value}")
               .ToArray()
           ?? new string[0];

        public static async System.Threading.Tasks.Task<T> GetDataAsync<T>(this System.Net.Http.HttpResponseMessage response)
            => response.IsSuccessStatusCode
                ? (await response.Content?.ReadAsStringAsync()).DeserializeFromJson<T>()
                : default;

        public static System.Net.Http.StringContent GetStringContent(this object obj)
            => new System.Net.Http.StringContent(
                obj.SerializeToJson(),
                System.Text.Encoding.UTF8,
                "application/json");

        public static string ToQueryString(this System.Collections.Generic.IDictionary<string, object> data)
        {
            var param = data.ToParamList();
            return param.Any()
                ? $"?{string.Join("&", param)}"
                : string.Empty;
        }

    }
}

