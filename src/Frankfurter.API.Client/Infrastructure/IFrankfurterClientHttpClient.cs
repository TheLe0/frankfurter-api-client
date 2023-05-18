using System.Threading.Tasks;
using RestSharp;

namespace Frankfurter.API.Client.Infrastructure
{
    public interface IFrankfurterClientHttpClient
    {
        Task<T> GetAsync<T>(RestRequest request);
        string GetBaseUrl();
    }
}
