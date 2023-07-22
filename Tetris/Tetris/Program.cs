using System;
using System.Threading;

namespace Tetris
{
    public class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;

            while (true)
            {
                Thread.Sleep(200);
                GameManager.Instance.HandleInput();
                if (GameManager.Instance.IsCollision())
                {
                    GameManager.Instance.PlaceSymbol();
                    GameManager.Instance.CurrentX = GameManager.Instance.GameWidth / 2;
                    GameManager.Instance.CurrentY = 0;
                }
                else
                {
                    GameManager.Instance.CurrentY++;
                }
                GameManager.Instance.GameDraw();
            }
        }
    }
}