using System;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class I_Piece : GeneralPieces
        {
        private int state = 3;
        public I_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Cyan;
            Pop_Point = new Point(3, 1);
            InitializeBlocks();
        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y - 1));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 2));
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
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 3, Pop_Point.Y));
            }

            if (state == 1)
            {
                Blocks.Add(new Point(Pop_Point.X+2, Pop_Point.Y-1));
                Blocks.Add(new Point(Pop_Point.X+2, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y+1));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y+2));
            }

            if (state == 2)
            {
                Blocks.Add(new Point(Pop_Point.X , Pop_Point.Y +1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 3, Pop_Point.Y + 1));
            }

            if (state == 3)
            {
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y - 1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
                Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 2));
            }

        }
    }
}
