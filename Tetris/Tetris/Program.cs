using System;
using System.Threading;

namespace Tetris;


using Tetris.Elements.Base;
using Tetris.Services;
public class Program
{
    static void Main()
    {
        Console.WriteLine("You can use <- ->");
        Console.ReadKey();
        //Zapuskayte vsyo taki) level menayetsa dobavlayetsa noviy element
        Console.CursorVisible = false;
        int speed = 200;
        bool Level = false; 

        int count = 0;
        FormService form = new FormService();
        var kvadrat = form.GetSquer();
        var stick = form.GetStick();
        var razqonutaya = form.GetNewLevelForm();
        List<Element> list= new List<Element>();
        list.Add(kvadrat);
        list.Add(stick);
        list.Add(razqonutaya);
        int randomayzer = 0;
        int randomayzerY = 2;
        while (true)
        {

            if (Level)
            {
                randomayzerY = 3;
                speed = 50;
            }
            Thread.Sleep(speed);
            GameManager.Instance.HandleInput();
            if (GameManager.Instance.CurrentY == GameManager.Instance.GameHeight)
            {
                count++;
                GameManager.Instance.CurrentX = GameManager.Instance.GameWidth / 2;
                GameManager.Instance.CurrentY = 0;
                randomayzer = Random.Shared.Next(0, randomayzerY);
                if (count == 3)
                {
                    Level = true;
                }
            }
            else
            {
                GameManager.Instance.CurrentY++;
            }
            GameManager.Instance.GameDraw(list[randomayzer]);
            
        }
    }
}