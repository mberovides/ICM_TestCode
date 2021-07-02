using AutoMapper;
using ICM.Taxes.Calculator.Extensions;
using System.Collections.Generic;

namespace ICM.Integration.Extensions
{
    public static class MappedExtensions
    {
        public static Taxes.Calculator.Models.OrderInfo ToOrderInfo(this IMapper mapper, Models.OrderInfo model)
        {
            List<Taxes.Calculator.Models.LineItem> mappedLineMapped = new List<Taxes.Calculator.Models.LineItem>();
            var modelMapper = mapper.Map<Taxes.Calculator.Models.OrderInfo>(model);
            if (model.LineItems != null)
            {
                foreach (var item in model.LineItems)
                {
                    mappedLineMapped.Add(mapper.Map<Taxes.Calculator.Models.LineItem>(item));
                }
            }
            modelMapper.LineItems = mappedLineMapped;

            return modelMapper.AddFrom(model.ZipCodeFrom).AddTo(model.ZipCodeTo);
        }
    }
}
