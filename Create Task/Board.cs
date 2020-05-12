namespace CreateTask
{
    public class Board
    {
        const int BOARD_X = 20;
        const int BOARD_Y = 30;
        Cell food;


        Cell[,] cells = new Cell[BOARD_X, BOARD_Y];


    }

    public struct Cell
    {
        public int X { get; }
        public int Y { get; }
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }



}
