using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

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
