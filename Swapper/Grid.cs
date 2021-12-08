namespace Swapper;

public class Grid : IEquatable<Grid>
{
    private readonly char[] _cells;

    public Grid(string input) => 
        _cells = input.ToCharArray();

    public static Grid Empty(int size) => 
        new("".PadLeft(size, '0'));

    public char this[int index]
    {
        get => _cells[index];
        set => _cells[index] = value;
    }

    public Size Size => _cells.Length;

    public override string ToString() => 
        new(_cells);

    public override bool Equals(object? obj)
    {
        if (obj is string input)
            return Equals(input);

        return Equals(obj as Grid);
    }

    public static implicit operator Grid(string input) => new (input);

    public bool Equals(Grid? other) => 
        _cells.SequenceEqual(other?._cells ?? Array.Empty<char>());

    public override int GetHashCode() => 
        _cells.GetHashCode();

    public static bool operator ==(Grid? left, Grid? right) => 
        Equals(left, right);

    public static bool operator !=(Grid? left, Grid? right) => 
        !Equals(left, right);
}