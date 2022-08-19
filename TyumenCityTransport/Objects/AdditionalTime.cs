using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    /// <summary>
    /// Дополнительные рейсы общественного транспорта
    /// </summary>
    public class AdditionalTime
    {
        [JsonPropertyName("forward")]
        public bool? IsForward { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("times")]
        public IEnumerable<string> Times { get; set; } = null!;
    }
}
