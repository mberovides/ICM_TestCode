using ICM.WSI.TaxJar.Models;
using Xunit;
using ICM.Tools.WebTools.Extensions;
using ICM.WSI.TaxJar.Extensions;
using System.Collections.Generic;

namespace ICM.Taxes
{
    public class ExtensionsTests
    {
        [Fact]
        public void NullObjectToParamQueryString()
        {
            IDictionary<string, object> data = null;
            Assert.Equal("", data.ToQueryString());
        }

        [Fact]
        public void ObjectToParamQueryString()
        {
            var obj = new TaxJarRate { City = "Santa Monica", ZipCode = "90404", State = "CA", Country = "US" };
            var data = obj.ToQueryString();
            Assert.Equal("?city=Santa Monica&country=US&state=CA", data);

        }
    }
}
