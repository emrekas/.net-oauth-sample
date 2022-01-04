using System.Linq;

namespace EmployeeAPI.Common.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> SkipOrAll<T>(this IQueryable<T> src, int? skip)
        {
            return skip.HasValue ? src.Skip((int)skip) : src;
        }
        public static IQueryable<T> TakeOrAll<T>(this IQueryable<T> src, int? take)
        {
            return take.HasValue ? src.Take((int)take) : src;
        }
    }
}