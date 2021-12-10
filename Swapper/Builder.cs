using Swapper.Builders;

namespace Swapper;

public class Builder
{
    private readonly List<Func<Grid, Random, Grid>> _mutators = new();

    public Builder Shuffle(string alphabet, string with) => 
        Add((grid, random) => new Shuffler(random).Alphabet(grid, alphabet, with));

    public Builder Shuffle(string alphabet) =>
        Add((grid, random) => new Shuffler(random).Alphabet(grid, alphabet));

    public Builder Add(Func<Grid, Random, Grid> mutator)
    {
        _mutators.Add(mutator);
        return this;
    }
    
    public Builder Add(Func<Grid, Grid> mutator)
    {
        _mutators.Add((g, r) => mutator(g));
        return this;
    }

    public Grid Apply(Grid grid, Random? random = null) => 
        _mutators.Aggregate(grid, (current, mutator) => mutator(current, random ?? new Random()));

    public Builder Rotate() => Add(Swapper.Rotate.Clockwise);

    public IStack Stack(int stack) => new Stack(this, stack);

    public IBand Band(int band) => new Band(this, band);

    public IBands Bands() => new Bands(this);

    public IStacks Stacks() => new Stacks(this);

    public IColumns Columns() => new Columns(this);

    public IRows Rows() => new Rows(this);
}