namespace Swapper;

public static class RandomExt
{
    public static Shuffle Shuffle(this Random rnd) => new(rnd);
}