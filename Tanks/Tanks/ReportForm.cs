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
    public partial class ReportForm : Form
    {
        ListEntities objects;
        GameModel model;
        public ReportForm(ListEntities objects)
        {
            InitializeComponent();
            this.objects = objects;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(21);
            dataGridView1.Rows[0].Cells[0].Value = objects.Player.posPlayer.posx.ToString()
                + ";" + objects.Player.posPlayer.posy.ToString();
            for (int i = 0; i < objects.Walls.Count; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = objects.Walls[i].posWall.posx.ToString() 
                    + ";" + objects.Walls[i].posWall.posy.ToString();
            }

            for (int i = 0; i < objects.Enemies.Count; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = objects.Enemies[i].posEnemy.posx.ToString() 
                    + ";" + objects.Enemies[i].posEnemy.posy.ToString();
            }

            for (int i = 0; i < objects.Apples.Count; i++)
            {
                dataGridView1.Rows[i].Cells[3].Value = objects.Apples[i].posApple.posx.ToString()
                    + ";" + objects.Apples[i].posApple.posy.ToString();
            }

            for (int i = 0; i < objects.Bullets.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = objects.Bullets[i].posBullet.posx.ToString()
                    + ";" + objects.Bullets[i].posBullet.posy.ToString();
            }
        }

        private void ReportForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

    }
}
