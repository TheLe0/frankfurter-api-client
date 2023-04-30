using Frankfurter.API.Client.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frankfurter.API.Client.Extensions
{
    internal static class EndpointParameterBuilder
    {

        internal static string ConversionEndpointWithParameters(this string endpoint, decimal amount, CurrencyCode from, CurrencyCode to)
        {
            var fullEndPoint = new StringBuilder(endpoint);
            var isFirstParameter = true;

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("amount=" + amount);

            if (from != CurrencyCode.None)
            {
                fullEndPoint.AddParameterSeparator(ref isFirstParameter);
                fullEndPoint.Append("from=" + from.ToString());
            }

            if (to != CurrencyCode.None)
            {
                fullEndPoint.AddParameterSeparator(ref isFirstParameter);
                fullEndPoint.Append("to=" + to.ToString());
            }

            return fullEndPoint.ToString();
        }

        internal static string ConversionEndpointWithParameters(this string endpoint, decimal amount, CurrencyCode from, IEnumerable<CurrencyCode> to)
        {
            var fullEndPoint = new StringBuilder(endpoint);
            var isFirstParameter = true;

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("amount=" + amount);

            if (from != CurrencyCode.None)
            {
                fullEndPoint.AddParameterSeparator(ref isFirstParameter);
                fullEndPoint.Append("from=" + from.ToString());
            }

            var isFirstElement = true;

            foreach (var currency in to)
            {
                if (currency != CurrencyCode.None)
                {
                    if (isFirstElement)
                    {
                        fullEndPoint.AddParameterSeparator(ref isFirstParameter);
                        fullEndPoint.Append("to=");
                        isFirstElement = false;
                    }
                    else
                    {
                        fullEndPoint.Append(',');
                    }

                    fullEndPoint.Append(currency.ToString());
                }
            }

            return fullEndPoint.ToString();
        }

        internal static string ConversionByDateEndpointWithParameters(this string endpoint, DateTime referenceDate, decimal amount, CurrencyCode from)
        {
            var fullEndPoint = new StringBuilder(endpoint);
            var isFirstParameter = true;

            fullEndPoint.Append(referenceDate.ToString("yyyy-MM-dd"));

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("amount=" + amount);

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("from=" + from.ToString());

            return fullEndPoint.ToString();
        }

        private static void AddParameterSeparator(this StringBuilder parameter, ref bool isFirstParameter)
        {
            if (isFirstParameter)
            {
                parameter.Append('?');

                isFirstParameter = false;
            }
            else
            {
                parameter.Append('&');
            }
        }
    }
}
