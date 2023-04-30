using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Frankfurter.API.Client.DTO.Response
{
    public class ExchangeBaseApiResponse
    {
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("base")]
        public string Currency { get; set; }
        [JsonPropertyName("date")]
        public DateTime ReferenceDate { get; set; }
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("rates")]
        public JsonObject Rates { get; set; }
    }
}
