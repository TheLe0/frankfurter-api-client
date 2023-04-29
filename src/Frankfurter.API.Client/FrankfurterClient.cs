using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public class FrankfurterClient : FrankfurterBaseApiClient, IFrankfurterClient
    {
        public FrankfurterClient(CurrencyCode currency) : base(currency) { }
        public FrankfurterClient(FrankfurterClientConfiguration configuration) : base(configuration) { }
        public FrankfurterClient(IFrankfurterClientHttpClient restApiClient) : base(restApiClient) { }
    }
}
