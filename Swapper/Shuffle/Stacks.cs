namespace Swapper.Shuffle;

public class Stacks
{
    private readonly Random _rnd;

    public Stacks(Random rnd) => _rnd = rnd;

    public Grid Apply(Grid grid)
    {
        var length = grid.Size.Lower().Lower();
        for (var i = 0; i < length; i++)
        {
            grid = grid.Stack(i, _rnd.Next(length));
        }

        return grid;
    }
}