using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class L_Piece : GeneralPieces
    {
        private int state = 0;

        public L_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Orange;
            Pop_Point = new Point(4, 0);
            InitializeBlocks();

        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y + 1));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
        }

        protected override void RotationStates()
        {
            Blocks.Clear();
            state = (state + 1) % 4;
            switch (state)
            {
                case 0:
                    Blocks.Add(new Point(Pop_Point.X + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 2 + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 2 + moveState, Pop_Point.Y + fallState));
                    break;

                case 1:
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 2 + fallState));
                    Blocks.Add(new Point(Pop_Point.X+2 + moveState, Pop_Point.Y + 2 + fallState));
                    break;

                case 2:
                    Blocks.Add(new Point(Pop_Point.X + moveState, Pop_Point.Y + 2 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 2 + moveState, Pop_Point.Y + 1 + fallState));
                    break;

                case 3:
                    Blocks.Add(new Point(Pop_Point.X + moveState, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1 + moveState, Pop_Point.Y + 2 + fallState));
                    break;
            }
        }
    }
}