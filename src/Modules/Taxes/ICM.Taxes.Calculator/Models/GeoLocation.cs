namespace ICM.Taxes.Calculator.Models
{
    public class GeoLocation
    {
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country => "US";
    }
}
