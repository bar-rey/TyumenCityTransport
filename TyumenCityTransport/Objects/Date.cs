using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    // Метод Dates возвращает массив объектов, поэтому использую это чудо
    internal class Date
    {
        [JsonPropertyName("date")]
        public DateTime DateTime { get; set; }
    }
}
