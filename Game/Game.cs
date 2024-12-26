using System;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Pieces;

namespace Tetris.Game
{
    public partial class Game : Form
    {
        private GameManagement _gameManagement;
        private I_Piece TestPieces;

        private void Game_Load(object sender, EventArgs e)
        {
        }

        public Game()
        {
            InitializeComponent();
            _gameManagement = new GameManagement();
            TestPieces = new I_Piece(_gameManagement);
            TestPieces.Place();
        }

        // Méthode pour dessiner la grille
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellWidth = 30; // Largeur d'une cellule
            int cellHeight = 30; // Hauteur d'une cellule

            // Calculer la position pour centrer la grille
            int startX = (this.ClientSize.Width - (GameManagement.GridWidth * cellWidth)) / 2;
            int startY = (this.ClientSize.Height - (GameManagement.GridHeight * cellHeight)) / 2;

            // Dessiner chaque case de la grille
            for (int x = 0; x < GameManagement.GridWidth; x++)
            {
                for (int y = 0; y < GameManagement.GridHeight; y++)
                {
                    // Calculer la position de la case (en prenant en compte le centrage)
                    int posX = startX + x * cellWidth;
                    int posY = startY + y * cellHeight;

                    // Dessiner la case avec la couleur de la grille
                    using (Brush brush = new SolidBrush(_gameManagement.Grid[x, y]))
                    {
                        g.FillRectangle(brush, posX, posY, cellWidth, cellHeight);
                    }
                }
            }

            // Dessiner le contour extérieur de la grille en bleu néon
            using (Pen neonPen = new Pen(Color.FromArgb(0, 197, 255), 3)) // Bleu néon
            {
                // Dessiner le contour extérieur
                g.DrawRectangle(neonPen, startX, startY, GameManagement.GridWidth * cellWidth, GameManagement.GridHeight * cellHeight);
            }
        }

        // N'oubliez pas d'ajouter un gestionnaire d'événements pour le redessin
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Game_Paint(this, e); // Appeler notre méthode de dessin
        }
    }
}
