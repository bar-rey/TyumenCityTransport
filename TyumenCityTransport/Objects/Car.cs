using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class Car
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("car_class_id")]
        public int CarClassId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; } = null!;

        [JsonPropertyName("has_air_conditioner")]
        public bool HasAirConditioner { get; set; }

        [JsonPropertyName("has_equipment_for_disabled_persons")]
        public bool HasEquipmentForDisabledPersons { get; set; }
    }
}
