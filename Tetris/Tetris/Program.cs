using System;
using System.Threading;

namespace Tetris;

using Tetris.Services;
public class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        FormService form = new FormService();
        var kvadrat = form.GetSquer();
        var stick = form.GetStick();
        List<object> list= new List<object>();
        list.Add(kvadrat);
        list.Add(stick);
        int randomayzer = 0;
        while (true)
        {
            Thread.Sleep(200);
            GameManager.Instance.HandleInput();
            if (GameManager.Instance.IsCollision())
            {
                GameManager.Instance.PlaceSymbol(list[randomayzer]);
                GameManager.Instance.CurrentX = GameManager.Instance.GameWidth / 2;
                GameManager.Instance.CurrentY = 0;
                randomayzer = Random.Shared.Next(0, 2);
            }
            else
            {
                GameManager.Instance.CurrentY++;
            }
            GameManager.Instance.GameDraw(list[randomayzer]);
        }
    }
}