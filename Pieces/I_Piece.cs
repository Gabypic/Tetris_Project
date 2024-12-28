using System.Drawing;
using Tetris.Game;

namespace Tetris.Pieces
{
    internal class I_Piece : GeneralPieces
    {
        public I_Piece(GameManagement gameManagement) : base(gameManagement)
        {
            Color = Color.Cyan;
            Pop_Point = new Point(3, 1);
            InitializeBlocks();
        }

        protected override void InitializeBlocks()
        {
            Blocks.Add(new Point(Pop_Point.X, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X + 1, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X + 2, Pop_Point.Y));
            Blocks.Add(new Point(Pop_Point.X + 3, Pop_Point.Y));
        }
    }
}
