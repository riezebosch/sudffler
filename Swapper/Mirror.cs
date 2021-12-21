using Swapper.Builders;

namespace Swapper;

public static class Mirror
{
    public static Grid Columns(Grid grid) => 
        Columns(grid, 0, grid.Size.Stacks() - 1);

    private static Grid Columns(Grid grid, int left, int right)
    {
        for (; left < right; left++, right--)
        {
            grid = grid.Column(left, right);
        }

        return grid;
    }

    public static Grid Stack(this Grid grid, int stack)
    {
        var length = grid.Size.Bands().Rows();
        return Columns(grid, stack * length, (stack + 1) * length - 1);
    }
    
    public static Grid Stacks(this Grid grid)
    {
        var right = grid.Size.Bands().Rows() -1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = Swap.Stack(grid, left, right);
        }

        return grid;
    }

    public static Grid Rows(this Grid grid) =>
        Rows(grid, 0, grid.Size.Bands() - 1);
    
    public static Grid Bands(Grid grid)
    {
        var right = grid.Size.Bands().Columns() - 1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = Swap.Band(grid, left, right);
        }
        
        return grid;
    }
    
    public static Grid Band(Grid grid, int band)
    {
        var length = grid.Size.Bands().Rows();
        return Rows(grid, band * length, (band + 1) * length - 1);
    }
    private static Grid Rows(Grid grid, int start , int end)
    {
        for (; start < end; start++, end--)
        {
            grid = Swap.Row(grid, start, end);
        }

        return grid;
    }
}