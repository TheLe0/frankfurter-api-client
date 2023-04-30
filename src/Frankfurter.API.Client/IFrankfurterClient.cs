using Frankfurter.API.Client.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public interface IFrankfurterClient
    {
        public Task<IEnumerable<Currency>> GetAllAvaliableCurrenciesAsync();
        public Task<Exchange> CurrencyConvert(decimal amount, CurrencyCode from, CurrencyCode to);
    }
}
