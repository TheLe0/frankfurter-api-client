using Frankfurter.API.Client;
using Frankfurter.API.Client.Domain;

var frankfurter = new FrankfurterClient();

var currencies = await frankfurter
    .CurrencyConvert(5, CurrencyCode.BRL, CurrencyCode.USD)
    .ConfigureAwait(false);

Console.WriteLine("Finish Execution!");
