using System.Threading.Tasks;

namespace ICM.WSI.TaxJar.Abstractions
{
    public interface ITaxOrderService
    {
        public Task<Models.TaxJarOrderData> TaxJarByOrderPost(Models.TaxJarOrder input);
    }
}