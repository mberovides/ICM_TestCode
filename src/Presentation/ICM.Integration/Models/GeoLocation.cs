namespace ICM.Integration.Models
{
    public class GeoLocation
    {
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public static string Country = "US";
    }

}