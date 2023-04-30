using Frankfurter.API.Client.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public interface IFrankfurterClient
    {
        Task<IEnumerable<Currency>> GetAllAvaliableCurrenciesAsync();
        Task<Exchange> CurrencyConvertAsync(decimal amount, CurrencyCode from, CurrencyCode to);
        Task<Exchange> CurrencyConvertByDateAsync(DateTime referenceDate, decimal amount, CurrencyCode from);
    }
}
