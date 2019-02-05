using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Tanks.EntitiesView
{
    public class WallView : Wall
    {
        public WallView(int x, int y, int width, int height, bool destructible = false, bool isWater = false) : base(x, y, width, height, destructible, isWater)
        {

        }
    }
}
