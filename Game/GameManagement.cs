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
        private bool canFall;


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
            canFall = true;
            Console.WriteLine("ici colorcell ?");
            foreach (var block in blocks)
            {
                if (!(block.X >= 0 && block.X < GridWidth && block.Y >= 0 && block.Y < GridHeight))
                {
                    canFall = false;
                }
            }
            if (canFall)
            {
                foreach (var block in blocks)
                {
                    Console.WriteLine(color.ToString() + " " + form);
                    Grid[block.X, block.Y] = color;
                    form.Invoke((MethodInvoker)delegate
                    {
                        Console.WriteLine("tu entre ici ?");
                        form.Invalidate();
                    });
                    Console.WriteLine("tu entre pas, mais au moins tu sort ?");
                    return false;
                }
            }
            return true;
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
