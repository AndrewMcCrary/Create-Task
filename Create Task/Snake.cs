using System.Collections.Generic;

namespace CreateTask
{
    public class Snake
    {
        const Direction START_DIRECTION = Direction.left;
        const int START_X = 20;
        const int START_Y = 15;
        const int START_LENGTH = 4;

        private List<Body> body;


        public Snake(
            int StartX = START_X,
            int StartY = START_Y,
            Direction StartDirection = START_DIRECTION, 
            int StartLength = START_LENGTH)
        {
            // init starting length





        }



        public void TurnHead(Direction dir)
        {
            if (dir != body[0].Direction && dir != GetInverse(dir))
                body[0].SetDirection(dir);
        }

        public void MoveAll()
        {
            for (int i = 0; i < body.Count; i++)
            {
                switch (body[i].Direction)
                {
                    case Direction.up:
                        body[i].SetY(body[i].Y + 1);
                        break;
                    case Direction.down:
                        body[i].SetY(body[i].Y - 1);
                        break;
                    case Direction.left:
                        body[i].SetX(body[i].X - 1);
                        break;
                    case Direction.right:
                        body[i].SetX(body[i].X + 1);
                        break;
                }

                if (i != 0)
                    body[i].SetDirection(body[i - 1].Direction);
            }
        }

        /// <summary>
        /// Need to move then AddLength
        /// </summary>
        public void AddLength()
        {
            Body last = body[body.Count - 1];
            switch (last.Direction)
            {
                case Direction.up:
                    body.Add(new Body(last.X, last.Y - 1, Direction.up));
                    break;
                case Direction.down:
                    body.Add(new Body(last.X, last.Y + 1, Direction.down));
                    break;
                case Direction.left:
                    body.Add(new Body(last.X + 1, last.Y, Direction.left));
                    break;
                case Direction.right:
                    body.Add(new Body(last.X - 1, last.Y, Direction.right));
                    break;
            }
        }

        public struct Body
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public Direction Direction { get; set; }

            public Body(int x, int y, Direction dir)
            {
                this.X = x;
                this.Y = y;
                this.Direction = dir;
            }

            public void SetX(int i)
            {
                this.X = i;
            }

            public void SetY(int i)
            {
                this.Y = i;
            }

            public void SetDirection(Direction dir)
            {
                this.Direction = dir;
            }
        }

        public enum Direction
        {
            up = 0,
            down = 1,
            left = 2,
            right = 3
        }

        private Direction GetInverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.up:
                    dir = Direction.down;
                    break;
                case Direction.down:
                    dir = Direction.up;
                    break;
                case Direction.left:
                    dir = Direction.right;
                    break;
                case Direction.right:
                    dir = Direction.left;
                    break;
            }
            return dir;
        }
    }
}
