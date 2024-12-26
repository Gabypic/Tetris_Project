using System;
using System.Collections.Generic;
using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class I_Piece
    {
        private GameManagement _gameManagement;
        public Color Color { get; private set; }
        public List<Point> Blocks { get; private set; }
        public Point Pop_Point { get; private set; }

        public I_Piece(GameManagement gameManagement)
        {
            _gameManagement = gameManagement;
            Color = Color.Cyan;
            Pop_Point = new Point(3, 1);
            InitializeBlocks();

        }

        private void InitializeBlocks()
        {
            Blocks = new List<Point>
            {
                new Point(Pop_Point.X, Pop_Point.Y),
                new Point(Pop_Point.X+1, Pop_Point.Y),
                new Point(Pop_Point.X+2, Pop_Point.Y),
                new Point(Pop_Point.X+3, Pop_Point.Y)
            };
        }

        public void Place()
        {
            foreach (var block in Blocks)
            {

                _gameManagement.ColorCell(block.X, block.Y, Color);
            }

        }
    }
}