using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;
using Frankfurter.API.Client.Extensions;
using Frankfurter.API.Client.Infraestructure;
using Frankfurter.API.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public class FrankfurterClient : FrankfurterBaseApiClient, IFrankfurterClient
    {
        public FrankfurterClient() : base() { }
        public FrankfurterClient(string baseUrl) : base(baseUrl) { }
        public FrankfurterClient(FrankfurterClientConfiguration configuration) : base(configuration) { }
        public FrankfurterClient(IFrankfurterClientHttpClient restApiClient) : base(restApiClient) { }

        public async Task<IEnumerable<Currency>> GetAllAvaliableCurrenciesAsync()
        {
            var response = await GetAsync<JsonObject>(Routes.CurrencyEndpoint)
                .ConfigureAwait(false);

            if (response == null) return null;

            return response.ToCurrencyList();
        }

        public async Task<Exchange> CurrencyConvertAsync(decimal amount, CurrencyCode from, CurrencyCode to)
        {
            var endpoint = Routes.LatestEndpoint.ConversionEndpointWithParameters(
                amount,
                from,
                to
            );

            var response = await GetAsync<ExchangeBaseApiResponse>(endpoint)
                .ConfigureAwait(false);

            if (response == null) return null;

            return response.ToExchange();
        }

        public async Task<Exchange> CurrencyConvertByDateAsync(DateTime referenceDate, decimal amount, CurrencyCode from)
        {
            var endpoint = Routes.RootEndpoint.ConversionByDateEndpointWithParameters(
                referenceDate,
                amount,
                from
            );

            var response = await GetAsync<ExchangeBaseApiResponse>(endpoint)
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchange();
        }

        public async Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from)
        {
            var endpoint = Routes.LatestEndpoint
                .ConversionEndpointWithParameters(
                amount,
                from,
                CurrencyCode.None
            );

            var response = await GetAsync<ExchangeBaseApiResponse>(endpoint)
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchange();
        }

        public Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to)
        {
            throw new NotImplementedException();
        }
    }
}
