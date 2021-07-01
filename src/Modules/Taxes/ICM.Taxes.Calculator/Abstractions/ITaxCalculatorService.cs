using System.Threading.Tasks;

namespace ICM.Taxes.Calculator.Abstractions
{
    public interface ITaxCalculatorService
    {
        Task<Models.TaxRateResult> TaxRatesForLocation(Models.GeoLocation location);

        Task<Models.TaxOrderResult> CalculateTaxOrder(Models.OrderInfo order);
    }
}
