using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int mapWidth = 780;
            int mapHeight = 540;

            ListEntities objects = new ListEntities();
            IGameModel model = new GameModel(objects,mapWidth, mapHeight);
            IPlayerController controller = new PlayerController(model);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(controller,objects, mapWidth, mapHeight));
        }
    }
}
