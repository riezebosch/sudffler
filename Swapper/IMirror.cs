namespace Swapper;

public interface IMirror
{
    Builder Band(int i);
    Builder Bands();
    Builder Rows();
    Builder Stacks();
    Builder Stack(int i);
    Builder Columns();
}