using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CreateTask
{
    class Program
    {
        const int TIME_BETWEEN_FRAMES = 250;
        static void Main(string[] args)
        {
            Board b = new Board(new Snake());
            int score = 0;
            while (!b.Dead)
            {
                Task.Run(() =>
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            b.Turnhead(Snake.Direction.up);
                            break;
                        case ConsoleKey.DownArrow:
                            b.Turnhead(Snake.Direction.down);
                            break;
                        case ConsoleKey.RightArrow:
                            b.Turnhead(Snake.Direction.right);
                            break;
                        case ConsoleKey.LeftArrow:
                            b.Turnhead(Snake.Direction.left);
                            break;
                    };
                });

                b.MoveSnake();
                if (b.Food.Equals(b.snake.body[0].Coords))
                {
                    b.AddLength();
                    b.SpawnFood();
                    score++;
                }



                Console.Clear();
                Console.WriteLine(b.FormString() + $"Score: {score}");
                //add length when run into food

                Thread.Sleep(TIME_BETWEEN_FRAMES);
            }
        }

        
    }
}
