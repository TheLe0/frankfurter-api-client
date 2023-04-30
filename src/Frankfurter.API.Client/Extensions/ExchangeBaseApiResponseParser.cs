using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.DTO.Response;

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
    }
}
