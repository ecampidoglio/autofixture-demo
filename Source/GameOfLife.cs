using System;
using System.Collections;
using System.Collections.Generic;

public class Grid
{
	public Generation Refresh(Generation seed)
	{
		return seed;
	}
}

public class Generation : IEnumerable<Cell>
{
	Cell[] cells;

	public Generation(params Cell[] cells)
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
}

public class Cell
{
	public Cell(int x, int y)
	{
	}
}
