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
        static bool loose = false;
        static int score = 0;
        static double speed = 1000;
        static double increase_speed = 50;
        private GeneralPieces? Piece;
        private GameManagement? _gameManagement;
        private Form _gameForm;
        private bool fullFall;

        public Running(Form gameForm, GameManagement gameManagement)
        {
            _gameForm = gameForm;
            _gameManagement = gameManagement;
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

            timer = new System.Timers.Timer(speed);
            timer.Start();

            try
            {
                if (_gameForm != null && !_gameForm.IsDisposed && _gameForm.Visible)
                {
                    Console.WriteLine("Avant Invalidate");
                    _gameForm.BeginInvoke((MethodInvoker)delegate
                    {
                        Console.WriteLine("Invalidate via BeginInvoke");
                        _gameForm.Invalidate();
                    });
                    Application.DoEvents();

                    Console.WriteLine("Après Invalidate");
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
                if (fullFall)
                {
                    Piece = new RandomPiece(_gameManagement).NewRandomPiece();
                    Piece.Place(_gameForm);
                }
                string lastPressedKey = (_gameForm as Game)?.GetPressedKey();
                if (!string.IsNullOrEmpty(lastPressedKey))
                {
                    Console.WriteLine($"Key pressed: {lastPressedKey}");
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
                        Console.WriteLine(lastPressedKey);
                        Piece.Turn(_gameForm);
                    }
                    (_gameForm as Game).pressedKey = "";
                }

                fullFall = Piece.Fall(_gameForm);
                Console.WriteLine("Score: " + score);
                score += 10;
                AdjustTimerSpeed();
                Thread.Sleep(1000);
            }

            timer.Stop();
            Console.WriteLine("Timer Stopped");
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer déclenché à " + DateTime.Now);
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
    }
}
