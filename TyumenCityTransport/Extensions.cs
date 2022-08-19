using System.Collections;
using System.Globalization;

namespace TyumenCityTransport
{
    public static class ObjectExtensions
    {
        public static string ToApiString(this object variable)
        {
            var type = variable.GetType();
            if (type == typeof(bool)) return (bool)variable ? "1" : "0";
            if (variable is DateTime dateTime) return dateTime.ToString("yyyy-MM-dd");
            if (variable is double @double) return @double.ToString(CultureInfo.InvariantCulture);
            if (!(variable is IEnumerable enumerable) || variable is string)
                return variable.ToString();
            return string.Join(",", enumerable);
        }
    }
}
