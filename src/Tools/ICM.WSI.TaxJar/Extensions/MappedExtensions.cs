using AutoMapper;
using ICM.Taxes.Calculator.Models;
using System.Collections.Generic;

namespace ICM.WSI.TaxJar.Extensions
{
    public static class MappedExtensions
    {
        public static ICM.WSI.TaxJar.Models.TaxJarOrder ToTaxJarOrder(this IMapper mapper, OrderInfo orderInput)
        {
            if (orderInput == null || mapper == null) return default;

            var input = mapper.Map<ICM.WSI.TaxJar.Models.TaxJarOrder>(orderInput);
            List<ICM.WSI.TaxJar.Models.TaxJarLineItemOrder> mappedLineItems = new List<ICM.WSI.TaxJar.Models.TaxJarLineItemOrder>();

            if (orderInput.LineItems != null)
            {
                foreach (var item in orderInput.LineItems)
                {
                    mappedLineItems.Add(mapper.Map<ICM.WSI.TaxJar.Models.TaxJarLineItemOrder>(item));
                }
            }

            input.line_items = mappedLineItems.ToArray();
            return input;
        }
    }
}