namespace TyumenCityTransport.Services
{
    public interface IHttpService : IDisposable
    {
        /// <summary>
        /// Отправляет асинхронный GET-запрос и возвращает результат в объекте Stream
        /// </summary>
        /// <param name="url">Базовый url.</param>
        /// <param name="parameters">Параметры запроса.</param>
        Task<Stream> GetForStreamAsync(Uri url, Dictionary<string, string>? parameters);

        /// <summary>
        /// Создаёт URL для GET-запроса.
        /// </summary>
        /// <param name="baseUrl">Базовый URL.</param>
        /// <param name="parameters">Параметры строки запроса.</param>
        Uri BuildGetRequestUrl(string baseUrl, Dictionary<string, string>? parameters);
    }
}
