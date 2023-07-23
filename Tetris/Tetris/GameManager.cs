

using Tetris.Services;

namespace Tetris
{
    public class GameManager
    {
        private static GameManager instance;
        private static readonly object padlock = new object();

        private const int gameWidth = 15;
        private const int gameHeight = 20;
        private int currentX = gameWidth / 2;
        private int currentY = 0;

        public int CurrentX { get { return currentX; } set { currentX = value; } }
        public int CurrentY { get { return currentY; } set { currentY = value; } }
        public int GameWidth { get { return gameWidth; } }
        public int GameHeight { get { return gameHeight; } }


        private string symbol1 = "██";
        private object[,] grid = new object[gameWidth, gameHeight];

        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;



            }
        }

        public void GameDraw(object forma)
        {
            Console.SetCursorPosition(0, 0);
            int rand = Random.Shared.Next(0, 2);
            for (int y = 0; y < gameHeight; y++)
            {
                for (int x = 0; x < gameWidth; x++)
                {
                    if (x == currentX && y == currentY)
                    {
                        Console.Write(forma);
                    }
                    else if (grid[x, y] == forma)
                    {
                        Console.Write(forma);
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
            return currentY >= gameHeight - 1/* || grid[currentX, currentY + 1]*/;
        }

        public void PlaceSymbol(object l)
        {
            grid[currentX, currentY] = l;
        }
    }
}
