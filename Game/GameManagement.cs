using System;
using System.Drawing;
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

        public void ColorCell(int x, int y, Color color, Form form)
        {
            Console.WriteLine("ici colorcell ?");
            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                Console.WriteLine(color.ToString() + " " + form);
                Grid[x, y] = color;
                form.Invoke((MethodInvoker)delegate {
                    Console.WriteLine("tu entre ici ?");
                    form.Invalidate();
                });
                Console.WriteLine("tu entre pas, mais au moins tu sort ?");
            }
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
