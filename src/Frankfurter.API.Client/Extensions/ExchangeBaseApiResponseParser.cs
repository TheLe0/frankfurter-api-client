using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frankfurter.API.Client.Extensions
{
    internal static class ExchangeBaseApiResponseParser
    {
        internal static Exchange ToExchange(this ExchangeBaseApiResponse apiResponse) 
        {
            return new Exchange
            {
                ReferenceDate = apiResponse.ReferenceDate,
                ReferenceAmount = apiResponse.Amount,
                ReferenceCurrency = apiResponse.Currency.ToCurrencyCode(),
                Rates = apiResponse.Rates.ToCurrencyRateList()
            };
        }

        internal static IEnumerable<Exchange> ToExchangeList(this ExchangeBaseApiResponse apiResponse)
        {
            var exchangeList = new List<Exchange>();
            var listJsonObjs = apiResponse.Rates.ToArray();

            for (var i = 0; i < listJsonObjs.Length; i++)
            {
                exchangeList.Add(
                    new Exchange
                    {
                        ReferenceDate = DateTime.Parse(listJsonObjs[i].Key),
                        ReferenceAmount = apiResponse.Amount,
                        ReferenceCurrency = apiResponse.Currency.ToCurrencyCode(),
                        Rates = listJsonObjs[i].Value.AsObject().ToCurrencyRateList()
                    }
                );
            }

            return exchangeList;
        }
    }
}
