using System.ComponentModel.DataAnnotations;

namespace ICM.Integration.Models
{
    public class OrderInfo
    {
        [Required]
        public string ZipCodeFrom { get; set; }
        [Required]
        public string ZipCodeTo { get; set; }
        public decimal Amount { get; set; }
        [Required]
        public decimal Shipping { get; set; }
        [Required]
        public LineItem[] LineItems { get; set; }
    }
}