using System.Threading.Tasks;

namespace ICM.Taxes.Calculator.Abstractions
{
    public interface ITaxServices
    {
        Task<Models.TaxRateResult> TaxRatesForLocation(string zipCode);

        Task<Models.TaxOrderResult> CalculateTaxOrder(Models.OrderInfo order);
    }
}
