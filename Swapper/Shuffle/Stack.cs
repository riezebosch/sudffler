namespace Swapper.Shuffle;

public class Stack
{
    private readonly Random _rnd;

    public Stack(Random rnd) => _rnd = rnd;

    public Grid Apply(Grid grid)
    {
        var length = grid.Size.Lower().Higher();
        for (var i = 0; i < length; i++)
        {
            grid = grid.Column(i, _rnd.Next(length));
        }

        return grid;
    }
}