using Bogus.DataSets;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;
using Frankfurter.API.Client.Fixtures.Core;
using Frankfurter.API.Client.Fixtures.DTO;
using Frankfurter.API.Client.Infraestructure;
using System.Text.Json.Nodes;

namespace Frankfurter.API.Client.UnitTest
{
    public class FrankfurterClientTest
    {
        private readonly IFrankfurterClient _client;
        private readonly Mock<IFrankfurterClientHttpClient> _mockHttpClient;

        public FrankfurterClientTest()
        {
            _mockHttpClient = new Mock<IFrankfurterClientHttpClient>();
            _client = new FrankfurterClient(_mockHttpClient.Object);
        }

        [Fact]
        public async void GetAllAvaliableCurrenciesAsync_Success()
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<JsonObject>(It.IsAny<string>()))
                .ReturnsAsync(JsonObjectFixture.GenerateCurrenciesJsonObject());

            var currencies = await _client.GetAllAvaliableCurrenciesAsync();

            Assert.NotNull(currencies);
            Assert.NotEmpty(currencies);
            Assert.True(currencies.Any());
        }

        [Fact]
        public async void GetAllAvaliableCurrenciesAsync_Fail_NullResponse()
        {
            _mockHttpClient.Setup(_ =>
                _.GetAsync<JsonObject>(It.IsAny<string>()))
                .ReturnsAsync((JsonObject)null);

            var currencies = await _client.GetAllAvaliableCurrenciesAsync();

            Assert.Null(currencies);
        }

        [InlineData(1, 3, 9)]
        [InlineData(10, 9, 7)]
        [InlineData(1, 3, 30)]
        [InlineData(7, 30, 3)]
        [InlineData(15.67, 4, 30)]
        [Theory]
        public async void CurrencyConvert_Success(decimal amount, int baseCurrency, int conversionCurrency)
        {
            var fromCurrency = (CurrencyCode) baseCurrency;
            var toCurrency = (CurrencyCode) conversionCurrency;

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture
                .GenerateForExchangeBaseApiResponse(amount, fromCurrency, toCurrency));

            var exchange = await _client
                .CurrencyConvertAsync(amount, fromCurrency, toCurrency);

            Assert.NotNull(exchange);
            Assert.Equal(exchange.ReferenceAmount, amount);
            Assert.Equal(exchange.ReferenceCurrency, fromCurrency);
            Assert.NotEmpty(exchange.Rates);
        }

        [InlineData(1, 3, 9)]
        [InlineData(10, 9, 7)]
        [InlineData(1, 3, 30)]
        [InlineData(7, 30, 3)]
        [InlineData(15.67, 4, 30)]
        [Theory]
        public async void CurrencyConvert_Fail_NullResponse(decimal amount, int baseCurrency, int conversionCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;
            var toCurrency = (CurrencyCode)conversionCurrency;


            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync((ExchangeBaseApiResponse) null);

            var exchange = await _client
                .CurrencyConvertAsync(amount, fromCurrency, toCurrency);

            Assert.Null(exchange);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15.67, 4)]
        [Theory]
        public async void CurrencyConvertByDate_Success(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;
            var referenceDate = new DateTime(2014, 1, 1);

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture
                .GenerateForExchangeByDateApiResponse(referenceDate, amount, fromCurrency));

            var exchange = await _client
                .CurrencyConvertByDateAsync(referenceDate, amount, fromCurrency);

            Assert.NotNull(exchange);
            Assert.Equal(exchange.ReferenceAmount, amount);
            Assert.Equal(exchange.ReferenceCurrency, fromCurrency);
            Assert.NotEmpty(exchange.Rates);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15, 4)]
        [Theory]
        public async void CurrencyConvertByDate_Fail_NullResponse(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;
            var referenceDate = new DateTime(2014, 1, 1);

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync((ExchangeBaseApiResponse)null);

            var exchange = await _client
                .CurrencyConvertByDateAsync(referenceDate, amount, fromCurrency);

            Assert.Null(exchange);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15, 4)]
        [Theory]
        public async void CurrencyConvertByLastPublishedDateAsync_Success(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture
                .GenerateForExchangeBaseApiResponse(amount, fromCurrency, CurrencyCode.USD));

            var exchange = await _client
                .CurrencyConvertByLastPublishedDateAsync(amount, fromCurrency);

            Assert.NotNull(exchange);
            Assert.Equal(exchange.ReferenceAmount, amount);
            Assert.Equal(exchange.ReferenceCurrency, fromCurrency);
            Assert.NotEmpty(exchange.Rates);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15, 4)]
        [Theory]
        public async void CurrencyConvertByLastPublishedDateAsync_Fail_NullResponse(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;
            var referenceDate = new DateTime(2014, 1, 1);

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture.GenerateNullResponse());

            var exchange = await _client
                .CurrencyConvertByLastPublishedDateAsync(amount, fromCurrency);

            Assert.Null(exchange);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15, 4)]
        [Theory]
        public async void CurrencyConvertByLastPublishedDateAsync_WithToList_Success(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;

            var toCurrencies = new List<CurrencyCode>
            {
                CurrencyCode.EUR,
                CurrencyCode.USD
            };

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture
                .GenerateForExchangeBaseApiResponse(amount, fromCurrency, CurrencyCode.USD));

            var exchange = await _client
                .CurrencyConvertByLastPublishedDateAsync(amount, fromCurrency, toCurrencies);

            Assert.NotNull(exchange);
            Assert.Equal(exchange.ReferenceAmount, amount);
            Assert.Equal(exchange.ReferenceCurrency, fromCurrency);
            Assert.NotEmpty(exchange.Rates);
        }

        [InlineData(1, 3)]
        [InlineData(10, 9)]
        [InlineData(1, 13)]
        [InlineData(7, 30)]
        [InlineData(15, 4)]
        [Theory]
        public async void CurrencyConvertByLastPublishedDateAsync_WithToList_Fail_NullResponse(decimal amount, int baseCurrency)
        {
            var fromCurrency = (CurrencyCode)baseCurrency;

            var toCurrencies = new List<CurrencyCode>
            {
                CurrencyCode.EUR,
                CurrencyCode.USD
            };

            _mockHttpClient.Setup(_ =>
                _.GetAsync<ExchangeBaseApiResponse>(It.IsAny<string>()))
                .ReturnsAsync(ExchangeBaseApiResponseFixture.GenerateNullResponse());

            var exchange = await _client
                .CurrencyConvertByLastPublishedDateAsync(amount, fromCurrency, toCurrencies);

            Assert.Null(exchange);
        }
    }
}
