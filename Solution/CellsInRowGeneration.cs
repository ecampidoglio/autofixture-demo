using System;
using Ploeh.AutoFixture;
using System;

public class CellsInRowGeneration : ICustomization
{
	public void Customize(IFixture fixture)
	{
		var row = fixture.Create<int>();
		var column = fixture.Create<int>();

		fixture.Customize<Cell>(cfg => cfg
			   .With(cell => cell.Y, row)
			   .With(cell => cell.X, column++));
	}
}
