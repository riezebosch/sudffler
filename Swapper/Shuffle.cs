namespace Swapper;

public class Shuffler
{
    private readonly Random _rnd;

    public Shuffler(Random rnd) => _rnd = rnd;

    public Grid Alphabet(Grid source, string alphabet) => 
        Alphabet(source, alphabet, alphabet.Shuffle(_rnd));

    public Grid Alphabet(Grid source, string alphabet, string with)
    {
        var target = Grid.Empty(source.Size);
        for (var i = 0; i < source.Size; i++)
        {
            var index = alphabet.IndexOf(source[i]);
            target[i] = index >= 0 ? with[index] : source[i];
        }

        return target;
    }

    public Grid Stacks(Grid grid) => 
        Shuffle(grid, grid.Size.Lower().Lower(), Swap.Stack);
    
    public Grid Bands(Grid grid) => 
        Shuffle(grid, grid.Size.Lower().Higher(), Swap.Band);
    
    public Grid Band(Grid grid) => 
        Shuffle(grid, grid.Size.Lower().Lower(), Swap.Row);

    public Grid Stack(Grid grid) => 
        Shuffle(grid, grid.Size.Lower().Higher(), Swap.Column);

    private Grid Shuffle(Grid grid, Size length, Func<Grid, int, int, Grid> swap)
    {
        for (var i = 0; i < length; i++)
        {
            grid = swap(grid, i, _rnd.Next(length));
        }

        return grid;
    }
}