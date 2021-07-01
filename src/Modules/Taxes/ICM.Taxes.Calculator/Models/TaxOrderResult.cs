using System;
namespace ICM.Taxes.Calculator.Models
{
    public class TaxOrderResult
    {
        public decimal AmountToCollect { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal Shipping { get; set; }
        public string TaxSource { get; set; }
        public decimal TaxableAmount { get; set; }

    }
}