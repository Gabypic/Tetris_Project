using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
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
        public int fallState = 0;
        public bool fallCompleted;

        protected GeneralPieces(GameManagement gameManagement)
        {
            GameManagement = gameManagement;
            Blocks = new List<Point>();
        }

        protected abstract void InitializeBlocks();
        protected abstract void RotationStates();

        public void Place(Form form)
        {
            Console.WriteLine("hello there");
            GameManagement.ColorCell(Blocks, Color, form);
        }

        public bool Fall(Form form)
        {
            fallState += 1;
            foreach (var block in Blocks)
            {
                GameManagement.ChangeRender(block.X, block.Y);
            }
            fallCompleted = GameManagement.ColorCell(Blocks, Color, form);
            if (fallCompleted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveRightLeft(Form form, int direction)
        {
            if (form == null)
            {
                return;
            }
            foreach (var block in Blocks)
            {
                GameManagement.ChangeRender(block.X, block.Y);
            }

            for (int i = 0; i < Blocks.Count; i++)
            {
                var block = Blocks[i];
                Blocks[i] = new Point(block.X + direction, block.Y);
            }
        }

        public void Turn(Form form)
        {
            if (form == null)
            {
                return;
            }
            foreach(var block in Blocks)
            {
                GameManagement.ChangeRender(block.X, block.Y);
            }
            RotationStates();
            Place(form);
        }
    }
}
