﻿using Bogus;
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