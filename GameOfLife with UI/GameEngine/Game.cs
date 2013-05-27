namespace GameEngine
{
    public class Game
    {
        public bool[,] Play(bool[,] source)
        {
            bool[,] dest = new bool[source.GetLength(0),source.GetLength(1)];
            for(int x = 0; x<source.GetLength(0); x++)
            {
                for(int y = 0; y<source.GetLength(1);y++)
                {
                    int neighbours = GetNumberOfNeighbours(source, x, y);
                    if (source[x,y])
                    {
                        dest[x, y] = (neighbours == 3 || neighbours == 2);
                    }
                    else
                    {
                        dest[x, y] = neighbours == 3;
                    }
                }

            }
            return dest;
        }

        private int GetNumberOfNeighbours(bool[,] source, int x, int y)
        {
            int n = 0;

            // row above, left middle right
            n += IsValidIndex(source, x - 1, y - 1) && source[x - 1, y - 1] ? 1 : 0;
            n += IsValidIndex(source, x - 1, y - 0) && source[x - 1, y - 0] ? 1 : 0;
            n += IsValidIndex(source, x - 1, y + 1) && source[x - 1, y + 1] ? 1 : 0;

            // same row , left  right
            n += IsValidIndex(source, x, y - 1) && source[x, y - 1] ? 1 : 0;
            n += IsValidIndex(source, x, y + 1) && source[x, y + 1] ? 1 : 0;

            // row below, left middle right
            n += IsValidIndex(source, x + 1, y - 1) && source[x + 1, y - 1] ? 1 : 0;
            n += IsValidIndex(source, x + 1, y - 0) && source[x + 1, y - 0] ? 1 : 0;
            n += IsValidIndex(source, x + 1, y + 1) && source[x + 1, y + 1] ? 1 : 0;
            
            return n;
        }

        private bool IsValidIndex(bool [,] source, int x, int y)
        {
            return x >= 0 && x < source.GetLength(0) &&
                   y >= 0 && y < source.GetLength(1);

        }
    }
}
