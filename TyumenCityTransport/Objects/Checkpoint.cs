using System.Text.Json.Serialization;

namespace TyumenCityTransport.Objects
{
    public class Checkpoint
    {
        /// <summary>
        /// Идентификатор остановки
        /// </summary>
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Название остановки
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Описание остановки
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Нечто из метода Checkpoint
        /// </summary>
        [JsonPropertyName("heading")]
        public int? Heading { get; set; }

        /// <summary>
        /// Координаты остановки из метода CheckpointsForSearch
        /// Сохраняет широту в свойство Latitude, а долготу в свойство Longitude
        /// </summary>
        /// <value>
        /// Дублирует Latitude и Longitude
        /// Перечисляемый тип, в котором первым элементом является долгота, а вторым широта
        /// </value>
        [JsonPropertyName("coordinate")]
        public IEnumerable<double>? Coordinate
        {
            get
            {
                if (Latitude != null && Longitude != null)
                    return new double[] { (double)Longitude, (double)Latitude };
                return null;
            }
            set
            {
                if (value != null && value.Count() == 2) 
                {
                    double[] coord = value.ToArray();
                    Longitude = coord[0];
                    Latitude = coord[1];
                }
            }
        }

        /// <summary>
        /// Широта местоположения остановки
        /// </summary>
        [JsonPropertyName("lat")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Долгота местоположения остановки
        /// </summary>
        [JsonPropertyName("lon")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Некая широта из метода Checkpoint.. Может быть для отображения на карте?
        /// </summary>
        [JsonPropertyName("projected_lat")]
        public double? ProjectedLatitude { get; set; }

        /// <summary>
        /// Некая долгота из метода Checkpoint.. Может быть для отображения на карте?
        /// </summary>
        [JsonPropertyName("projected_lon")]
        public double? ProjectedLongitude { get; set; }

        /// <summary>
        /// Код, отображаемый на сайте и остановках
        /// </summary>
        [JsonPropertyName("code_number")]
        public string? CodeNumber { get; set; }

        /// <summary>
        /// Даты из метода CheckpointsForSearch, в которые на данной остановке останавливается общественный транспорт
        /// </summary>
        [JsonPropertyName("dates")]
        public IEnumerable<DateTime>? Dates { get; set; }

        /// <summary>
        /// Идентификаторы маршрутов общественного транспорта, проходящих через данную остановку
        /// </summary>
        [JsonPropertyName("routes")]
        public IEnumerable<int>? RoutesIds { get; set; }

        /// <summary>
        /// Полученные методом Checkpoint идентификаторы маршрутов
        /// Сохраняет значение в RoutesIds
        /// </summary>
        /// <value>
        /// Всегда дублирует RoutesIds
        /// </value>
        [JsonPropertyName("routes_ids")]
        public IEnumerable<int>? RoutesIdsAlternative { get { return RoutesIds; } set { RoutesIds = value; } }
    }
}
