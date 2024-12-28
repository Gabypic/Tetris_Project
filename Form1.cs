using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private bool isHovered = false;
        private Point originalLocation;

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            originalLocation = button1.Location;

            button1.Paint += Button1_Paint;
            button1.MouseEnter += Button1_MouseEnter;
            button1.MouseLeave += Button1_MouseLeave;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Tetris.Game.Game game = new Tetris.Game.Game();
            this.Hide();
            game.FormClosed += (s, args) => this.Show();
            game.Show();
           
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;

            button1.Size = new Size(button1.Width + 1, button1.Height + 1);
            button1.Invalidate();
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;

            button1.Size = new Size(button1.Width - 1, button1.Height - 1);
            button1.Invalidate();
        }

        private void Button1_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;

            Color neonOrange = Color.FromArgb(255, 165, 0);
            using (Pen neonPen = new Pen(neonOrange, 3))
            {
                e.Graphics.DrawRectangle(neonPen, 1, 1, btn.Width - 3, btn.Height - 3);
            }

            if (isHovered)
            {
                using (Pen glowPen = new Pen(Color.FromArgb(255, 255, 0), 5))
                {
                    e.Graphics.DrawRectangle(glowPen, 0, 0, btn.Width - 1, btn.Height - 1);
                }
            }
        }
    }
}
