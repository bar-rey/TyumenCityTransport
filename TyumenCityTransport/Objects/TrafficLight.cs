using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class TrafficLight
    {
        /// <summary>
        /// Идентификатор светофора
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название светофора
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Режим работы светофора
        /// </summary>
        [JsonPropertyName("operating_mode")]
        public string OperatingMode { get; set; } = null!;

        /// <summary>
        /// Широта местоположения светофора
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота местоположения светофора
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Выключен ли светофор
        /// </summary>
        [JsonPropertyName("shutdown")]
        public bool Shutdown { get; set; }
    }
}
