using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Tetris.Pieces;

namespace Tetris.Game
{
    public partial class Game : Form
    {
        private GameManagement _gameManagement;
        public string pressedKey = "";

        private void Game_Load(object sender, EventArgs e)
        {
        }

        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            {
                case Keys.D:
                    Console.WriteLine("hello rayou");
                    pressedKey = "D";
                    break;

                case Keys.Q:
                    Console.WriteLine("Merci Rayou");
                    pressedKey = "Q";
                    break;

                default:
                    return;
            }
        }

        public string GetPressedKey()
        {
            return pressedKey;
        }


        public Game()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            _gameManagement = new GameManagement();
            Console.WriteLine(_gameManagement);

            Task.Run(() =>
            {
                Running run = new Running(this, _gameManagement);
                run.LaunchGame();
            });
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellWidth = 30;
            int cellHeight = 30;

            int startX = (this.ClientSize.Width - (GameManagement.GridWidth * cellWidth)) / 2;
            int startY = (this.ClientSize.Height - (GameManagement.GridHeight * cellHeight)) / 2;

            if (_gameManagement == null || _gameManagement.Grid == null)
            {
                Console.WriteLine("Erreur : _gameManagement ou la grille n'est pas initialisé.");
                return;
            }

            for (int x = 0; x < _gameManagement.Grid.GetLength(0); x++)
            {
                for (int y = 0; y < _gameManagement.Grid.GetLength(1); y++)
                {
                    int posX = startX + x * cellWidth;
                    int posY = startY + y * cellHeight;
                    var color = _gameManagement.Grid[x, y];

                    if (color != Color.Empty)
                    {
                        using (Brush brush = new SolidBrush(color))
                        {
                            e.Graphics.FillRectangle(brush, posX, posY, cellWidth, cellHeight);
                        }
                    }
                }
            }
            using (Pen neonPen = new Pen(Color.FromArgb(0, 197, 255), 3))
            {
                g.DrawRectangle(neonPen, startX, startY, GameManagement.GridWidth * cellWidth, GameManagement.GridHeight * cellHeight);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Game_Paint(this, e);
        }
    }
}
