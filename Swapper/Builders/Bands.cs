namespace Swapper.Builders;

internal class Bands : IBands
{
    private readonly Builder _builder;

    public Bands(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(Swapper.Mirror.Bands);
    public Builder Shuffle() => _builder.Add((grid, random) => new Shuffler(random).Bands(grid));
    public Builder ForEach(Action<IBand> apply) => _builder.Add(grid =>
    {
        var builder = new Builder();
        var bands = grid.Size.Stacks().Columns();
            
        for (var band = 0; band < bands; band++)
        {
            apply(new Band(builder, band));
        }

        return builder.Apply(grid);
    });
}

public static class SizeHelpers
{
    public static Size Side(this Size grid) => grid.Lower();
    public static Size Stacks(this Size grid) => grid.Lower();
    public static Size Columns(this Size grid) => grid.Higher();
    public static Size Bands(this Size grid) => grid.Higher();
    public static Size Rows(this Size grid) => grid.Lower();
}