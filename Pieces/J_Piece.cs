using System.Drawing;
using Tetris.Game;
using static System.Windows.Forms.AxHost;

namespace Tetris.Pieces
{
    internal class J_Piece : GeneralPieces
    {
        private int state = 3;
        public J_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Blue;
            Pop_Point = new Point(4, 0);
            InitializeBlocks();
        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
        }

        protected override void RotationStates()
        {
            state += 1;
            if (state >= 4)
            {
                state = 0;
            }
            if (state == 0)
            {
                Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
            }
            if (state == 1)
            {
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 2));
            }
            if (state == 2) 
            {
                Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
            }
            if (state == 3) 
            {
                Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
            }
        }
    }
}
