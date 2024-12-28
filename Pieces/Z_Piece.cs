using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class Z_Piece : GeneralPieces
    {
        public Z_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Red;
            Pop_Point = new Point(3, 0);
            InitializeBlocks();

        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X+1, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X+1, Pop_Point.Y+1));
            Blocks.Add(new Point(Pop_Point.X+2, Pop_Point.Y+1));
        }
    }
}
