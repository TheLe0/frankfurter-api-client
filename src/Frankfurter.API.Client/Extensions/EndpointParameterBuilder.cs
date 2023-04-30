using Frankfurter.API.Client.Domain;
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

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("from=" + from.ToString());

            fullEndPoint.AddParameterSeparator(ref isFirstParameter);
            fullEndPoint.Append("to=" + to.ToString());

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
