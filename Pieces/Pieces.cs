using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
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
        public int fallState = 0;
        public int moveState = 0;

        protected GeneralPieces(GameManagement gameManagement)
        {
            GameManagement = gameManagement;
            Blocks = new List<Point>();
        }

        protected abstract void InitializeBlocks();
        protected abstract void RotationStates();

        public void Place(Form form)
        {
            GameManagement.ColorCell(Blocks, Color, form);
        }

        public bool Fall(Form form)
        {
            fallState++;

            bool shouldStopFalling = false;

            foreach (var block in Blocks)
            {
                if (block.Y + 1 >= GameManagement.GridHeight || 
                    (GameManagement.Grid[block.X, block.Y + 1] != Color.Black &&
                     GameManagement.Grid[block.X, block.Y + 1] != Color))
                {
                    shouldStopFalling = true;
                    break;
                }
            }

            if (shouldStopFalling)
            {
                Color finalColor;
                foreach (var block in Blocks)
                {
                    finalColor = GameManagement.DarkenColor(Color, 0.2f);
                    GameManagement.Grid[block.X, block.Y] = finalColor;
                }
                return true;
            }

            var updatedBlocks = new List<Point>();
            foreach (var block in Blocks)
            {
                updatedBlocks.Add(new Point(block.X, block.Y + 1));
                GameManagement.ChangeRender(block.X, block.Y);
            }

            Blocks = updatedBlocks;

            GameManagement.ColorCell(Blocks, Color, form);

            return false;
        }


        public void MoveRightLeft(Form form, int direction)
        {
            moveState += direction;
            bool canMove = true;
            if (form == null)
            {
                return;
            }

            foreach (var block in Blocks)
            {
                int newX = block.X + direction;
                if (newX >= GameManagement.GridWidth || newX < 0 || 
                    (GameManagement.Grid[block.X + direction, block.Y] != Color.Black &&
                     GameManagement.Grid[block.X + direction, block.Y] != Color))
                {
                    canMove = false;
                    break;
                }
            }

            if (canMove)
            {
                foreach (var block in Blocks)
                {
                    GameManagement.ChangeRender(block.X, block.Y);
                }
                for (int i = 0; i < Blocks.Count; i++)
                {
                    var block = Blocks[i];
                    Blocks[i] = new Point(block.X + direction, block.Y);
                }
                GameManagement.ColorCell(Blocks, Color, form);
            }
        }

        public void Turn(Form form)
        {
            if (form == null)
            {
                return;
            }

            foreach (var block in Blocks)
            {
                GameManagement.ChangeRender(block.X, block.Y);
            }

            var originalState = new List<Point>(Blocks);
            var validRotation = true;

            RotationStates();

            foreach (var block in Blocks)
            {
                if (block.X < 0 || block.X >= GameManagement.GridWidth ||
                    block.Y < 0 || block.Y >= GameManagement.GridHeight)
                {
                    validRotation = false;
                    break;
                }

                if (GameManagement.Grid[block.X, block.Y] != Color.Black &&
                    GameManagement.Grid[block.X, block.Y] != Color)
                {
                    validRotation = false;
                    break;
                }
            }

            if (!validRotation)
            {
                Blocks = originalState;
                Place(form);
                return;
            }

            foreach (var block in Blocks)
            {
                Console.WriteLine("tu vient la ?");
                GameManagement.ChangeRender(block.X, block.Y);
            }
            Place(form);
        }
    }
}
