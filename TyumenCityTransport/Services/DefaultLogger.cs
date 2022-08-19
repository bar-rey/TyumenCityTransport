namespace TyumenCityTransport.Services
{
    public class DefaultLogger : ILogger
    {
        public void Log(string message) 
            => Console.WriteLine(message);
    }
}
