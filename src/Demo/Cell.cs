namespace Demo
{
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
}