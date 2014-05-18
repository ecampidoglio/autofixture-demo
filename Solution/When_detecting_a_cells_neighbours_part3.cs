using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

public class When_detecting_a_cell_s_neighbours_with_declarative_af
{
    [Theory, SingleAliveCellGeneration]
    public void It_should_report_the_correct_number_for_a_cell_with_neighbours(
        Generation subject)
    {
        var lonelyCell = subject.Single();
        var neighbours = subject.NeighboursOf(lonelyCell.X, lonelyCell.Y);
        neighbours.Should().Be(0);
    }
}
