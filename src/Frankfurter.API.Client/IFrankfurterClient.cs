using Frankfurter.API.Client.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public interface IFrankfurterClient
    {
        Task<IEnumerable<Currency>> GetAllAvailableCurrenciesAsync();
        Task<Exchange> CurrencyConvertAsync(decimal amount, CurrencyCode from, CurrencyCode to);
        Task<Exchange> CurrencyConvertByDateAsync(DateTime referenceDate, decimal amount, CurrencyCode from);
        Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from);
        Task<Exchange> CurrencyConvertByLastPublishedDateAsync(decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to);
        Task<IEnumerable<Exchange>> CurrencyConvertByDateIntervalAsync(decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to, DateTime startDate, DateTime? endDate = null);
    }
}
