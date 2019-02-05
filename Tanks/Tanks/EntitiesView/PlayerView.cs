using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Tanks.EntitiesView
{
    public class PlayerView : Player
    {
        public PlayerView(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {

        }
    }
}
