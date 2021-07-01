using System.Threading.Tasks;

namespace ICM.WSI.TaxJar.Abstractions
{
    public interface IRateService
    {
        public Task<Models.TaxJarRateData> TaxJarRateLocationGet(Models.TaxJarRate input);
    }
}
