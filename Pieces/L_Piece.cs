using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class L_Piece : GeneralPieces
    {

        public L_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Orange;
            Pop_Point = new Point(4, 0);
            InitializeBlocks();

        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y+1));
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y+2));
            Blocks.Add(new Point(Pop_Point.X+1, Pop_Point.Y+2));
        }
    }
}