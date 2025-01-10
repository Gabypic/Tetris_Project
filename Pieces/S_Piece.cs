using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class S_Piece : GeneralPieces
    {
        private int state = 3;
        public S_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Green;
            Pop_Point = new Point(5, 0);
            InitializeBlocks();

        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X - 1, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X - 1, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X - 2, Pop_Point.Y + 1));
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
            }
        }
    }
}