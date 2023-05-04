namespace CrucisCo.MinefieldGame
{
    public class Mine
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Mine(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}