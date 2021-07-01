using ICM.Tools.WebTools.Extensions;

namespace ICM.WSI.TaxJar.Extensions
{
    public static class TaxJarRateExtensions
    {
        public static string ToQueryString(this Models.TaxJarRate locationInfo)
            => new System.Collections.Generic.Dictionary<string, object>
            {
                ["country"] = locationInfo?.Country,
                ["state"] = locationInfo?.State,
                ["city"] = locationInfo?.City,
            }.ToQueryString();

        public static string GetRelative(this Models.TaxJarRate input)
            => $"v2/rates/{input.ZipCode}/{input.ToQueryString()}";
    }
}