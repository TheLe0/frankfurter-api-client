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
            var listJsonObjs = jsonObject.ToArray();

            return listJsonObjs.Select(node 
                => new Currency
                {
                    Name = node.Value.ToString(), 
                    Code = node.Key.ToString().ToCurrencyCode()
                }).ToList();
        }

        internal static IEnumerable<CurrencyRate> ToCurrencyRateList(this JsonObject jsonObject)
        {
            var listJsonObjs = jsonObject.ToArray();

            return listJsonObjs.Select(node 
                => new CurrencyRate
                {
                    Amount = (decimal) node.Value, 
                    CurrencyCode = node.Key.ToCurrencyCode()
                }).ToList();
        }
    }
}
