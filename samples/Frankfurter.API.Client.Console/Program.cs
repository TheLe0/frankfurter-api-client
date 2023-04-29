using Frankfurter.API.Client;
using Frankfurter.API.Client.Domain;

var frankfurter = new FrankfurterClient(CurrencyCode.BRL);

var currencies = await frankfurter.GetAllAvaliableCurrenciesAsync().ConfigureAwait(false);

Console.WriteLine("Finish Execution!");
