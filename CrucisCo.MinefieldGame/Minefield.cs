namespace CrucisCo.MinefieldGame
{
    public class Minefield
    {
        public int Size { get; private set; }
        public bool[,] Mines { get; private set; }

        public Minefield(int size, int numMines)
        {
            Size = size;
            Mines = new bool[Size, Size];

            PlantMines(numMines);
        }

        public bool IsMineAt(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                return false;
            }
            return Mines[x, y];
        }

        private void PlantMines(int numMines)
        {
            // Plant mines randomly
            Random rand = new Random();
            int numPlantedMines = 0;
            while (numPlantedMines < numMines)
            {
                int x = rand.Next(Size);
                int y = rand.Next(Size);
                if (!Mines[x, y])
                {
                    Mines[x, y] = true;
                    numPlantedMines++;
                }
            }
        }
    }
}