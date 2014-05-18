using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

public class When_calculating_a_generation_with_af
{
    Fixture fixture;

    public When_calculating_a_generation_with_af()
    {
        fixture = new Fixture();
    }

    [Fact]
    public void It_should_return_a_generation_containing_cells()
    {
        // Given
        var seed = fixture.Create<Generation>();
        var subject = fixture.Create<Grid>();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        nextGeneration.Should().NotBeEmpty();
    }

    [Fact]
    public void It_should_return_the_same_number_of_cells()
    {
        // Given
        var seed = fixture.Create<Generation>();
        var subject = fixture.Create<Grid>();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        nextGeneration.Should().HaveSameCount(seed);
    }

    [Fact]
    public void It_should_kill_an_alive_cell_without_neighbours()
    {
        // Given
        fixture.Customize<Cell>(create =>
                create.With(c => c.Alive, true));
        fixture.Customize(new SingleElementSequence<Cell>());
        var seed = fixture.Create<Generation>();
        var subject = fixture.Create<Grid>();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        seed.Single().Alive.Should().BeFalse();
    }
}
