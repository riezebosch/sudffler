namespace Swapper.Builders;

internal class Bands : IBands
{
    private readonly Builder _builder;

    public Bands(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(Swapper.Mirror.Bands);
    public Builder Shuffle() => _builder.Add((grid, random) => random.Shuffle().Bands(grid));
    public Builder ForEach(Action<IBand> apply) => _builder.Add(grid =>
    {
        var builder = new Builder();
        var bands = grid.Size.R;
            
        for (var band = 0; band < bands; band++)
        {
            apply(new Band(builder, band));
        }

        return builder.Apply(grid);
    });
}