using System.Collections.Generic;

namespace ICM.WSI.TaxJar.Models
{
    public class TaxJarOrder
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }

        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }

        public decimal? amount { get; set; }
        public decimal shipping { get; set; }

        public TaxJarLineItemOrder[] line_items { get; set; }


        public IEnumerable<string> RequiredValuesHandler()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(to_country))
                errors.Add("Shipping country information required");
            if (!amount.HasValue && line_items.Length == 0)
                errors.Add("Either Amount or LineItems are required to calculate taxes");
            if (to_country == "US" && string.IsNullOrWhiteSpace(to_zip))
                errors.Add("ZipCode required when shipping to US");
            if ((to_country == "US" || to_country == "CA") && string.IsNullOrWhiteSpace(to_state))
                errors.Add("State is required when shipping to US or CA");

            return errors;
        }
    }
}
