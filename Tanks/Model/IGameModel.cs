using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public interface IGameModel
    {
        void NewGame();
        void Draw(Graphics graf);
        void Update(int msc);
        void ChangeDiriction(Direction direction);
    }
}
