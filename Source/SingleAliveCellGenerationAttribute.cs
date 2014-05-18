using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

public class SingleAliveCellGenerationAttribute : AutoDataAttribute
{
    public SingleAliveCellGenerationAttribute()
        : base(new Fixture().Customize(new SingleAliveCellGeneration()))
    {
    }
}
