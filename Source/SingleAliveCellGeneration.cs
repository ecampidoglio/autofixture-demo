using Ploeh.AutoFixture;

public class SingleCellGeneration : ICustomization
{
    bool alive;

    public SingleCellGeneration(bool alive = false)
    {
        this.alive = alive;
    }

    public void Customize(IFixture fixture)
    {
        fixture.Customize<Cell>(create =>
                create.With(c => c.Alive, this.alive));
        fixture.Customize(new SingleElementSequence<Cell>());
    }
}
