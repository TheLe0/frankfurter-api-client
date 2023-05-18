using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;
using Frankfurter.API.Client.Extensions;
using Frankfurter.API.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Frankfurter.API.Client.Infrastructure;

namespace Frankfurter.API.Client
{
    public class FrankfurterClient : FrankfurterBaseApiClient, IFrankfurterClient
    {
        public FrankfurterClient() : base() { }
        public FrankfurterClient(string baseUrl) : base(baseUrl) { }
        public FrankfurterClient(FrankfurterClientConfiguration configuration) : base(configuration) { }
        public FrankfurterClient(IFrankfurterClientHttpClient restApiClient) : base(restApiClient) { }

        public async Task<IEnumerable<Currency>> GetAllAvailableCurrenciesAsync()
        {
            Endpoint.AppendPathSegment(Routes.CurrencyEndpoint);

            var response = await GetAsync<JsonObject>()
                .ConfigureAwait(false);

            if (response == null) return null;

            return response.ToCurrencyList();
        }

        public async Task<Exchange> CurrencyConvertAsync(decimal amount, CurrencyCode from, CurrencyCode to)
        {
            Endpoint.AppendPathSegment(Routes.LatestEndpoint);

            if (amount > decimal.Zero) Endpoint.SetQueryParam("amount", amount);
            if (from != CurrencyCode.NONE) Endpoint.SetQueryParam("from", from.ToString());
            if (to != CurrencyCode.NONE) Endpoint.SetQueryParam("to", to.ToString());

            var response = await GetAsync<ExchangeBaseApiResponse>()
                .ConfigureAwait(false);

            if (response == null) return null;

            return response.ToExchange();
        }

        public async Task<Exchange> CurrencyConvertByDateAsync(DateTime referenceDate, decimal amount, CurrencyCode from)
        {
            Endpoint.AppendPathSegment(Routes.RootEndpoint);
            Endpoint.AppendPathSegment(referenceDate.ToString("yyyy-MM-dd"));

            if (amount > decimal.Zero) Endpoint.SetQueryParam("amount", amount);
            if (from != CurrencyCode.NONE) Endpoint.SetQueryParam("from", from.ToString());

            var response = await GetAsync<ExchangeBaseApiResponse>()
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchange();
        }

        public async Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from)
        {
            Endpoint.AppendPathSegment(Routes.LatestEndpoint);

            if (amount > decimal.Zero) Endpoint.SetQueryParam("amount", amount);
            if (from != CurrencyCode.NONE) Endpoint.SetQueryParam("from", from.ToString());

            var response = await GetAsync<ExchangeBaseApiResponse>()
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchange();
        }

        public async Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to)
        {
            Endpoint.AppendPathSegment(Routes.LatestEndpoint);

            if (amount > decimal.Zero) Endpoint.SetQueryParam("amount", amount);
            if (from != CurrencyCode.NONE) Endpoint.SetQueryParam("from", from.ToString());
            if (to != null) Endpoint.SetQueryParam("to", to.ToParameter());


            var response = await GetAsync<ExchangeBaseApiResponse>()
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchange();
        }

        public async Task<IEnumerable<Exchange>> CurrencyConvertByDateIntervalAsync(decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to, DateTime startDate, DateTime? endDate = null)
        {
            Endpoint.AppendPathSegment(Routes.RootEndpoint);

            Endpoint.AppendPathSegment(
                EndpointParameterBuilder.DateIntervalToString(startDate, endDate)
            );

            if (amount > decimal.Zero) Endpoint.SetQueryParam("amount", amount);
            if (from != CurrencyCode.NONE) Endpoint.SetQueryParam("from", from.ToString());
            if (to != null) Endpoint.SetQueryParam("to", to.ToParameter());

            var response = await GetAsync<ExchangeBaseApiResponse>()
                .ConfigureAwait(false);

            if (response.IsNull()) return null;

            return response.ToExchangeList();
        }
    }
}
