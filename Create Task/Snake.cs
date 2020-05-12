using System.Collections.Generic;

namespace CreateTask
{
    public class Snake
    {
        //starting conditions
        const direction STARTINGDIRECTION = direction.left;
        const int STARTINGX = 20;
        const int STARTINGY = 15;
        const int STARTINGLENGTH = 5;
        const int REFRESHRATE = 2; //Cells per second

        public List<snake> body = new List<snake>();

        public void start()
        {
            body.Add(new snake(STARTINGX, STARTINGY, STARTINGDIRECTION));
            while (body.Count <= STARTINGLENGTH - 1)
            {
                addLength(body[body.Count - 1]);
            }

        }

        public void addLength(snake last)
        {
            switch (last.Direction)
            {
                case direction.up:
                    body.Add(new snake(last.X, last.Y - 1, last.Direction));
                    break;

                case direction.left:
                    body.Add(new snake(last.X + 1, last.Y, last.Direction));
                    break;

                case direction.right:
                    body.Add(new snake(last.X - 1, last.Y, last.Direction));
                    break;

                case direction.down:
                    body.Add(new snake(last.X, last.Y + 1, last.Direction));
                    break;
            }
        }

        public void refresh()
        {
            for (int i = 0; body.Count > i; i++)
            {
                switch (body[i].Direction)
                {
                    case direction.up:
                        body[i].Y++;
                        break;

                    case direction.left:
                        
                        break;

                    case direction.right:
                        
                        break;

                    case direction.down:
                        
                        break;
                }

            }

        }

        public struct snake
        {
            public int X { get; set; }
            public int Y { get; set; }
            public direction Direction { get; set; }

            public snake(int x, int y, direction d)
            {
                this.X = x;
                this.Y = y;
                this.Direction = d;
            }

            public void move()
            {
                switch (this.Direction)
                {
                    case direction.up:
                        
                        break;

                    case direction.left:

                        break;

                    case direction.right:

                        break;

                    case direction.down:

                        break;
                }

            }

        }
        public enum direction
        {
            up = 0,
            right = 1,
            left = 2,
            down = 3

        }




    }
}
