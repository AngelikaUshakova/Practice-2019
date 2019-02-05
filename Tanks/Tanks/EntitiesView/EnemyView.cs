using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Tanks.EntitiesView
{
    public class EnemyView : Enemies
    {
        public EnemyView(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {

        }
    }
}
