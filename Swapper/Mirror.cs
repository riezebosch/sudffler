namespace Swapper;

public static class Mirror
{
    public static Grid Columns(Grid grid) => 
        Do(grid, 0, grid.Size.N, Swap.Column);

    public static Grid Stack(Grid grid, int stack) => 
        Do(grid, stack * grid.Size.R, (stack + 1) * grid.Size.R, Swap.Column);

    public static Grid Stacks(Grid grid) => 
        Do(grid, 0, grid.Size.R, Swap.Stack);

    public static Grid Bands(Grid grid) => 
        Do(grid, 0, grid.Size.C, Swap.Band);

    public static Grid Band(Grid grid, int band) => 
        Do(grid, band * grid.Size.R, (band + 1) * grid.Size.R, Swap.Row);

    public static Grid Rows(Grid grid) =>
        Do(grid, 0, grid.Size.N, Swap.Row);

    private static Grid Do(Grid grid, int start, int stop, Func<Grid, int, int, Grid> mirror)
    {
        while (start < stop)
        {
            grid = mirror(grid, start++, --stop);
        }

        return grid;
    }
}