using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public abstract class Time
    {
        /// <summary>
        /// Прямой ли маршрут (едет в сторону конечной или обратно)
        /// </summary>
        [JsonPropertyName("is_forward")]
        public bool IsForward { get; set; }

        /// <summary>
        /// Предыдущие остановки маршрута
        /// </summary>
        /// <value>
        /// Скорее всего всегда содержит только один элемент
        /// </value>
        [JsonPropertyName("prev_cps")]
        public IEnumerable<int> PreviousCheckpoints { get; set; } = null!;

        /// <summary>
        /// Дополнительные рейсы маршрута 
        /// </summary>
        [JsonPropertyName("dop_times")]
        public Dictionary<string, AdditionalTime> AdditionalTimes { get; set; } = null!;

        /// <summary>
        /// ?Основной ли маршрут?
        /// Не знаю, что это из себя представляет
        /// </summary>
        [JsonPropertyName("is_primary")]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Следующие остановки маршрута
        /// </summary>
        /// <value>
        /// Скорее всего всегда содержит только один элемент
        /// </value>
        [JsonPropertyName("next_cps")]
        public IEnumerable<int> NextCheckpoints { get; set; } = null!;

        /// <summary>
        /// Направление маршрута
        /// </summary>
        /// <value>
        /// Начальная остановка - конечная остановка
        /// </value>
        [JsonPropertyName("direction")]
        public string? Direction { get; set; }

        /// <summary>
        /// Текущая остановка маршрута
        /// </summary>
        /// <value>
        /// Объект Checkpoint с указанным идентификатором остановки и её названием
        /// </value>
        [JsonPropertyName("checkpoint")]
        public Checkpoint Checkpoint { get; set; } = null!;

        /// <summary>
        /// Идентификатор маршрута
        /// </summary>
        [JsonPropertyName("route_id")]
        public int RouteId { get; set; }

        /// <summary>
        /// Закончился ли маршрут
        /// </summary>
        [JsonPropertyName("is_end")]
        public bool IsEnd { get; set; }

        /// <summary>
        /// Место остановки в списке остановок маршрута
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }
    }
}
