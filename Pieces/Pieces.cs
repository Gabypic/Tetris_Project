using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Game;

namespace Tetris.Pieces
{
    public abstract class GeneralPieces
    {
        protected GameManagement GameManagement { get; }
        public Color Color { get; protected set; }
        public List<Point> Blocks { get; protected set; }
        public Point Pop_Point { get; protected set; }
        private Form _gameForm;

        protected GeneralPieces(GameManagement gameManagement)
        {
            GameManagement = gameManagement;
            Blocks = new List<Point>();
        }

        protected abstract void InitializeBlocks();

        public void Place(Form form)
        {
            Console.WriteLine("hello there");
            foreach (var block in Blocks)
            {
                if (block.X >= 0 && block.X < GameManagement.GridWidth && block.Y >= 0 && block.Y < GameManagement.GridHeight)
                {
                    Console.WriteLine($"Block dans la grille : {block.X}, {block.Y}");
                    GameManagement.ColorCell(block.X, block.Y, Color, form);
                }
                else
                {
                    Console.WriteLine($"Block hors de la grille : {block.X}, {block.Y}");
                }
            }
        }

        public void Fall(Form form)
        {
            foreach (var block in Blocks)
            {
                GameManagement.FallRender(block.X, block.Y);
            }

            for (int i = 0; i < Blocks.Count; i++)
            {
                var block = Blocks[i];
                Blocks[i] = new Point(block.X, block.Y + 1);
                GameManagement.ColorCell(Blocks[i].X, Blocks[i].Y, Color, form);
            }
        }
    }
}
