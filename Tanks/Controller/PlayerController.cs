using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class PlayerController : IPlayerController
    {
        private IGameModel model;

        public PlayerController(IGameModel model)
        {
            this.model = model;
        }

        public void Draw(Graphics graf)
        {
            throw new NotImplementedException();
        }

        public void KeyStroke(Keys key)
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            model.NewGame();
        }

        public void Update(int msc)
        {
            model.Update(msc);
        }
    }
}
