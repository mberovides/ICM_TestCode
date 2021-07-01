namespace ICM.Taxes.Calculator.Models
{
    public class TaxRateResult
    {
        public string City { get; set; }
        public decimal? CityRate { get; set; }

        public string County { get; set; }
        public decimal? CountyRate { get; set; }

        public string State { get; set; }
        public decimal? StateRate { get; set; }

        public string Zip { get; set; }
    }
}
