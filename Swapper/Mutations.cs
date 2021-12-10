namespace Swapper;

public static class Mutations
{
    public static Grid Rotate(this Grid source)
    {
        var target = Grid.Empty(source.Size);
        var length = source.Size.Lower();
        
        for (var row = 0; row < length; row++)
        {
            var column = length - row - 1;
            for (var cell = 0; cell < length; cell++)
            {
                target[cell * length + column] = source[row * length + cell];
            }
        }

        return target;
    }

    public static Grid Shuffle(this Grid source, string alphabet) => 
        Shuffle(source, alphabet, alphabet.Shuffle()); 

    public static Grid Shuffle(this Grid source, string alphabet, string becomes)
    {
        var target = Grid.Empty(source.Size);
        for (var i = 0; i < source.Size; i++)
        {
            var index = alphabet.IndexOf(source[i]);
            target[i] = index >= 0 ? becomes[index] : source[i];
        }

        return target;
    }

    public static Grid Column(this Grid grid, int column, int with)
    {
        var length = grid.Size.Lower();
        for (var cell = 0; cell < grid.Size; cell += length)
        {
            (grid[cell + column], grid[cell + with]) = (grid[cell + with], grid[cell + column]);
        }

        return grid;
    }

    public static Grid Stack(this Grid grid, int stack, int with)
    {
        var length = grid.Size.Lower().Higher();
        for (var column = 0; column < length; column++)
        {
            grid = grid.Column(length * stack + column, length * with + column);
        }

        return grid;
    }

    public static Grid Row(this Grid grid, int row, int with)
    {
        var length = grid.Size.Lower();
        for (var cell = 0; cell < length; cell++)
        {
            var a = row * length + cell;
            var b = with * length + cell;
            (grid[a], grid[b]) = (grid[b], grid[a]);
        }

        return grid;
    }

    public static Grid Band(this Grid grid, int band, int with)
    {
        var length = grid.Size.Lower().Lower();
        for (var row = 0; row < length; row++)
        {
            grid = Row(grid, band * length + row, with * length + row);
        }

        return grid;
    }
}