namespace NecronomiconsCurse;

public static class Utils
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) => source.ToList().ForEach(action);
}