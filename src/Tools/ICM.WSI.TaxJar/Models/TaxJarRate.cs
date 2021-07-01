using System.ComponentModel.DataAnnotations.Schema;

namespace ICM.WSI.TaxJar.Models
{
    public class TaxJarRate
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [NotMapped]
        public string ZipCode { get; set; }
    }
}
