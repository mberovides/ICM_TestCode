using ICM.WSI.TaxJar.Models;
using System.Linq;
using Xunit;

namespace ICM.Taxes
{
    public class TaxJarTests
    {

        [Fact]
        public void OriginalOrderIsValid()
        {
           Assert.False(originalTaxJarData.RequiredValuesHandler().Any());
        }

        [Fact]
        public void ShouldValidatesRequiredFields()
        {
            originalTaxJarData.to_country = null;
            var errors = originalTaxJarData.RequiredValuesHandler().ToList();
            int counter = errors.Count;
            Assert.Equal(1, counter);
            Assert.Equal("Shipping country information required", errors[0]);
        }

        [Fact]
        public void ShouldFailWhenZipCodeMissingForUsRequiredFields()
        {
            originalTaxJarData.to_country = "US";
            originalTaxJarData.to_zip = null;
            var errors = originalTaxJarData.RequiredValuesHandler().ToList();
            int counter = errors.Count;
            Assert.Equal(1, counter);
            Assert.Equal("ZipCode required when shipping to US", errors[0]);
        }


        #region Data
        private readonly TaxJarOrder originalTaxJarData = new TaxJarOrder
        {
            from_country = "US",
            from_zip = "07001",
            from_state = "NJ",
            to_country = "US",
            to_zip = "07446",
            to_state = "NJ",
            amount = (decimal)16.50,
            shipping = (decimal)1.5,
            line_items = new TaxJarLineItemOrder[] {
                        new TaxJarLineItemOrder{
                           quantity = 1,
                           unit_price = (decimal) 15.0,
                           product_tax_code = "31000"
                        }

                    },

        };

        private readonly TaxJarRateData fakeRates = new TaxJarRateData
        {
            country = "US",
            country_rate = 0.15m,
            freight_taxable = false,
            county = "MDC",
            county_rate = 0.1255m,
            zip = "33193"
        };

        private readonly TaxJarOrderData fakeOrderTax = new TaxJarOrderData
        {
            amount_to_collect = 10.5m,
            freight_taxable = true,
            has_nexus = false,
            order_total_amount = 30m,
            taxable_amount = 25m,

        };

        private readonly TaxJarRate taxJarRateData = new TaxJarRate
        {
            ZipCode = "90404",
            City = "Santa Monica",
            Country = "USA"
        };


        private TaxJarOrder taxJarOrderData = new TaxJarOrder
        {
            from_country = "US",
            from_zip = "07001",
            from_state = "NJ",
            to_country = "US",
            to_zip = "07446",
            to_state = "NJ",
            amount = (decimal)16.50,
            shipping = (decimal)1.5,
            line_items = new TaxJarLineItemOrder[]
                    {
                                    new TaxJarLineItemOrder
                                    {
                                        unit_price = (decimal)15,
                                        quantity = 1,
                                        product_tax_code = "31000"
                                    }
            }
        };



        #endregion
    }
}