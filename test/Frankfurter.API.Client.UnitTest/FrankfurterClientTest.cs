using Frankfurter.API.Client.Fixtures.Core;
using Frankfurter.API.Client.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

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
            Assert.True(currencies.Count() > 0);
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
    }
}
