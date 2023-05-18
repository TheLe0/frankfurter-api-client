using Frankfurter.API.Client;
using Frankfurter.API.Client.Domain;

var frankfurter = new FrankfurterClient();

// Get All available currencies
var currencies = await frankfurter
    .GetAllAvailableCurrenciesAsync()
    .ConfigureAwait(false);

// Convert a specified amount of one currency to another

var exchange = await frankfurter
    .CurrencyConvertAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        CurrencyCode.USD // Currency to Convert
    ).ConfigureAwait(false);

// Get the currency equivalency amount of one currency in a date

exchange = await frankfurter
    .CurrencyConvertByDateAsync(
        DateTime.UtcNow, // Reference Date
        10, // Reference Amount
        CurrencyCode.BRL // Reference Currency
    ).ConfigureAwait(false);

//  Get the currency equivalency amount of one currency in the last published date

exchange = await frankfurter
    .CurrencyConvertByLastPublishedDateAsync(
        10, // Reference Amount
        CurrencyCode.BRL // Reference Currency
    ).ConfigureAwait(false);

//  Get the currency equivalency amount of one currency in the last published date
// with specified currencies to convert

var toCurrencies = new List<CurrencyCode>
{
    CurrencyCode.EUR,
    CurrencyCode.USD
};

exchange = await frankfurter
    .CurrencyConvertByLastPublishedDateAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        toCurrencies // Currencies to convert
    ).ConfigureAwait(false);

// Get the equivalent of one currency in a specific
// date interval

var exchanges = await frankfurter
    .CurrencyConvertByDateIntervalAsync(
        10, // Reference Amount
        CurrencyCode.BRL, // Reference Currency
        toCurrencies, // Currencies to convert
        new DateTime(2020,1,1), // Start date
        new DateTime(2021,1,1) // End Date
    ).ConfigureAwait(false);

Console.WriteLine("Finish Execution!");
