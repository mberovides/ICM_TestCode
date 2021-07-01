using System;
using System.Threading.Tasks;
using ICM.WSI.TaxJar.Extensions;

namespace ICM.WSI.TaxJar.Services
{
    public class TaxJarCalculatorService : Taxes.Calculator.Abstractions.ITaxCalculatorService
    {
        private readonly WSI.TaxJar.Abstractions.ITaxOrderService _taxjarOrderSvc;
        private readonly WSI.TaxJar.Abstractions.IRateService _taxjarRateSvc;
        protected AutoMapper.IMapper _mapper;

        public TaxJarCalculatorService(
            Abstractions.IRateService taxjarRateSvc,
            Abstractions.ITaxOrderService taxjarOrderSvc,
            AutoMapper.IMapper mapper)
        {
            _taxjarRateSvc = taxjarRateSvc ?? throw new ArgumentNullException(nameof(taxjarRateSvc));
            _taxjarOrderSvc = taxjarOrderSvc ?? throw new ArgumentNullException(nameof(taxjarOrderSvc));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Taxes.Calculator.Models.TaxRateResult> TaxRatesForLocation(Taxes.Calculator.Models.GeoLocation location)
        {
            if (location == null) return default;
            var input = _mapper.Map<ICM.WSI.TaxJar.Models.TaxJarRate>(location);
            var output = await _taxjarRateSvc.TaxJarRateLocationGet(input);
            return _mapper.Map<Taxes.Calculator.Models.TaxRateResult>(output);
        }

        public async Task<ICM.Taxes.Calculator.Models.TaxOrderResult> CalculateTaxOrder(ICM.Taxes.Calculator.Models.OrderInfo order)
            => _mapper.Map<ICM.Taxes.Calculator.Models.TaxOrderResult>(await _taxjarOrderSvc.TaxJarByOrderPost(_mapper.ToTaxJarOrder(order)));
    }
}
