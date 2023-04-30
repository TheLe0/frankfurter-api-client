using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frankfurter.API.Client
{
    public interface IFrankfurterClient
    {
        public Task<IEnumerable<Currency>> GetAllAvaliableCurrenciesAsync();
        public Task<Exchange> CurrencyConvert(decimal amount, CurrencyCode from, CurrencyCode to);
    }
}
