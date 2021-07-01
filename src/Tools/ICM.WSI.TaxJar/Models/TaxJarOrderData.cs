namespace ICM.WSI.TaxJar.Models
{
    public class TaxJarOrderData
    {
        public decimal amount_to_collect { get; set; }

        public TaxJarBreakdown breakdown { get; set; }

        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }

        public TaxJarJurisdictions jurisdictions { get; set; }

        public decimal order_total_amount { get; set; }
        public decimal rate { get; set; }
        public decimal shipping { get; set; }
        public string tax_source { get; set; }
        public decimal taxable_amount { get; set; }
    }

    public class TaxJarOrderDataContainer
    {
        public TaxJarOrderData Tax { get; set; }
    }
}
