using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class Grid
    {
        public IEnumerable<Cell> Refresh(IEnumerable<Cell> seed)
        {
            seed.First().Alive = false;
            return seed;
        }
    }
}

