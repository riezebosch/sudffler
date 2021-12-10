namespace Swapper;

public static class Mirror
{
    public static Grid MirrorColumns(this Grid grid) => 
        grid.MirrorColumns(0, grid.Size.Lower() - 1);

    private static Grid MirrorColumns(this Grid grid, int left, int right)
    {
        for (; left < right; left++, right--)
        {
            grid = grid.Column(left, right);
        }

        return grid;
    }

    public static Grid MirrorStack(this Grid grid, int stack)
    {
        var length = grid.Size.Lower().Lower();
        return grid.MirrorColumns(stack * length, (stack + 1) * length - 1);
    }
    
    public static Grid MirrorStacks(this Grid grid)
    {
        var right = grid.Size.Lower().Lower() -1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = grid.Stack(left, right);
        }

        return grid;
    }

    public static Grid MirrorRows(this Grid grid) =>
        grid.MirrorRows(0, grid.Size.Lower() - 1);
    
    public static Grid MirrorBands(this Grid grid)
    {
        var right = grid.Size.Lower().Higher() - 1;
        for (var left = 0; left < right; left++, right--)
        {
            grid = grid.Band(left, right);
        }
        
        return grid;
    }
    
    public static Grid MirrorBand(this Grid grid, int band)
    {
        var length = grid.Size.Lower().Lower();
        return grid.MirrorRows(band * length, (band + 1) * length - 1);
    }
    private static Grid MirrorRows(this Grid grid, int @from , int to)
    {
        for (; @from < to; @from++, to--)
        {
            grid = grid.Row(@from, to);
        }

        return grid;
    }
}