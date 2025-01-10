using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Pieces;

namespace Tetris.Game
{
    internal class RandomPiece
    {
        Random random = new Random();
        private GameManagement _gameManagement;
        private Form _gameForm;

        public RandomPiece(GameManagement gameManagement)
        {
            _gameManagement = gameManagement;
        }

        public GeneralPieces NewRandomPiece()
        {
            int randomPiece = random.Next(0, 7);
            switch (randomPiece)
            {
                case 0:
                    return new I_Piece(_gameManagement);
                case 1:
                    return new J_Piece(_gameManagement);
                case 2:
                    return new L_Piece(_gameManagement);
                case 3:
                    return new O_Piece(_gameManagement);
                case 4: 
                    return new S_Piece(_gameManagement);
                case 5:
                    return new T_Piece(_gameManagement);
                case 6: 
                    return new Z_Piece(_gameManagement);
            }
            return new I_Piece(_gameManagement);
        }
    }
}
