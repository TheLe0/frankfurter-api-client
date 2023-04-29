using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frankfurter.API.Client.Infraestructure
{
    public class FrankfurterClientHttpClient : IFrankfurterClientHttpClient
    {
        private readonly RestClient _client;
        private readonly FrankfurterClientConfiguration _configuration;

        public FrankfurterClientHttpClient(FrankfurterClientConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(GetConfigurations());
        }

        public FrankfurterClientHttpClient(CurrencyCode currency)
        {
            _configuration = new FrankfurterClientConfiguration(currency);
            _client = new RestClient(GetConfigurations());
        }

        public Task<T> GetAsync<T>(string endpoint)
        {
            var fullEndpoint = _configuration.BaseApiUrl
                + endpoint;

            return _client.GetJsonAsync<T>(fullEndpoint);
        }

        private RestClientOptions GetConfigurations()
        {
            return new RestClientOptions(_configuration.BaseApiUrl)
            {
                ThrowOnAnyError = _configuration.ThrowOnAnyError,
                MaxTimeout = _configuration.MaxTimeout
            };
        }
    }
}
