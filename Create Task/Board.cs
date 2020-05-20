using System;

namespace CreateTask
{
    public class Board
    {
        const int BOARD_X = 20;
        const int BOARD_Y = 30;

        const char SNAKE_BODY_CHAR = 'O';
        const char SNAKE_HEAD_UP = '∩';
        const char SNAKE_HEAD_DOWN = '╦';
        const char SNAKE_HEAD_LEFT = '«';
        const char SNAKE_HEAD_RIGHT = '»';
        const char FOOD_CHAR = 'Ω';


        private Coords[,] cells;
        private Snake _snake;
        private readonly int _width;
        private readonly int _height;

        public int Width => _width;
        public int Height => _height;

        public Board(Snake s, int Width = BOARD_X, int Height = BOARD_Y)
        {
            this._width = Width;
            this._height = Height;
            cells = new Coords[BOARD_X, BOARD_Y];
        }

        public string FormString()
        {
            string str = string.Empty;
            int len = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    len = str.Length;
                    if (_snake.body[0].Coords.Equals(new Coords(i + 1, j + 1)))
                        switch (_snake.body[0].Direction)
                        {
                            case Snake.Direction.up:
                                str += SNAKE_HEAD_UP;
                                break;
                            case Snake.Direction.down:
                                str += SNAKE_HEAD_DOWN;
                                break;
                            case Snake.Direction.left:
                                str += SNAKE_HEAD_LEFT;
                                break;
                            case Snake.Direction.right:
                                str += SNAKE_HEAD_RIGHT;
                                break;
                        }

                    for (int b = 1; b < _snake.body.Count; b++)
                    {
                        if (_snake.body[b].Coords.Equals(new Coords(i, j)))
                            str += SNAKE_BODY_CHAR;
                    }

                    if (len == str.Length - 1)
                        str += ' ';
                }
                str += '\n';
            }


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
