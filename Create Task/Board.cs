using System;

namespace CreateTask
{
    public class Board
    {
        const int BOARD_X = 20;
        const int BOARD_Y = 30;

        private Coords[,] cells;
        private Snake _snake;
        private readonly int _width;
        private readonly int _height;

        public int Width => _width;
        public int Height => _height;

        public Board(Snake s, int Width = BOARD_X, int Height = BOARD_Y)
        {
            cells = new Coords[BOARD_X, BOARD_Y];
        }

        public Coords SpawnFood()
        {
            Random rand = new Random();
            Coords food;

            do
            {
                int X = (int)Math.Floor(rand.NextDouble() * Width);
                int Y = (int)Math.Floor(rand.NextDouble() * Height);
                food = new Coords(X, Y);
            } while (!HasSnake(food, _snake));

            return food;
        }

        public bool HasSnake(Coords c, Snake s)
        {
            foreach (Snake.Body i in s.body)
            {
                if (i.Coords.Equals(c))
                    return true;
            }
            return false;
        }
    }

    public struct Coords
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coords(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void SetX(int x)
        {
            this.X = x;
        }

        public void SetY(int y)
        {
            this.Y = y;
        }

        public bool Equals(Coords c)
        {
            if (c.X == this.X && c.Y == this.Y)
                return true;
            else
                return false;
        }
    }
}
