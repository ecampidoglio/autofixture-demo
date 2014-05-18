using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

public class CellsInRowGenerationAttribute : AutoDataAttribute
{
	public CellsInRowGenerationAttribute()
            : base(new Fixture().Customize(new CellsInRowGeneration()))
	{
	}
}

