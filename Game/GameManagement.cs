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
                if (block.X < 0 || block.X >= GridWidth || block.Y >= GridHeight)
                {
                    Console.WriteLine($"Bloc hors cadre : {block}");
                    notFullDown = false;
                    return notFullDown;
                }
                if (block.Y + 1 < GridHeight && Grid[block.X, block.Y + 1] != Color.Black)
                {
                    Console.WriteLine($"Collision détectée pour le bloc : {block}");
                    notFullDown = true;
                    return notFullDown;
                }
                if (block.Y == GridHeight - 1)
                {
                    Console.WriteLine("La pièce a atteint le bas de la grille.");
                    notFullDown = true;
                    return notFullDown;
                }
            }
            if (!notFullDown)
            {
                foreach (var block in blocks)
                {
                    Console.WriteLine($"Coloration : {color} sur {block}");
                    Grid[block.X, block.Y] = color;

                    form.Invoke((MethodInvoker)delegate
                    {
                        form.Invalidate();
                    });
                }
            }

            return notFullDown;
        }


        public void ChangeRender(int x, int y)
        {
            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                Grid[x, y] = Color.Black;
            }
        }
    }
}
