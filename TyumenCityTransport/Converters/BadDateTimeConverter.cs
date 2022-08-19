using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TyumenCityTransport.Converters
{
    public class BadDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateTime.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }
}
