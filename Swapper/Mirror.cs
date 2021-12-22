namespace Swapper;

public static class Mirror
{
    public static Grid Columns(Grid grid) => 
        Columns(grid, 0, grid.Size.N - 1);

    private static Grid Columns(Grid grid, int left, int right)
    {
        for (; left < right; left++, right--)
        {
            grid = Swap.Column(grid, left, right);
        }

        return grid;
    }

    public static Grid Stack(Grid grid, int stack) => 
        Columns(grid, stack * grid.Size.R, (stack + 1) * grid.Size.R - 1);

    public static Grid Stacks(Grid grid)
    {
        var right = grid.Size.R -1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = Swap.Stack(grid, left, right);
        }

        return grid;
    }

    public static Grid Bands(Grid grid)
    {
        var right = grid.Size.C - 1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = Swap.Band(grid, left, right);
        }
        
        return grid;
    }

    public static Grid Band(Grid grid, int band) => 
        Rows(grid, band * grid.Size.R, (band + 1) * grid.Size.R - 1);

    public static Grid Rows(Grid grid) =>
        Rows(grid, 0, grid.Size.N - 1);

    private static Grid Rows(Grid grid, int start , int end)
    {
        for (; start < end; start++, end--)
        {
            grid = Swap.Row(grid, start, end);
        }

        return grid;
    }
}