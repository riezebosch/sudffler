namespace Swapper;

public class Shuffle
{
    private readonly Random _rnd;

    public Shuffle(Random rnd) => _rnd = rnd;

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
        Do(grid, 0, grid.Size.R, Swap.Stack);
    
    public Grid Bands(Grid grid) => 
        Do(grid, 0, grid.Size.C, Swap.Band);
    
    public Grid Band(Grid grid, int band) => 
        Do(grid, band * grid.Size.R, grid.Size.R, Swap.Row);

    public Grid Stack(Grid grid, int stack) => 
        Do(grid, stack * grid.Size.C, grid.Size.C, Swap.Column);

    private Grid Do(Grid grid, int start, int length, Func<Grid, int, int, Grid> swap)
    {
        for (var i = 0; i < length; i++)
        {
            grid = swap(grid, start + i, start + _rnd.Next(length));
        }

        return grid;
    }
}