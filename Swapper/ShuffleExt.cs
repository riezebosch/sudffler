namespace Swapper;

public static class ShuffleExt
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> alphabet, Random random) =>
        alphabet.OrderBy(_ => random.Next());     // elegant shuffle: https://stackoverflow.com/a/4262134/129269

    public static string Shuffle(this string alphabet, Random random) =>
        new(Shuffle<char>(alphabet, random).ToArray());
}