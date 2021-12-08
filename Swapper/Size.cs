namespace Swapper;

public record Size(int size)
{
    public static implicit operator Size(int size) => new(size);
    public static implicit operator int(Size size) => size.size;
    
    public Size Lower() => 
        (int)Math.Pow(size, 0.5);
    
    public Size Higher() => 
        (int)Math.Ceiling(Math.Pow(size, 0.5));
}