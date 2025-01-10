﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class S_Piece : GeneralPieces
    {
        private int state = 0;
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
            state = (state + 1) % 2;

            switch (state)
            {
                case 0:
                    Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X - 1, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X - 1, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X - 2, Pop_Point.Y + 1 + fallState));
                    break;

                case 1:
                    Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + fallState));
                    Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 1 + fallState));
                    Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y + 2 + fallState));
                    break;
            }
        }
    }
}