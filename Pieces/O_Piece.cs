using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class O_Piece : GeneralPieces
    {
        public O_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Yellow;
            Pop_Point = new Point(4, 0);
            InitializeBlocks();

        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
        }

        protected override void RotationStates()
        {
            Blocks.Clear();
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + fallState));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + fallState));
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1 + fallState));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1 + fallState));
        }
    }
}