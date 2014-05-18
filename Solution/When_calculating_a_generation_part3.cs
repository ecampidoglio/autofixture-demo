using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

public class When_calculating_a_generation_with_declarative_af
{
    [Theory, AutoData]
    public void It_should_return_a_generation_containing_cells(Grid subject, Generation seed)
    {
        var nextGeneration = subject.Refresh(seed);
        nextGeneration.Should().NotBeEmpty();
    }

    [Theory, AutoData]
    public void It_should_return_the_same_number_of_cells(Grid subject, Generation seed)
    {
        var nextGeneration = subject.Refresh(seed);
        nextGeneration.Should().HaveSameCount(seed);
    }

    [Theory, SingleAliveCellGeneration]
    public void It_should_kill_an_alive_cell_without_neighbours(Grid subject, Generation seed)
    {
        var nextGeneration = subject.Refresh(seed);
        seed.Single().Alive.Should().BeFalse();
    }
}
