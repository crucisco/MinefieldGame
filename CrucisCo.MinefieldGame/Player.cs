namespace CrucisCo.MinefieldGame
{
    public class Player
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Lives { get; set; }

        private readonly int _size;

        public Player(int x, int y, int lives, int size)
        {
            PosX = x;
            PosY = y;
            Lives = lives;
            _size = size;
        }

        public bool Move(Direction direction)
        {
            bool moved = false;

            switch (direction)
            {
                case Direction.Up:
                    if (PosY > 0)
                    {
                        PosY--;
                        moved = true;
                    }
                    break;
                case Direction.Down:
                    if (PosY < _size - 1)
                    {
                        PosY++;
                        moved = true;
                    }
                    break;
                case Direction.Left:
                    if (PosX > 0)
                    {
                        PosX--;
                        moved = true;
                    }
                    break;
                case Direction.Right:
                    if (PosX < _size - 1)
                    {
                        PosX++;
                        moved = true;
                    }
                    break;
            }

            return moved;
        }
    }
}