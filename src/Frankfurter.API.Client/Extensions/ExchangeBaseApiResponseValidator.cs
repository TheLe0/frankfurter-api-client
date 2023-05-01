using Frankfurter.API.Client.DTO.Response;
using System;

namespace Frankfurter.API.Client.Extensions
{
    internal static class ExchangeBaseApiResponseValidator
    {
        internal static bool IsNull(this ExchangeBaseApiResponse exchangeBaseApiResponse)
        {
            if (exchangeBaseApiResponse == null) return true;
            if (exchangeBaseApiResponse.Rates == null) return true;
            if (exchangeBaseApiResponse.Amount == decimal.Zero) return true;
            if (exchangeBaseApiResponse.Currency == null) return true;

            return false;
        }
    }
}
