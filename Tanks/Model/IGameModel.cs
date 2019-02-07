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
        void NewGame(bool gameOver);
        bool Update(int msc);
        void ChangePlayerDirection(Direction direction);
        void GameOver();
        void Move();
        ref int GetScore();
        void Shoot();
    }
}
