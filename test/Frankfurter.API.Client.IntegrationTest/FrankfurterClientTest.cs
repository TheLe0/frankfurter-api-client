using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Domain;

namespace Frankfurter.API.Client.IntegrationTest
{
    public class FrankfurterClientTest
    {
        private readonly IFrankfurterClient _client;
        private const string _wrongBaseUrl = "http://localhost:4200";

        public FrankfurterClientTest()
        {
            _client = new FrankfurterClient();
        }

        [Fact]
        public async void GetAllAvaliableCurrenciesAsync_Success()
        {
            var currencies = await _client.GetAllAvaliableCurrenciesAsync();

            Assert.NotNull(currencies);
            Assert.NotEmpty(currencies);
            Assert.True(currencies.Any());
        }

        [Fact]
        public async void GetAllAvaliableCurrenciesAsync_Fail_Timeout()
        {
            var configuration = new FrankfurterClientConfiguration
            {
                BaseApiUrl = _wrongBaseUrl,
                MaxTimeout = 1,
                ThrowOnAnyError = true
            };

            var client = new FrankfurterClient(configuration);

            Func<Task> act = () => client.GetAllAvaliableCurrenciesAsync();

            await Assert.ThrowsAsync<TimeoutException>(act);
        }

        [InlineData(1, 3, 9)]
        [InlineData(10, 9, 7)]
        [InlineData(1, 3, 30)]
        [InlineData(7, 30, 3)]
        [InlineData(15, 4, 30)]
        [Theory]
        public async void CurrencyConvert_Success(decimal amount, int baseCurrency, int conversionCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;
            var toCurrency = (CurrencyCode)conversionCurrency;

            var exchange = await _client
                .CurrencyConvertAsync(amount, fromCurrency, toCurrency);

            Assert.NotNull(exchange);
            Assert.Equal(exchange.ReferenceAmount, amount);
            Assert.Equal(exchange.ReferenceCurrency, fromCurrency);
            Assert.NotEmpty(exchange.Rates);
        }
    }
}