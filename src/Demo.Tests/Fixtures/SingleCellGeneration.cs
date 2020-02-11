using AutoFixture;

namespace Demo.Tests.Fixtures
{
    public class SingleCellGeneration : ICustomization
    {
        private readonly bool _alive;

        public SingleCellGeneration(bool alive = false)
        {
            _alive = alive;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customize<Cell>(create => create.With(c => c.Alive, _alive));
            fixture.Customize(new SingleElementSequence<Cell>());
        }
    }
}
