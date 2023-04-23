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
        private readonly string _methodBase = $"https://api.tgt72.ru/api/v{CurrentSupportedApiVersion}/";

        /// <summary>
        /// Сервис для отправки HTTP-запросов библиотекой
        /// </summary>
        private readonly IHttpService _httpService;

        /// <summary>
        /// Логгер библиотеки
        /// </summary>
        internal ILogger? Logger { get; } = null;

        /// <summary>
        /// 
        /// </summary>
        internal readonly ICryptography Cryptography;

        /// <summary>
        /// Используемая экземпляром класса версия API
        /// </summary>
        public int ApiVersion { get; }

        /// <summary>
        /// Объект для работы с методами API
        /// </summary>
        public Methods Methods => new Methods(this);

        #region Constructors

        public TransportApi()
        {
            Logger = new DefaultLogger();
            _httpService = new DefaultHttpService(Logger);
            Cryptography = new DefaultCryptography();
        }

        public TransportApi(IHttpService httpService)
        {
            _httpService = httpService;
            Logger = new DefaultLogger();
            Cryptography = new DefaultCryptography();
        }

        public TransportApi(IHttpService httpService, ICryptography cryptography)
        {
            _httpService = httpService;
            Logger = new DefaultLogger();
            Cryptography = cryptography;
        }

        public TransportApi(ILogger logger)
        {
            Logger = logger;
            _httpService = new DefaultHttpService(logger);
            Cryptography = new DefaultCryptography();
        }

        public TransportApi(ILogger logger, ICryptography cryptography)
        {
            Logger = logger;
            _httpService = new DefaultHttpService(logger);
            Cryptography = cryptography;
        }

        public TransportApi(IHttpService httpService, ILogger logger, ICryptography cryptography) 
        {
            Logger = logger;
            _httpService = httpService;
            Cryptography = cryptography;
        }

        #endregion Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
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