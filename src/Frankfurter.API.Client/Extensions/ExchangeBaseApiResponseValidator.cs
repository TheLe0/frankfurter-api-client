using Frankfurter.API.Client.DTO.Response;

namespace Frankfurter.API.Client.Extensions
{
    internal static class ExchangeBaseApiResponseValidator
    {
        internal static bool IsNull(this ExchangeBaseApiResponse exchangeBaseApiResponse)
        {
            if (exchangeBaseApiResponse?.Rates == null) return true;
            if (exchangeBaseApiResponse.Amount == decimal.Zero) return true;
            return exchangeBaseApiResponse.Currency == null;
        }
    }
}
