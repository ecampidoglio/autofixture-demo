using System.Collections;
using System.Collections.Generic;

namespace Demo
{
    public class Generation : IEnumerable<Cell>
    {
        private readonly IEnumerable<Cell> cells;

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
}