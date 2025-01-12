using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Tetris.Pieces;

namespace Tetris.Game
{
    public class GameManagement
    {
        public const int GridWidth = 10;
        public const int GridHeight = 20;
        public Color[,] Grid { get; set; }
        private Form _gameForm;
        private bool notFullDown;


        public GameManagement(Form gameForm)
        {
            _gameForm = gameForm;
            Grid = new Color[GridWidth, GridHeight];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
                {
                    Grid[x, y] = Color.Black;
                }
            }
        }

        public GameManagement()
        {
            Grid = new Color[GridWidth, GridHeight];
            InitializeGrid();
        }

        public bool ColorCell(List<Point> blocks, Color color, Form form)
        {
            notFullDown = false;

            foreach (var block in blocks)
            {
                if (block.X < 0 || block.X >= GridWidth || block.Y > GridHeight)
                {
                    notFullDown = false;
                    return notFullDown;
                }

                if (block.Y == GridHeight)
                {
                    notFullDown = true;
                    return notFullDown;
                }
            }

            if (!notFullDown)
            {
                foreach (var block in blocks)
                {
                    Grid[block.X, block.Y] = color;
                }

                form.Invoke((MethodInvoker)delegate
                {
                    form.Invalidate();
                });
            }
            return notFullDown;
        }



        public void ChangeRender(int x, int y)
        {
            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                if (Grid[x, y] == Color.Black)
                    return;

                Grid[x, y] = Color.Black;
            }
        }

        public void CheckFullLines()
        {
            for (int y = 0; y < GridHeight; y++)
            {
                bool isFullLine = true;
                for (int x = 0; x < GridWidth; x++)
                {
                    if (Grid[x, y] == Color.Black)
                    {
                        isFullLine = false;
                        break;
                    }
                }

                if (isFullLine)
                {
                    ClearLine(y);
                }
            }
        }

        private void ClearLine(int y)
        {
            for (int x = 0; x < GridWidth; x++)
            {
                Grid[x, y] = Color.Black;
            }

            for (int j = y; j > 0; j--)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Grid[x, j] = Grid[x, j - 1];
                }
            }
        }

        public Color DarkenColor(Color originalColor, float percentage)
        {
            int r = (int)(originalColor.R * (1 - percentage));
            int g = (int)(originalColor.G * (1 - percentage));
            int b = (int)(originalColor.B * (1 - percentage));

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return Color.FromArgb(originalColor.A, r, g, b);
        }
    }
}
