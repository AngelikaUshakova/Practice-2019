using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
   public interface IPlayerController
    {
         void NewGame();
         bool Update(int msc);
         void KeyStroke(Keys key, bool gameOver);
         ref int GetScore();
    }
}
