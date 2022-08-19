namespace TyumenCityTransport
{
    public class ApiResponse<T>
    {
        public T? Response { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
