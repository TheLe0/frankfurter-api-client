using Frankfurter.API.Client.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frankfurter.API.Client.Extensions
{
    internal static class EndpointParameterBuilder
    {
        internal static string ToParameter(this IEnumerable<CurrencyCode> currencies)
        {
            var currenciesStr = new StringBuilder();

            foreach (var currency in currencies)
            {
                if (currency == CurrencyCode.NONE) continue;
                
                currenciesStr.Append(',');
                currenciesStr.Append(currency.ToString());
            }

            return currenciesStr.ToString();
        }

        internal static string DateIntervalToString(DateTime startDate, DateTime? fromDate)
        {
            var dateInterval = new StringBuilder(startDate.ToString("yyyy-MM-dd"));

            dateInterval.Append("..");

            if (fromDate != null)
            {
                dateInterval.Append(fromDate?.ToString("yyyy-MM-dd"));
            }

            return dateInterval.ToString();
        }
    }

}
