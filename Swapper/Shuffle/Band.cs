namespace Swapper.Shuffle;

public class Band
{
    private readonly Random _rnd;

    public Band(Random rnd) => _rnd = rnd;

    public Grid Apply(Grid grid)
    {
        var length = grid.Size.Lower().Lower();
        for (var i = 0; i < length; i++)
        {
            grid = grid.Row(i, _rnd.Next(length));
        }

        return grid;
    }
}