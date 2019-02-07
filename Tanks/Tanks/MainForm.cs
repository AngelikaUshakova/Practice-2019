using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class MainForm : Form
    {
        IPlayerController controller;
        ListEntities objects;
        Form reportform ;
        int mapWidth;
        int mapHeight;
        bool gameOver = false;
        private int score = 0;

        public MainForm(IPlayerController controller, ListEntities objects, int mapWidth, int mapHeight)
        {
            InitializeComponent();
            this.controller = controller;
            this.objects = objects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            controller.NewGame();
            timer.Enabled = true;
            Draw();
        }

        void Draw()
        {
            Bitmap map = new Bitmap(mapWidth, mapHeight);
            Graphics graf = Graphics.FromImage(map);

            if (gameOver)
            {
                graf.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, mapWidth, mapHeight));

                graf.DrawString("Game Over", new Font(FontFamily.GenericSerif, 30, FontStyle.Italic),
                    new SolidBrush(Color.White), new Point(290, 200));
                graf.DrawString("Try again", new Font(FontFamily.GenericSerif, 20, FontStyle.Italic),
                    new SolidBrush(Color.White), new Point(325, 250));
                graf.DrawString("(Press space)", new Font(FontFamily.GenericSerif, 15, FontStyle.Italic),
                    new SolidBrush(Color.White), new Point(325, 280));
            }
            else
            {
                graf.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, mapWidth, mapHeight));

                objects.Player.Draw(graf);

                foreach (var wall in objects.Walls)
                {
                    wall.Draw(graf);
                }
                foreach (var apple in objects.Apples)
                {
                    apple.Draw(graf);
                }
                foreach (var enemy in objects.Enemies)
                {
                    enemy.Draw(graf);
                }

                foreach (var bullet in objects.Bullets)
                {
                    bullet.Draw(graf);
                }

                graf.DrawString(score.ToString(), new Font(FontFamily.GenericSerif, 20, FontStyle.Italic),
                    new SolidBrush(Color.White), new Point(740, 5));

                graf.DrawString("Press I to report", new Font(FontFamily.GenericSerif, 16, FontStyle.Italic),
                    new SolidBrush(Color.White), new Point(5, 520));

                if (gameOver)
                {
                    graf.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, mapWidth, mapHeight));

                    graf.DrawString("Game Over", new Font(FontFamily.GenericSerif, 30, FontStyle.Italic),
                        new SolidBrush(Color.White), new Point(290, 200));
                    graf.DrawString("Try again", new Font(FontFamily.GenericSerif, 20, FontStyle.Italic),
                        new SolidBrush(Color.White), new Point(325, 250));
                    graf.DrawString("(Press space)", new Font(FontFamily.GenericSerif, 15, FontStyle.Italic),
                        new SolidBrush(Color.White), new Point(325, 280));
                    score = 0;
                }
            }
            pictureBox1.Image = map;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameOver = controller.Update(timer.Interval);

            score = controller.GetScore();
            Draw();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I )
            {
                if(reportform == null || reportform.IsDisposed)
                {
                    reportform = new ReportForm(objects);
                    reportform.Show();
                }
                reportform.KeyDown += MainForm_KeyDown;
            }
            controller.KeyStroke(e.KeyCode, gameOver);
        }
    }
}
