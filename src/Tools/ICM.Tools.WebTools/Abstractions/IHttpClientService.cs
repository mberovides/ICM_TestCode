using System.Threading.Tasks;

namespace ICM.Tools.WebTools.Abstractions
{
    public interface IHttpClientService
    {
        Task<Out> GetAsync<Out>(string url, string relative, string token);
        Task<Out> PostAsync<In, Out>(string url, string relative, In objIn, string token);
    }
}