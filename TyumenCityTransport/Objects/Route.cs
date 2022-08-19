using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class Route
    {
        /// <summary>
        /// Идентификатор маршрута
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Название маршрута
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Описание маршрута (начальная и конечная остановка)
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Когда маршрут стал активным
        /// </summary>
        [JsonPropertyName("active_from")]
        public DateTime? ActiveFrom { get; set; }

        /// <summary>
        /// Когда маршрут перестанет быть активным
        /// </summary>
        [JsonPropertyName("active_to")]
        public DateTime? ActiveTo { get; set; }

        /// <summary>
        /// Новый ли маршрут
        /// </summary>
        [JsonPropertyName("new")]
        public bool? New { get; set; }

        /// <summary>
        /// Устаревший ли маршрут
        /// </summary>
        [JsonPropertyName("outdated")]
        public bool? Outdated { get; set; }

        /// <summary>
        /// Даты, в которые маршрут курсирует 
        /// </summary>
        [JsonPropertyName("dates")]
        public IEnumerable<DateTime>? Dates { get; set; }

        /// <summary>
        /// Идентификаторы остановок маршрута
        /// </summary>
        [JsonPropertyName("checkpoints")]
        public IEnumerable<int>? CheckpointsIds { get; set; }

        /// <summary>
        /// Полученные методом Route остановки маршрута
        /// Сохраняет значение в CheckpointsIds
        /// </summary>
        /// <value>
        /// Всегда дублирует CheckpointsIds
        /// </value>
        [JsonPropertyName("checkpoints_ids")]
        public IEnumerable<int>? CheckpointsIdsAlternative { get { return CheckpointsIds; } set { CheckpointsIds = value; } }
    }
}
