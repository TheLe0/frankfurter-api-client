using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Extensions;
using Frankfurter.API.Client.Infraestructure;
using Frankfurter.API.Client.Resources;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public class FrankfurterClient : FrankfurterBaseApiClient, IFrankfurterClient
    {
        public FrankfurterClient() : base() { }
        public FrankfurterClient(FrankfurterClientConfiguration configuration) : base(configuration) { }
        public FrankfurterClient(IFrankfurterClientHttpClient restApiClient) : base(restApiClient) { }

        public async Task<IEnumerable<Currency>> GetAllAvaliableCurrenciesAsync()
        {
            var response = await GetAsync<JsonObject>(Routes.CurrencyEndpoint)
                .ConfigureAwait(false);

            if (response == null) return null;

            return response.ToCurrencyList();
        }
    }
}
