using System;
using System.Drawing;

namespace Tetris.Game
{
    public class GameManagement
    {
        public const int GridWidth = 10; // Largeur de la grille
        public const int GridHeight = 20; // Hauteur de la grille
        public Color[,] Grid { get; private set; }

        public GameManagement()
        {
            // Initialisation de la grille (10x20), chaque case par défaut est blanche
            Grid = new Color[GridWidth, GridHeight];
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    Grid[x, y] = Color.Black; // Initialement, toutes les cases sont blanches
                }
            }
        }

        // Méthode pour colorier une case spécifique
        public void ColorCell(int x, int y, Color color)
        {
            if (x >= 0 && x < GridWidth && y >= 0 && y < GridHeight)
            {
                Grid[x, y] = color;
            }
        }
    }
}
