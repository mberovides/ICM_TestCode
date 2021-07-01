namespace ICM.Taxes.Calculator.Models
{
    public class LineItem
    {
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProductTaxCode { get; set; }
    }
}