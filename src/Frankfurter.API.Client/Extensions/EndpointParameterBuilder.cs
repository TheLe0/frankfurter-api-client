using Frankfurter.API.Client.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Frankfurter.API.Client.Extensions
{
    internal static class EndpointParameterBuilder
    {
        internal static string ToString(this IEnumerable<CurrencyCode> currencies)
        {
            var currenciesStr = new StringBuilder();
            var isFirstRow = true;

            foreach (var currency in currencies)
            {
                if (currency != CurrencyCode.None)
                {
                    if (isFirstRow)
                    {
                        currenciesStr.Append(',');
                    }
                    else
                    {
                        isFirstRow = false;
                    }

                    currenciesStr.Append(currency.ToString());
                }
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
