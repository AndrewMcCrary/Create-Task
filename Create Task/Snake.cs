using System.Collections.Generic;

namespace CreateTask
{
    public class Snake
    {
        const Direction START_DIRECTION = Direction.left;
        const int START_X = 20;
        const int START_Y = 15;
        const int START_LENGTH = 4;

        public List<Body> body;
        private bool _dead;

        public bool Dead => _dead;

        public Snake(
            int StartX = START_X,
            int StartY = START_Y,
            Direction StartDirection = START_DIRECTION, 
            int StartLength = START_LENGTH)
        {
            _dead = false;
            // init starting length

            body = new List<Body>
            {
                new Body(new Coords(StartX, StartY), StartDirection)
            };


            for (int i = 0; i < StartLength - 1; i++)
                this.AddLength();
        }

        public void Kill()
        {
            _dead = true;
        }

        public void TurnHead(Direction dir)
        {
            if (dir != body[0].Direction && dir != GetInverse(dir))
                body[0].SetDirection(dir);
        }

        public void MoveAll()
        {
            if (_dead)
                return;

            for (int i = 0; i < body.Count; i++)
            {
                switch (body[i].Direction)
                {
                    case Direction.up:
                        body[i].Coords.SetY(body[i].Coords.Y + 1);
                        break;
                    case Direction.down:
                        body[i].Coords.SetY(body[i].Coords.Y - 1);
                        break;
                    case Direction.left:
                        body[i].Coords.SetX(body[i].Coords.X - 1);
                        break;
                    case Direction.right:
                        body[i].Coords.SetX(body[i].Coords.X + 1);
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
                    body.Add(new Body(new Coords(last.Coords.X, last.Coords.Y - 1), Direction.up));
                    break;
                case Direction.down:
                    body.Add(new Body(new Coords(last.Coords.X, last.Coords.Y + 1), Direction.down));
                    break;
                case Direction.left:
                    body.Add(new Body(new Coords(last.Coords.X + 1, last.Coords.Y), Direction.left));
                    break;
                case Direction.right:
                    body.Add(new Body(new Coords(last.Coords.X - 1, last.Coords.Y), Direction.right));
                    break;
            }
        }

        public struct Body
        {
            public Coords Coords { get; private set; }
            public Direction Direction { get; private set; }

            public Body(Coords c, Direction d)
            {
                this.Coords = c;
                this.Direction = d;
            }

            public void SetCoords(Coords c)
            {
                this.Coords = c;
            }

            public void SetDirection(Direction d)
            {
                this.Direction = d;
            }
        }

        public enum Direction
        {
            up = 0,
            down = 1,
            left = 2,
            right = 3
        }

        public Direction GetInverse(Direction dir)
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
