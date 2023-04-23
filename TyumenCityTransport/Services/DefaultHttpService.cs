namespace TyumenCityTransport.Services
{
    public class DefaultHttpService : IHttpService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger? _logger = null;

        public DefaultHttpService() { }
        public DefaultHttpService(ILogger logger) => _logger = logger;

        /// <summary>
        /// Отправляет асинхронный GET-запрос и возвращает результат в объекте Stream.
        /// </summary>
        /// <param name="url">Базовый url.</param>
        /// <param name="parameters">Параметры запроса.</param>
        public async Task<Stream> GetForStreamAsync(Uri url, Dictionary<string, string>? parameters = null) 
        {
            var requestUrl = BuildGetRequestUrl(url.AbsoluteUri, parameters);
            _logger?.Log($"GET-запрос: {requestUrl.AbsoluteUri}");
            var response = await _httpClient.GetAsync(requestUrl).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Создаёт URL для GET-запроса.
        /// </summary>
        /// <param name="baseUrl">Базовый URL.</param>
        /// <param name="parameters">Параметры строки запроса.</param>
        public Uri BuildGetRequestUrl(string baseUrl, Dictionary<string, string>? parameters) 
        {
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            string requestUrl = baseUrl;
            if (parameters != null && parameters.Count > 0)
                requestUrl += string.Concat("?", string.Join("&", parameters.Select(i =>
                    $"{Uri.EscapeDataString(i.Key)}={Uri.EscapeDataString(i.Value)}")));
            return new Uri(requestUrl);
        }

        /// <summary>
        /// Освобождает ресурсы используемого клиента HTTP.
        /// </summary>
        public void Dispose() => _httpClient?.Dispose();
    }
}
