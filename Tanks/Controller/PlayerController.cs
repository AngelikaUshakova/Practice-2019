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

        public ref int GetScore()
        {
            return ref model.GetScore();
        }

        public void KeyStroke(Keys key, bool gameOver)
        {
            if (gameOver)
            {
                if (key == Keys.Space)
                {
                    NewGame();
                }
            }
            else
            {
                switch (key)
                {
                    case Keys.A: model.ChangePlayerDirection(Direction.LEFT);
                        
                        break;
                    case Keys.D: model.ChangePlayerDirection(Direction.RIGHT);
                        break;
                    case Keys.S: model.ChangePlayerDirection(Direction.DOWN);
                        break;
                    case Keys.W: model.ChangePlayerDirection(Direction.UP);
                        break;
                    case Keys.Space: model.Shoot();
                        break;
                }
            }
        }

        public void NewGame()
        {
            model.NewGame(false);
        }

        public bool Update(int msc)
        {
           return model.Update(msc);
        }
    }
}
