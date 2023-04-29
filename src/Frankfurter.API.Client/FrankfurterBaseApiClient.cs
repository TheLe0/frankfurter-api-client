using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Infraestructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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

        protected FrankfurterBaseApiClient(CurrencyCode currency)
        {
            _httpClient = new FrankfurterClientHttpClient(currency);
        }
    }
}
