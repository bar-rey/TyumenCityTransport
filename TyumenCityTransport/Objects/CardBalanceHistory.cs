using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TyumenCityTransport.Converters;

namespace TyumenCityTransport.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class CardBalanceHistory
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sum")]
        public float Sum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("agent")]
        public string Agent { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exemption_balance")]
        public int ExemptionBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("balance")]
        public float Balance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tariff")]
        public float Tariff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("route")]
        public string Route { get; set; } = null!;
    }
}
