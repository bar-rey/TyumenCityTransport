using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class TimeRanged : Time
    {
        [JsonPropertyName("short_trip")]
        public Dictionary<string, IEnumerable<string>> ShortTrip { get; set; } = null!;

        [JsonPropertyName("very_big_car_times")]
        public Dictionary<string, IEnumerable<string>> VeryBigCarTimes { get; set; } = null!;
        
        [JsonPropertyName("physically_challenged_support")]
        public Dictionary<string, IEnumerable<string>> PhysicallyChallengedSupport { get; set; } = null!;

        [JsonPropertyName("times")]
        public Dictionary<string, IEnumerable<string>> Times { get; set; } = null!;

        [JsonPropertyName("intervals")]
        public Dictionary<string, IEnumerable<int>?>? Intervals { get; set; }
    }
}
