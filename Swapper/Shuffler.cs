namespace Swapper;

public static class Shuffler
{
    private static readonly Random Rnd = new();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> alphabet) =>
        alphabet.OrderBy(_ => Rnd.Next());     // elegant shuffle: https://stackoverflow.com/a/4262134/129269

    public static string Shuffle(this string alphabet) =>
        new(Shuffle<char>(alphabet).ToArray());
}