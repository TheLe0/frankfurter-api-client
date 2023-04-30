using System;
using System.Collections.Generic;

namespace Frankfurter.API.Client.Domain
{
    public class Exchange
    {
        public DateTime ReferenceDate { get; set; }
        public decimal ReferenceAmount { get; set; }
        public CurrencyCode ReferenceCurrency { get; set; }
        public IEnumerable<CurrencyRate> Rates { get; set; }
    }
}
