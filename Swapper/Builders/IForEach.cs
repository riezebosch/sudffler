namespace Swapper.Builders;

public interface IForEach<out T>
{
    Builder ForEach(Action<T> apply);
}