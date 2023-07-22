

namespace Tetris
{
    public class GameManager
    {
        private static GameManager instance;
        private static readonly object padlock = new object();

        private int gameWidth = 15;
        private int gameHeight = 20;
        private int currentX = 15 / 2;
        private int currentY = 0;

        public int CurrentX { get { return currentX; } set { currentX = value; } }
        public int CurrentY { get { return currentY; } set { currentY = value; } }
        public int GameWidth { get { return gameWidth; } }
        public int GameHeight { get { return gameHeight; } }


        private string symbol1 = "██";
        private bool[,] grid = new bool[15, 20];

        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameManager();
                    }
                    return instance;
                }
            }
        }

        public void GameDraw()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < gameHeight; y++)
            {
                for (int x = 0; x < gameWidth; x++)
                {
                    if (x == currentX && y == currentY)
                    {
                        Console.Write(symbol1);
                    }
                    else if (grid[x, y])
                    {
                        Console.Write(symbol1);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }

        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    currentX = Math.Max(0, currentX - 2);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    currentX = Math.Min(gameWidth - 2, currentX + 2);
                }
            }
        }

        public bool IsCollision()
        {
            return currentY >= gameHeight - 1 || grid[currentX, currentY + 1];
        }

        public void PlaceSymbol()
        {
            grid[currentX, currentY] = true;
        }
    }
}
