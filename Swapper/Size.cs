namespace Swapper;

/// <summary>
/// https://en.wikipedia.org/wiki/Mathematics_of_Sudoku#Rectangular_regions
/// </summary>
public record Size
{
    public Size(int size)
    {
        C = (int)Math.Ceiling(Math.Pow(size, 0.25));
        R = (int)Math.Pow(size, 0.25);
        N = C * R;
    }

    public int C { get; }
    public int R { get; }
    public int N { get; }

    public static implicit operator Size(int size) => new(size);
    public static implicit operator int(Size size) => size.N * size.N;
}