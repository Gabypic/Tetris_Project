using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualBasic.Devices;
using Tetris.Pieces;

namespace Tetris.Game
{
    public class Running
    {
        static System.Timers.Timer? timer;
        private bool loose = false;
        static int score = 0;
        static double speed = 1000;
        static double increase_speed = 50;
        private GeneralPieces? Piece;
        private GameManagement? _gameManagement;
        private PiecesManagement _piecesControl;
        private Form _gameForm;
        private int fullFall;
        private System.Timers.Timer movementTimer;
        private bool askHold = false; 

        public Running(Form gameForm, GameManagement gameManagement)
        {
            _gameForm = gameForm;
            _gameManagement = gameManagement;
            _piecesControl = new PiecesManagement(_gameManagement);

            movementTimer = new System.Timers.Timer(50);
            movementTimer.Elapsed += (sender, e) => Movement();
            movementTimer.Start();
        }

        public void LaunchGame()
        {
            System.Threading.Thread.Sleep(1000);
            if (_gameForm == null)
            {
                Console.WriteLine("Erreur : _gameForm est null.");
                return;
            }

            if (_gameManagement == null)
            {
                Console.WriteLine("Erreur : _gameManagement est null.");
                return;
            }

            if (_piecesControl == null)
            {
                Console.WriteLine("Erreur = _piecesControl est null.");
                return;
            }

            timer = new System.Timers.Timer(speed);
            timer.Start();

            try
            {
                if (_gameForm != null && !_gameForm.IsDisposed && _gameForm.Visible)
                {
                    _gameForm.BeginInvoke((MethodInvoker)delegate
                    {
                        _gameForm.Invalidate();
                    });
                    Application.DoEvents();
                }
                else
                {
                    Console.WriteLine("Erreur : _gameForm est soit fermé, soit invisible.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'appel à Invalidate : {ex.Message}");
            }
            

            while (!loose)
            {
                if (fullFall == 1 || score <= 0 || Piece == null)
                {
                    _gameManagement.CheckFullLines();
                    Piece = new PiecesManagement(_gameManagement).NewRandomPiece();
                    Piece.Place(_gameForm);
                }

                if (askHold)
                {
                    Piece.DeletePiece(_gameForm);
                    Piece = _piecesControl.PieceHolder(Piece);
                    if (Piece != null)
                        Piece.Place(_gameForm);
                    askHold = false;
                }
                if (Piece != null)
                    fullFall = Piece.Fall(_gameForm);
                    if (fullFall == 2) 
                        loose = true;
                Console.WriteLine(loose);
                score += 10;
                AdjustTimerSpeed();
                Thread.Sleep(800);
            }

            StopGame();
        }

        private static void AdjustTimerSpeed()
        {
            if (timer != null)
            {
                double targetInterval = 1000 - (score / 10) * increase_speed;

                if (targetInterval < 100)
                {
                    targetInterval = 100;
                }

                timer.Interval = targetInterval;
            }
        }

        public void Movement()
        {
            string lastPressedKey = (_gameForm as Game)?.GetPressedKey();
            if (!string.IsNullOrEmpty(lastPressedKey))
            {
                if (lastPressedKey == "D")
                {
                    Piece.MoveRightLeft(_gameForm, 1);
                }
                if (lastPressedKey == "Q")
                {
                    Piece.MoveRightLeft(_gameForm, -1);
                }
                if (lastPressedKey == "Z")
                {
                    Piece.Turn(_gameForm);
                }
                if (lastPressedKey == "S")
                {
                    Piece.Fall(_gameForm);
                }
                if (lastPressedKey == "C")
                {
                    askHold = true;
                }
                if (lastPressedKey == " ")
                {
                    Piece.InstantFall(_gameForm);
                }
                (_gameForm as Game).pressedKey = "";
            }

            (_gameForm as Game).pressedKey = "";
            _gameForm.BeginInvoke((MethodInvoker)delegate
            {
                _gameForm.Refresh();
            });

        }

        public void StopGame()
        {
            loose = true;
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            if (movementTimer != null)
            {
                movementTimer.Stop();
                movementTimer.Dispose();
            }
        }

    }
}
