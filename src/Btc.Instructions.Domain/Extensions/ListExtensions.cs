namespace Btc.Instructions.Domain.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source switch
            {
                null => true,
                ICollection<T> collection => collection.Count < 1,
                _ => !source.Any()
            };
        }
    }
}
