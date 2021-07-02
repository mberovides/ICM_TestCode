using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ICM.Integration;
using Xunit;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace IMC.IntegrationTests
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected HttpClient client;

        public IntegrationTest(WebApplicationFactory<Startup> fixture)
        {
            client = fixture.CreateClient();
        }
        [Fact]
        public async Task RateTaxLocationNotFound()
        {
            var zipCode = "33026";
            var response = await client.GetAsync($"api/TaxCalculator/Rates/{zipCode}");

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"Rates unavailable for zipcode: {zipCode}", responseString);
        }

        [Fact]
        public async Task RateTaxLocation()
        {
            var zipCode = "90404";
            var response = await client.GetAsync($"api/TaxCalculator/Rates/{zipCode}");

            var responseString = await response.Content.ReadAsStringAsync();

            var rates = JsonConvert.DeserializeObject<ICM.Taxes.Calculator.Models.TaxRateResult>(responseString);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(zipCode, rates.Zip);
            Assert.Equal(0, rates.CityRate);
            Assert.Equal(0.01m, rates.CountyRate);
            Assert.Equal(0.0625m, rates.StateRate);
        }

        public async Task CalculateTaxesNotFound()
        {
            var order = SeedOrderToTax();
            order.ZipCodeFrom = "33126";
            var json = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/TaxCalculator/Calculate/", stringContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var orderTaxes = JsonConvert.DeserializeObject<ICM.Taxes.Calculator.Models.TaxOrderResult>(responseString);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"There is something wrong with the order data", responseString);
        }

        [Fact]
        public async Task CalculateTaxes()
        {
            var order = SeedOrderToTax();
            var json = JsonConvert.SerializeObject(order);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"api/TaxCalculator/Calculate/", stringContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var orderTaxes = JsonConvert.DeserializeObject<ICM.Taxes.Calculator.Models.TaxOrderResult>(responseString);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal((decimal)1.09, orderTaxes.AmountToCollect);
            Assert.Equal((decimal)1.5, orderTaxes.Shipping);
            Assert.Equal((decimal)0.06625, orderTaxes.Rate);
  

        }
        #region Utils data
        public ICM.Integration.Models.OrderInfo SeedOrderToTax()
        {
            return new ICM.Integration.Models.OrderInfo
            {
                ZipCodeFrom = "07001",
                ZipCodeTo = "07446",
                Amount = (decimal)16.50,
                Shipping = (decimal)1.5,
                LineItems = new ICM.Integration.Models.LineItem[] {
                    new ICM.Integration.Models.LineItem
                    {
                        Quantity = 1,
                        UnitPrice = (decimal)15.0,
                        ProductTaxCode = "31000"
                    }
                }
            };
        }

        #endregion
    }
}

