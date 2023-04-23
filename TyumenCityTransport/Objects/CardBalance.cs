using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class CardBalance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tdk")]
        public string Tdk { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("ltype")]
        public string Ltype { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("series")]
        public int Series { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("card_um")]
        public string CardUm { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exemption_balance")]
        public int ExemptionBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exemption_limit")]
        public int ExemptionLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("resultCode")]
        public int ResultCode { get; set; }
        /// <summary>
        /// Текущий баланс
        /// </summary>
        [JsonPropertyName("balance")]
        public float Balance { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; } = null!;
        /// <summary>
        /// ID карты
        /// </summary>
        [JsonPropertyName("card")]
        public string Card { get; set; } = null!;
        /// <summary>
        /// История поездок
        /// </summary>
        [JsonPropertyName("history")]
        public IEnumerable<CardBalanceHistory> History { get; set; } = null!;
    }
}
