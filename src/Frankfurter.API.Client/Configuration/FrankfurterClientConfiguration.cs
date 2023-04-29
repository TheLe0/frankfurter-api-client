using Frankfurter.API.Client.Resources;

namespace Frankfurter.API.Client.Configuration
{
    public class FrankfurterClientConfiguration
    {
        public string BaseApiUrl { get; set; }
        public bool ThrowOnAnyError { get; set; }
        public int MaxTimeout { get; set; }

        public FrankfurterClientConfiguration(string baseUrl)
        {
            BaseApiUrl = baseUrl;

            SetupDefaultConfigs();
        }

        public FrankfurterClientConfiguration()
        {
            BaseApiUrl = Routes.BaseUrl;

            SetupDefaultConfigs();
        }

        private void SetupDefaultConfigs()
        {
            MaxTimeout = 10000;
            ThrowOnAnyError = true;
        }
    }
}
