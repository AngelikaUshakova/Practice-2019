using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wall : ImmovableObject
    {
        bool destructible;
        bool isWater;

        public Wall(int x, int y, int width, int height, bool destructible = false, bool isWater = false) : base(x, y, width, height)
        {
            this.destructible = destructible;
            this.isWater = isWater;
        }
    }
}
