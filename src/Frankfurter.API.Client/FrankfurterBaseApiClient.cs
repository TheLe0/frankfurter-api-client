using Flurl;
using Frankfurter.API.Client.Configuration;
using RestSharp;
using System.Threading.Tasks;
using Frankfurter.API.Client.Infrastructure;

namespace Frankfurter.API.Client
{
    public abstract class FrankfurterBaseApiClient
    {
        private readonly IFrankfurterClientHttpClient _httpClient;
        protected readonly Url Endpoint;

        protected FrankfurterBaseApiClient(FrankfurterClientConfiguration configuration)
        {
            _httpClient = new FrankfurterClientHttpClient(configuration);
            Endpoint = _httpClient.GetBaseUrl();
        }

        protected FrankfurterBaseApiClient(string baseUrl)
        {
            _httpClient = new FrankfurterClientHttpClient(baseUrl);
            Endpoint = _httpClient.GetBaseUrl();
        }


        protected FrankfurterBaseApiClient(IFrankfurterClientHttpClient restApiClient)
        {
            _httpClient = restApiClient;
            Endpoint = _httpClient.GetBaseUrl();
        }

        protected FrankfurterBaseApiClient()
        {
            _httpClient = new FrankfurterClientHttpClient();
            Endpoint = _httpClient.GetBaseUrl();
        }

        protected Task<T> GetAsync<T>()
        {
            var restRequest = new RestRequest(Endpoint.ToString());
            RefreshEndpoint();

            return _httpClient.GetAsync<T>(restRequest);
        }

        private void RefreshEndpoint()
        {
            Endpoint.Reset();
        }
    }
}
