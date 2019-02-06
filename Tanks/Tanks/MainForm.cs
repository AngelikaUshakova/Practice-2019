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
        int mapWidth;
        int mapHeight;

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
        
            pictureBox1.Image = map;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            controller.Update(timer.Interval);
            Draw();
        }
    }

}
