using System.Text.Json.Serialization;

namespace TyumenCityTransport
{
    public class Response<T>
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("objects")]
        public IEnumerable<T> Objects { get; set; } = null!;

        [JsonPropertyName("success")]
        public bool? Success { get; set; } = null;
    }
}