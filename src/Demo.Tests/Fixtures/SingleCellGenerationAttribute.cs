using AutoFixture;
using AutoFixture.Xunit2;

namespace Demo.Tests.Fixtures
{
    public class SingleCellGenerationAttribute : AutoDataAttribute
    {
        public SingleCellGenerationAttribute(bool alive = false)
            : base(() => new Fixture().Customize(new SingleCellGeneration(alive)))
        {
        }
    }
}
