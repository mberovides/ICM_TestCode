using System;
using System.Collections.Generic;
using System.Text;

namespace ICM.WSI.TaxJar.Models
{
    public class TaxJarBreakdown
    {
        public decimal city_tax_collectable { get; set; }
        public decimal city_tax_rate { get; set; }
        public decimal city_taxable_amount { get; set; }
        public decimal combined_tax_rate { get; set; }
        public decimal county_tax_collectable { get; set; }
        public decimal county_tax_rate { get; set; }
        public decimal county_taxable_amount { get; set; }

        public List<TaxJarLineItem> line_items { get; set; }
        public TaxJarShipping shipping { get; set; }

        public decimal special_district_tax_collectable { get; set; }
        public decimal special_district_taxable_amount { get; set; }
        public decimal special_tax_rate { get; set; }
        public decimal state_tax_collectable { get; set; }
        public decimal state_tax_rate { get; set; }
        public decimal state_taxable_amount { get; set; }
        public decimal tax_collectable { get; set; }
        public decimal taxable_amount { get; set; }

    }
}
