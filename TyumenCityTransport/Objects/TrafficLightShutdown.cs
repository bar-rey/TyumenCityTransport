using System.Text.Json.Serialization;
using TyumenCityTransport.Converters;

namespace TyumenCityTransport.Objects
{
    public class TrafficLightShutdown
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("traffic_light_id")]
        public int TrafficLightId { get; set; }

        [JsonPropertyName("start")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime Start { get; set; }

        [JsonPropertyName("end")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime End { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
