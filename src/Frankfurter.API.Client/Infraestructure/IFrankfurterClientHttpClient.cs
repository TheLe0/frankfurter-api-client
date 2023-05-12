using System.Threading.Tasks;
using RestSharp;

namespace Frankfurter.API.Client.Infraestructure
{
    public interface IFrankfurterClientHttpClient
    {
        Task<T> GetAsync<T>(RestRequest request);
        string GetBaseUrl();
    }
}
