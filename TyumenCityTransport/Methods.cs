using System.Collections.Generic;
using TyumenCityTransport.Objects;

namespace TyumenCityTransport
{
    public class Methods
    {
        private readonly TransportApi _transportApi;
        public Methods(TransportApi transportApi) => _transportApi = transportApi;

        /// <summary>
        /// Остановки общественного транспорта с возможностью поиска по переданной строке.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <param name="queryText">Строка для фильтрации по описанию и названию</param>
        public async Task<ApiResponse<Response<Checkpoint>>> CheckpointsForSearch(DateTime? dateTime = null, string? queryText = null) 
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            if (!string.IsNullOrEmpty(queryText))
                parameters.Add("query_text", queryText);
            return await _transportApi.RequestAsync<Response<Checkpoint>>("checkpointsforsearch", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Остановки общественного транспорта.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <returns>Остановки общественного транспорта на сегодняшний день, если не была передана другая дата</returns>
        public async Task<ApiResponse<Response<Checkpoint>>> Checkpoint(DateTime? dateTime = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            return await _transportApi.RequestAsync<Response<Checkpoint>>("checkpoint", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Маршруты общественного транспорта с возможностью поиска по переданной строке.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <param name="search">Строка для фильтрации по описанию и названию</param>
        public async Task<ApiResponse<Response<Route>>> RoutesForSearch(DateTime? dateTime = null, string? search = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            if (!string.IsNullOrEmpty(search))
                parameters.Add("search", search);
            return await _transportApi.RequestAsync<Response<Route>>("routesforsearch", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Маршруты общественного транспорта.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <returns>Маршруты общественного транспорта на сегодняшний день, если не была передана другая дата</returns>
        public async Task<ApiResponse<Response<Route>>> Route(DateTime? dateTime = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            return await _transportApi.RequestAsync<Response<Route>>("route", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Рейсы общественного транспорта с разделением на временные промежутки.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <param name="showIntervals">Отображать ли время ожидания общественного транспорта на остановке (мин. и макс. в минутах)</param>
        /// <param name="ranges">Промежутки времени формата чч:мм-чч:мм (например, 00:00-12:00)</param>
        /// <param name="checkpointId">Время стоянки общественного транспорта на остановке с данным идентификатором</param>
        /// <param name="routeId">Время стоянки общественного транспорта на остановках маршрута с данным идентификатором</param>
        public async Task<ApiResponse<Response<TimeRanged>>> Times(DateTime? dateTime = null, bool? showIntervals = null, IEnumerable<string>? ranges = null, int? checkpointId = null, int? routeId = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            if (showIntervals != null)
                parameters.Add("show_intervals", showIntervals.ToApiString());
            if (ranges != null && ranges.Any())
                parameters.Add("ranges", ranges.ToApiString());
            if (checkpointId != null)
                parameters.Add("checkpoint_id", checkpointId.ToApiString());
            if (routeId != null)
                parameters.Add("route_id", routeId.ToApiString());
            return await _transportApi.RequestAsync<Response<TimeRanged>>("times", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Рейсы общественного транспорта без разделения на временные промежутки.
        /// </summary>
        /// <param name="dateTime">Актуальность требуемой информации</param>
        /// <param name="showIntervals">Отображать ли время ожидания общественного транспорта на остановке (мин. и макс. в минутах)</param>
        /// <param name="checkpointId">Время стоянки общественного транспорта на остановке с данным идентификатором</param>
        /// <param name="routeId">Время стоянки общественного транспорта на остановках маршрута с данным идентификатором</param>
        public async Task<ApiResponse<Response<TimeRangeless>>> Times(DateTime? dateTime = null, bool? showIntervals = null, int? checkpointId = null, int? routeId = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (dateTime != null)
                parameters.Add("date", dateTime.ToApiString());
            if (showIntervals != null)
                parameters.Add("show_intervals", showIntervals.ToApiString());
            if (checkpointId != null)
                parameters.Add("checkpoint_id", checkpointId.ToApiString());
            if (routeId != null)
                parameters.Add("route_id", routeId.ToApiString());
            return await _transportApi.RequestAsync<Response<TimeRangeless>>("times", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Даты, в которые курсирует общественный транспорт
        /// </summary>
        /// <param name="checkpointId">Идентификатор остановки</param>
        /// <param name="routeId">Идентификатор маршрута</param>
        public async Task<ApiResponse<Response<DateTime>>> Dates(int? checkpointId = null, int? routeId = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (checkpointId != null)
                parameters.Add("checkpoint_id", checkpointId.ToApiString());
            if (routeId != null)
                parameters.Add("route_id", routeId.ToApiString());
            var response = await _transportApi.RequestAsync<Response<Date>>("dates", parameters).ConfigureAwait(false);
            if (response.Success)
                return new ApiResponse<Response<DateTime>>
                {
                    Success = true,
                    Response = new Response<DateTime>
                    {
                        Total = response.Response!.Total,
                        Success = response.Response.Success,
                        Objects = response.Response.Objects.Select(o => o.DateTime)
                    }
                };
            return new ApiResponse<Response<DateTime>>
            {
                Success = false,
                ErrorMessage = response.ErrorMessage
            };
        }

        /// <summary>
        /// Последние новости Тюменского городского транспорта
        /// </summary>
        /// <param name="limit">Количество возвращаемых новостей</param>
        /// <returns>Возвращает последние 30 новостей, если не был указан другой лимит</returns>
        public async Task<ApiResponse<Response<News>>> News(int? limit = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (limit != null)
                parameters.Add("limit", limit.ToApiString());
            return await _transportApi.RequestAsync<Response<News>>("news", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Светофоры
        /// </summary>
        /// <returns>Светофоры в городе</returns>
        public async Task<ApiResponse<Response<TrafficLight>>> TrafficLight()
        {
            return await _transportApi.RequestAsync<Response<TrafficLight>>("trafficlight").ConfigureAwait(false);
        }

        /// <summary>
        /// История выключений светофоров
        /// </summary>
        /// <param name="limit">Количество элементов истории</param>
        /// <returns>Возвращает 10 последних элементов, если не был указан другой лимит</returns>
        public async Task<ApiResponse<Response<TrafficLightShutdown>>> TrafficLightsShutdownFeed(int? limit = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (limit != null)
                parameters.Add("limit", limit.ToApiString());
            return await _transportApi.RequestAsync<Response<TrafficLightShutdown>>("trafficlightshutdownfeed", parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// Автомобили общественного транспорта
        /// </summary>
        /// <returns>Автомобили общественного транспорта</returns>
        public async Task<ApiResponse<Response<Car>>> Car()
        {
            return await _transportApi.RequestAsync<Response<Car>>("car").ConfigureAwait(false);
        }

        /// <summary>
        /// Баланс транспортной карты
        /// </summary>
        /// <returns>Автомобили общественного транспорта</returns>
        public async Task<ApiResponse<CardBalance>> Balance(string? card = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            if (card != null)
            {
                parameters.Add("card", card.ToApiString());
                parameters.Add("hash", _transportApi.Cryptography.MD5FromInput($"{DateTime.Today.ToString("dd.MM.yyyy")}.{card}").ToLower());
            }
            return await _transportApi.RequestAsync<CardBalance>("balance", parameters).ConfigureAwait(false);
        }
    }
}
