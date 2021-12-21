using Swapper.Builders;

namespace Swapper;

public static class Swap
{
    public static Grid Column(this Grid grid, int column, int with)
    {
        var length = grid.Size.Stacks();
        for (var cell = 0; cell < grid.Size; cell += length)
        {
            (grid[cell + column], grid[cell + with]) = (grid[cell + with], grid[cell + column]);
        }

        return grid;
    }

    public static Grid Stack(Grid grid, int stack, int with)
    {
        var length = grid.Size.Stacks().Columns();
        for (var column = 0; column < length; column++)
        {
            grid = grid.Column(length * stack + column, length * with + column);
        }

        return grid;
    }

    public static Grid Row(Grid grid, int row, int with)
    {
        var length = grid.Size.Bands();
        for (var cell = 0; cell < length; cell++)
        {
            var a = row * length + cell;
            var b = with * length + cell;
            (grid[a], grid[b]) = (grid[b], grid[a]);
        }

        return grid;
    }

    public static Grid Band(Grid grid, int band, int with)
    {
        var length = grid.Size.Bands().Rows();
        for (var row = 0; row < length; row++)
        {
            grid = Row(grid, band * length + row, with * length + row);
        }

        return grid;
    }
}