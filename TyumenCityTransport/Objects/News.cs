using System.Text.Json.Serialization;
using TyumenCityTransport.Converters;

namespace TyumenCityTransport.Objects
{
    public class News
    {
        /// <summary>
        /// Идентификатор новости
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Дата создания новости
        /// </summary>
        [JsonPropertyName("create_date")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата редактирования новости
        /// </summary>
        [JsonPropertyName("update_date")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Дата публикации новости
        /// </summary>
        [JsonPropertyName("publish_date")]
        [JsonConverter(typeof(BadDateTimeConverter))]
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Фрагмент из текста новости
        /// </summary>
        [JsonPropertyName("excerpt")]
        public string Excerpt { get; set; } = null!;

        /// <summary>
        /// Ссылка на новость
        /// </summary>
        [JsonPropertyName("link")]
        public Uri Link { get; set; } = null!;

        /// <summary>
        /// Опубликована ли новость
        /// </summary>
        [JsonPropertyName("is_published")]
        public bool IsPublished { get; set; }
    }
}
