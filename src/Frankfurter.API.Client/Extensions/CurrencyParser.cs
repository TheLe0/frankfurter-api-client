using Frankfurter.API.Client.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;

namespace Frankfurter.API.Client.Extensions
{
    internal static class CurrencyParser
    {
        internal static IEnumerable<Currency> ToCurrencyList(this JsonObject jsonObject)
        {
            var currencies = new List<Currency>();

            var listJsonObjs = jsonObject.ToArray();

            for ( var i = 0; i < listJsonObjs.Length; i++)
            {
                currencies.Add(
                    new Currency
                    {
                        Name = listJsonObjs[i].Value.ToString(),
                        Code = listJsonObjs[i].Key.ToString().ToCurrencyCode()
                    }
                ); 
            }

            return currencies;
        }

        internal static IEnumerable<CurrencyRate> ToCurrencyRateList(this JsonObject jsonObject)
        {
            var currencies = new List<CurrencyRate>();

            var listJsonObjs = jsonObject.ToArray();

            for (var i = 0; i < listJsonObjs.Length; i++)
            {
                currencies.Add(
                    new CurrencyRate
                    {
                        Amount = (decimal) listJsonObjs[i].Value,
                        CurrencyCode = listJsonObjs[i].Key.ToCurrencyCode()
                    }
                );
            }

            return currencies;
        }
    }
}
