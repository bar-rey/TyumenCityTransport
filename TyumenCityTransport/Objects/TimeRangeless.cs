using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class TimeRangeless : Time
    {
        [JsonPropertyName("short_trip")]
        public IEnumerable<string> ShortTrip { get; set; } = null!;

        [JsonPropertyName("very_big_car_times")]
        public IEnumerable<string> VeryBigCarTimes { get; set; } = null!;

        [JsonPropertyName("physically_challenged_support")]
        public IEnumerable<string> PhysicallyChallengedSupport { get; set; } = null!;

        [JsonPropertyName("times")]
        public IEnumerable<string> Times { get; set; } = null!;

        [JsonPropertyName("intervals")]
        public IEnumerable<int>? Intervals { get; set; }
    }
}
