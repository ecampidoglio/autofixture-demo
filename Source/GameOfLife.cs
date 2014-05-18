using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Grid
{
	public Generation Refresh(Generation seed)
	{
		var solitaryCells = seed.Where(cell => seed.NeighboursOf(cell.X, cell.Y) < 2);

		foreach (var cell in solitaryCells)
		{
			cell.Alive = false;
		}

		return seed;
	}
}

public class Generation : IEnumerable<Cell>
{
	IEnumerable<Cell> cells;

	public Generation(IEnumerable<Cell> cells)
	{
		this.cells = cells;
	}

	public IEnumerator<Cell> GetEnumerator()
	{
		foreach (var cell in this.cells)
		{
			yield return cell;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	public int NeighboursOf(int x, int y)
	{
		var neighbours = -1;

		for (var i = x - 1; i <= x + 1; i++)
		{
			for (var j = y - 1; j <= y + 1; j++)
			{
				if (CellExists(i, j))
				{
					neighbours++;
				}
			}
		}

		return neighbours;
	}

    private bool CellExists(int x, int y)
    {
        return this.cells.Any(c => c.X == x && c.Y == y);
    }
}

public class Cell
{
	public readonly int X;
	public readonly int Y;
	public bool Alive;

	public Cell(int x, int y, bool alive = false)
	{
		this.X = x;
		this.Y = y;
        this.Alive = alive;
	}
}
