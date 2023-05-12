using Flurl;
using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Infraestructure;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

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
