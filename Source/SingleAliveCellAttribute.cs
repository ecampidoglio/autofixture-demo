using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

public class SingleCellGenerationAttribute : AutoDataAttribute
{
    public SingleCellGenerationAttribute(bool alive = false)
        : base(new Fixture().Customize(new SingleCellGeneration(alive)))
    {
    }
}
