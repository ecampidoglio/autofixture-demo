using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

public class When_calculating_a_generation
{
    [Fact]
    public void It_should_return_a_generation_containing_cells()
    {
        // Given
        var seed = new Generation(
                       new List<Cell>()
                       {
                           new Cell(9, 12),
                           new Cell(15, 20)
                       });
        var subject = new Grid();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        nextGeneration.Should().NotBeEmpty();
    }

    [Fact]
    public void It_should_return_the_same_number_of_cells()
    {
        // Given
        var seed = new Generation(
                       new List<Cell>()
                       {
                           new Cell(1, 2),
                           new Cell(12, 25),
                           new Cell(5, 9)
                       });
        var subject = new Grid();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        nextGeneration.Should().HaveCount(3);
    }

    [Fact]
    public void It_should_kill_an_alive_cell_without_neighbours()
    {
        // Given
        var solitaryCell = new Cell(9, 10, alive: true);
        var seed = new Generation(
                       new List<Cell>()
                       {
                           solitaryCell
                       });
        var subject = new Grid();

        // When
        var nextGeneration = subject.Refresh(seed);

        // Then
        solitaryCell.Alive.Should().BeFalse();
    }
}
