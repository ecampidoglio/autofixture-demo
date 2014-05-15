using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

public class When_calculating_a_generation
{
	Fixture fixture;
	Grid subject;
	Generation seed;
	Generation nextGeneration;

	public When_calculating_a_generation()
	{
		fixture = new Fixture();
		subject = fixture.Create<Grid>();
		seed = fixture.Create<Generation>();
		nextGeneration = subject.Refresh(seed);
	}

	[Fact]
	public void It_should_return_a_generation_containing_cells()
	{
		nextGeneration.Should().NotBeEmpty();
	}

	[Theory, AutoData]
	public void It_should_return_the_same_amount_of_cells(Generation seed)
	{
	    var nextGeneration = subject.Refresh(seed);
	    nextGeneration.Should().HaveSameCount(seed);
	}
}
