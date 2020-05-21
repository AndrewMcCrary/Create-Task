using System;

namespace CreateTask
{
    public class Board
    {
        const int BOARD_X = 40;
        const int BOARD_Y = 20;

        const char SNAKE_BODY_CHAR = 'O';
        const char SNAKE_HEAD_UP = '∩';
        const char SNAKE_HEAD_DOWN = '╦';
        const char SNAKE_HEAD_LEFT = '«';
        const char SNAKE_HEAD_RIGHT = '»';
        const char FOOD_CHAR = 'Ω';

        private Coords[,] cells;
        private readonly Snake _snake;
        private readonly int _width;
        private readonly int _height;
        private Coords _food;

        public Coords Food => _food;
        public int Width => _width;
        public int Height => _height;
        public bool Dead => _snake.Dead;
        public Snake snake => _snake;

        public Board(Snake s, int Width = BOARD_X, int Height = BOARD_Y)
        {
            this._width = Width;
            this._height = Height;
            cells = new Coords[BOARD_X, BOARD_Y];
            _snake = s;
            SpawnFood();
        }

        public string FormString()
        {
            string str = string.Empty;
            int len;
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    len = str.Length;
                    if (j == 0 || j == Height - 1)
                    {
                        str += '─';
                        continue;
                    }
                    else if (i == 0 || i == Width - 1)
                    {
                        str += '│';
                        continue;
                    }

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
                        };

                    //death case on border
                    if (_snake.body[0].Coords.X == 2 || _snake.body[0].Coords.X == Width - 1)
                        _snake.Kill();
                    else if (_snake.body[0].Coords.Y == 2 || _snake.body[0].Coords.Y == Height - 1)
                        _snake.Kill();

                    if (Food.Equals(new Coords(i + 1, j + 1)))
                        str += FOOD_CHAR;

                    for (int b = 1; b < _snake.body.Count; b++)
                    {
                        if (_snake.body[b].Coords.Equals(new Coords(i + 1, j + 1)))
                            str += SNAKE_BODY_CHAR;
                    }

                    if (len == str.Length)
                        str += ' ';
                }
                str += '\n';
            }
            return str;
        }

        public void MoveSnake()
        {
            _snake.MoveAll();
        }

        public void AddLength()
        {
            _snake.AddLength();
        }

        public void Turnhead(Snake.Direction d)
        {
            _snake.TurnHead(d);
        }

        public void SpawnFood()
        {
            Random rand = new Random();
            Coords food;

            do
            {
                int X = (int)Math.Floor(rand.NextDouble() * Width);
                int Y = (int)Math.Floor(rand.NextDouble() * Height);
                food = new Coords(X, Y);
            } while (HasSnake(food, _snake) && !isBorder(food));

            _food = food;
        }

        public static bool HasSnake(Coords c, Snake s)
        {
            foreach (Snake.Body i in s.body)
            {
                if (i.Coords.Equals(c))
                    return true;
            }
            return false;
        }

        public bool isBorder(Coords c)
        {
            if ((c.X == 0 || c.X == Width - 1) || (c.Y == 0 || c.Y == Height - 1))
                return true;
            else
                return false;
        }
    }

    public struct Coords
    {
        public int X => _x;
        public int Y => _y;

        private int _x;
        private int _y;

        public Coords(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public void SetX(int x)
        {
            this._x = x;
        }

        public void SetY(int y)
        {
            this._y = y;
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
