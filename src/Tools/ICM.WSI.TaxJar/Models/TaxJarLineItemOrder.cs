namespace ICM.WSI.TaxJar.Models
{
    public class TaxJarLineItemOrder
    {
        public int quantity { get; set; }
        public decimal? unit_price { get; set; }
        public string product_tax_code { get; set; }
    }
}
