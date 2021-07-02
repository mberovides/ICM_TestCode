using System.Threading.Tasks;

namespace ICM.Taxes.Calculator
{
    public class TaxServices : Abstractions.ITaxServices
    {
        private readonly Abstractions.IGeoServices _geoSvc;
        private readonly Abstractions.ITaxCalculatorService _taxCalculatorService;

        public TaxServices(
            Abstractions.ITaxCalculatorService taxCalculatorService,
            Abstractions.IGeoServices geoSvc)
        {
            _taxCalculatorService = taxCalculatorService;
            _geoSvc = geoSvc;
        }

        public async Task<Models.TaxRateResult> TaxRatesForLocation(string zipCode)
         => await _taxCalculatorService.TaxRatesForLocation(_geoSvc.GetLocation(zipCode));


        public async Task<Models.TaxOrderResult> CalculateTaxOrder(Models.OrderInfo order)
            => await _taxCalculatorService.CalculateTaxOrder(Fill(order));

        private Models.OrderInfo Fill(Models.OrderInfo order)
        {
            if (order == null) return default;
            order.From = _geoSvc.GetLocation(order.From?.ZipCode);
            order.To = _geoSvc.GetLocation(order.To?.ZipCode);
            return order;
        }

    }
}

