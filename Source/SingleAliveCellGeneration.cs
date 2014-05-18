using Ploeh.AutoFixture;

public class SingleAliveCellGeneration : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customize<Cell>(create =>
                create.With(c => c.Alive, true));
        fixture.Customize(new SingleElementSequence<Cell>());
    }
}
