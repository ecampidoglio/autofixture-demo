using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Grid
{
    public IEnumerable<Cell> Refresh(IEnumerable<Cell> seed)
    {
        seed.First().Alive = false;
        return seed;
    }
}

public class Generation : IEnumerable<Cell>
{
    IEnumerable<Cell> cells;

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
