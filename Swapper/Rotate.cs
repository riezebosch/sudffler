namespace Swapper;

public static class Rotate
{
    public static Grid Clockwise(Grid source)
    {
        var target = Grid.Empty(source.Size);
        var length = source.Size.N;
        
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
}