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
        int mapWidth = 780;
        int mapHeight = 540;

        public MainForm()
        {
            InitializeComponent();
        }

        void Render()
        {
            Bitmap map = new Bitmap(mapWidth, mapHeight);
            Graphics graf = Graphics.FromImage(map);

        }
      
    }

}
