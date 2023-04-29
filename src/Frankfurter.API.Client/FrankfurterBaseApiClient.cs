using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Infraestructure;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public abstract class FrankfurterBaseApiClient
    {
        private readonly IFrankfurterClientHttpClient _httpClient;

        protected FrankfurterBaseApiClient(FrankfurterClientConfiguration configuration)
        {
            _httpClient = new FrankfurterClientHttpClient(configuration);
        }

        protected FrankfurterBaseApiClient(IFrankfurterClientHttpClient restApiClient)
        {
            _httpClient = restApiClient;
        }

        protected FrankfurterBaseApiClient()
        {
            _httpClient = new FrankfurterClientHttpClient();
        }

        protected Task<T> GetAsync<T>(string endpoint)
        {
            return _httpClient.GetAsync<T>(endpoint);
        }
    }
}
