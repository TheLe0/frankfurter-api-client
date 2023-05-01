using Bogus;
using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frankfurter.API.Client.Fixtures.DTO
{
    public static class ExchangeBaseApiResponseFixture
    {
        public static ExchangeBaseApiResponse GenerateForExchangeBaseApiResponse(decimal referenceAmount, CurrencyCode baseCurrency, CurrencyCode toCurrency)
        {
            return new Faker<ExchangeBaseApiResponse>()
                .RuleFor(u => u.Amount, _ => referenceAmount)
                .RuleFor(u => u.Currency, _ => baseCurrency.ToString())
                .RuleFor(u => u.ReferenceDate, (f) => f.Date.Past(1))
                .RuleFor(u => u.StartDate, (f) => f.Date.Past(1))
                .RuleFor(u => u.EndDate, _ => DateTime.Now)
                .RuleFor(u => u.Rates, (f) => GenerateRatesForExchangeBaseApiResponse(f.Random.UInt(1, 100), toCurrency))
                .Generate();
        }

        public static ExchangeBaseApiResponse GenerateForExchangeWithIntervalBaseApiResponse(decimal referenceAmount, CurrencyCode baseCurrency, DateTime startDate, DateTime endDate)
        {
            return new Faker<ExchangeBaseApiResponse>()
                .RuleFor(u => u.Amount, _ => referenceAmount)
                .RuleFor(u => u.Currency, _ => baseCurrency.ToString())
                .RuleFor(u => u.StartDate, _ => startDate)
                .RuleFor(u => u.EndDate, _ => endDate)
                .RuleFor(u => u.Rates, (f) => GenerateRatesWithDateKeyForExchangeBaseApiResponse(
                    f.Date.Past(1),
                    f.Random.UInt(1, 100),
                    (CurrencyCode)f.Random.UInt(1, 30))
                )
                .Generate();
        }

        public static ExchangeBaseApiResponse GenerateForExchangeByDateApiResponse(DateTime referenceDate, decimal referenceAmount, CurrencyCode baseCurrency)
        {
            return new Faker<ExchangeBaseApiResponse>()
                .RuleFor(u => u.Amount, _ => referenceAmount)
                .RuleFor(u => u.Currency, _ => baseCurrency.ToString())
                .RuleFor(u => u.ReferenceDate, _ => referenceDate)
                .RuleFor(u => u.StartDate, (f) => f.Date.Past(1))
                .RuleFor(u => u.EndDate, _ => DateTime.Now)
                .RuleFor(u => u.Rates, (f) => GenerateRatesForExchangeBaseApiResponse(f.Random.UInt(1, 100), (CurrencyCode) f.Random.UInt(1, 30)))
                .Generate();
        }

        public static ExchangeBaseApiResponse GenerateNullResponse()
        {
            return new ExchangeBaseApiResponse
            {
                Amount = decimal.Zero,
                Currency = null,
                ReferenceDate = DateTime.MinValue,
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MinValue,
                Rates = null
            };
        }

        private static JsonObject GenerateRatesWithDateKeyForExchangeBaseApiResponse(DateTime referenceDate, uint randomAmount, CurrencyCode toCurrencyCode)
        {
            var json = new StringBuilder();
            json.Append('{');
            json.Append('"');
            json.Append(referenceDate.ToString("yyyy-MM-dd"));
            json.Append('"');
            json.Append(": ");
            json.Append('{');
            json.Append('"');
            json.Append(toCurrencyCode.ToString());
            json.Append('"');
            json.Append(": ");
            json.Append(randomAmount);
            json.Append('}');
            json.Append('}');

            return JsonSerializer.Deserialize<JsonObject>(json.ToString());
        }

        private static JsonObject GenerateRatesForExchangeBaseApiResponse(uint randomAmount, CurrencyCode toCurrencyCode)
        {
            var json = new StringBuilder();
            json.Append('{');
            json.Append('"');
            json.Append(toCurrencyCode.ToString());
            json.Append('"');
            json.Append(": ");
            json.Append(randomAmount);
            json.Append('}');

            return JsonSerializer.Deserialize<JsonObject>(json.ToString());
        }
    }
}
