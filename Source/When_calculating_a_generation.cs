using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

public class When_calculating_a_generation
{
    [Theory, AutoData]
    public void It_should_return_a_generation_containing_cells(
        Generation seed, Grid subject)
    {
        var nextGeneration = subject.Refresh(seed);
        nextGeneration.Should().NotBeEmpty();
    }

    [Theory, AutoData]
    public void It_should_return_the_same_number_of_cells(
        Generation seed, Grid subject)
    {
        var nextGeneration = subject.Refresh(seed);
        nextGeneration.Should().HaveSameCount(seed);
    }

    [Theory, SingleCellGeneration(alive: true)]
    public void It_should_kill_an_alive_cell_without_neighbours(
        Generation seed, Grid subject)
    {
        var nextGeneration = subject.Refresh(seed);
        seed.Single().Alive.Should().BeFalse();
    }
}

