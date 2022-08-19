using System.Text.Json;
using TyumenCityTransport.Services;

namespace TyumenCityTransport
{
    /// <summary>
    /// API Тюменского городского транспорта (tgt72.ru)
    /// </summary>
    public class TransportApi : IDisposable
    {
        /// <summary>
        /// Версия гарантировано поддерживаемого библиотекой API
        /// </summary>
        public const int CurrentSupportedApiVersion = 5;

        /// <summary>
        /// Базовый URL
        /// </summary>
        private readonly string _methodBase;

        /// <summary>
        /// Сервис для отправки HTTP-запросов библиотекой
        /// </summary>
        private readonly IHttpService _httpService;

        /// <summary>
        /// Логгер библиотеки
        /// </summary>
        internal ILogger? Logger { get; } = null;

        /// <summary>
        /// Используемая экземпляром класса версия API
        /// </summary>
        public int ApiVersion { get; }

        /// <summary>
        /// Объект для работы с методами API
        /// </summary>
        public Methods Methods => new Methods(this);

        #region Constructors

        public TransportApi(int apiVersion = CurrentSupportedApiVersion)
        {
            _httpService = new DefaultHttpService();
            _methodBase = $"https://api.tgt72.ru/api/v{apiVersion}/";
            ApiVersion = apiVersion;
        }

        public TransportApi(IHttpService httpService, int apiVersion = CurrentSupportedApiVersion)
        {
            _httpService = httpService;
            _methodBase = $"https://api.tgt72.ru/api/v{apiVersion}/";
            ApiVersion = apiVersion;
        }

        public TransportApi(ILogger logger, int apiVersion = CurrentSupportedApiVersion)
        {
            Logger = logger;
            _httpService = new DefaultHttpService(logger);
            _methodBase = $"https://api.tgt72.ru/api/v{apiVersion}/";
            ApiVersion = apiVersion;
        }

        public TransportApi(IHttpService httpService, ILogger logger,
            int apiVersion = CurrentSupportedApiVersion) 
        {
            Logger = logger;
            _httpService = httpService;
            _methodBase = $"https://api.tgt72.ru/api/v{apiVersion}/";
            ApiVersion = apiVersion;
        }

        #endregion Constructors

        public async Task<ApiResponse<TResult>> RequestAsync<TResult>(string method, Dictionary<string, string>? parameters = null)
        {
            var url = new Uri(string.Concat(_methodBase, method));
            try 
            {
                using (var stream = await _httpService.GetForStreamAsync(url, parameters).ConfigureAwait(false))
                using (var streamReader = new StreamReader(stream))
                {
                    Logger?.Log($"Ответ был успешно получен, десериализуем ({method})");
                    var result = await JsonSerializer.DeserializeAsync<TResult>(stream).ConfigureAwait(false);
                    return new ApiResponse<TResult> { Success = true, Response = result };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<TResult> { Success = false, ErrorMessage = ex.Message };
            }
        }

        /// <summary>
        /// Освобождает ресурсы используемого сервиса HTTP
        /// </summary>
        public void Dispose() => _httpService?.Dispose();
    }
}