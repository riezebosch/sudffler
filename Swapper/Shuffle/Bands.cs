namespace Swapper.Shuffle;

public class Bands
{
    private readonly Random _rnd;

    public Bands(Random rnd) => _rnd = rnd;

    public Grid Apply(Grid grid)
    {
        var length = grid.Size.Lower().Higher();
        for (var i = 0; i < length; i++)
        {
            grid = grid.Band(i, _rnd.Next(length));
        }

        return grid;
    }
}