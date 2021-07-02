using System.Collections.Generic;

namespace ICM.Taxes.Calculator.Models
{
    public class OrderInfo
    {
        public GeoLocation From { get; set; }
        public GeoLocation To { get; set; }
        public decimal? Amount { get; set; }
        public decimal Shipping { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}