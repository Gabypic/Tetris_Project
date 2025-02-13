﻿using System;
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
        private Running _running;

        private void Game_Load(object sender, EventArgs e)
        {
        }

        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    pressedKey = "D";
                    break;

                case Keys.Q:
                    pressedKey = "Q";
                    break;

                case Keys.Z:
                    pressedKey = "Z";
                    break;

                case Keys.S:
                    pressedKey = "S";
                    break;

                case Keys.C:
                    pressedKey = "C";
                    break;

                case Keys.Space:
                    pressedKey = " ";
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

            this.FormClosed += Game_FormClosed;

            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            _gameManagement = new GameManagement();
            Console.WriteLine(_gameManagement);

            _running = new Running(this, _gameManagement);

            Task.Run(() =>
            {
                _running.LaunchGame();
            });
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellWidth = 30;
            int cellHeight = 30;
            int startX = (this.ClientSize.Width - (GameManagement.GridWidth * cellWidth)) / 3;
            int startY = (this.ClientSize.Height - (GameManagement.GridHeight * cellHeight)) / 2;

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
                            g.FillRectangle(brush, posX, posY, cellWidth, cellHeight);
                        }
                    }
                }
            }

            using (Pen neonPen = new Pen(Color.FromArgb(0, 197, 255), 3))
            {
                g.DrawRectangle(neonPen, startX, startY, GameManagement.GridWidth * cellWidth, GameManagement.GridHeight * cellHeight);
            }

            int miniGridCellSize = 20;
            int nextGridStartX = this.ClientSize.Width - 110;
            int nextGridStartY = 110;
            int holdGridStartX = this.ClientSize.Width - 110;
            int holdGridStartY = 320;

            DrawGridWithFilledCells(g, nextGridStartX, nextGridStartY, miniGridCellSize, 4, 4);
            DrawGridWithFilledCells(g, holdGridStartX, holdGridStartY, miniGridCellSize, 4, 4);
        }

        private void DrawGridWithFilledCells(Graphics g, int startX, int startY, int cellSize, int rows, int cols)
        {
            using (Brush blackBrush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int x = startX + j * cellSize;
                        int y = startY + i * cellSize;
                        g.FillRectangle(blackBrush, x, y, cellSize, cellSize);
                    }
                }
            }

            using (Pen borderPen = new Pen(Color.FromArgb(0, 197, 255), 3))
            {
                g.DrawRectangle(borderPen, startX, startY, cols * cellSize, rows * cellSize);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Game_Paint(this, e);
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopGame();
        }

        private void StopGame()
        {
            _running.StopGame();
            Console.WriteLine("Le jeu a été arrêté proprement.");
        }
    }
}
