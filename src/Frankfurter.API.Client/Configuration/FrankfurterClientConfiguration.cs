using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Resources;

namespace Frankfurter.API.Client.Configuration
{
    public class FrankfurterClientConfiguration
    {
        public string BaseApiUrl { get; set; }
        public CurrencyCode DefaultCurrency { get; set; }
        public bool ThrowOnAnyError { get; set; }
        public int MaxTimeout { get; set; }

        public FrankfurterClientConfiguration(string baseUrl, CurrencyCode defaultCurrency)
        {
            BaseApiUrl = baseUrl;
            DefaultCurrency = defaultCurrency;

            SetupDefaultConfigs();
        }

        public FrankfurterClientConfiguration(CurrencyCode defaultCurrency)
        {
            BaseApiUrl = Routes.BaseUrl;
            DefaultCurrency = defaultCurrency;

            SetupDefaultConfigs();
        }

        private void SetupDefaultConfigs()
        {
            MaxTimeout = 10000;
            ThrowOnAnyError = true;
        }
    }
}
