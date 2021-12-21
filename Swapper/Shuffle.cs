using Swapper.Builders;

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
        Shuffle(grid, 0, grid.Size.Side().Stacks(), Swap.Stack);
    
    public Grid Bands(Grid grid) => 
        Shuffle(grid, 0, grid.Size.Side().Bands(), Swap.Band);
    
    public Grid Band(Grid grid, int band) => 
        Shuffle(grid, band * grid.Size.Side().Bands(), grid.Size.Side().Rows(), Swap.Row);

    public Grid Stack(Grid grid, int stack) => 
        Shuffle(grid, stack * grid.Size.Side().Stacks(), grid.Size.Side().Columns(), Swap.Column);

    private Grid Shuffle(Grid grid, int start, Size length, Func<Grid, int, int, Grid> swap)
    {
        for (var i = 0; i < length; i++)
        {
            grid = swap(grid, start + i, start + _rnd.Next(length));
        }

        return grid;
    }
}