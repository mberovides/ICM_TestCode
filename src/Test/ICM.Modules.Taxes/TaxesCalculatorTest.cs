using AutoMapper;
using Xunit;

namespace ICM.Taxes
{
    public class TaxesCalculatorTest 
    {
        [Fact]
        public void Calculator_Should_validate_mapper_configuration()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ICM.Taxes.Calculator.Mapping.TaxesServiceProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}