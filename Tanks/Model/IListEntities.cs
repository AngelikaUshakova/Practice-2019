using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ListEntities
    {
        Player Player { get; set; } 
        List<Enemies> Enemies { get; set; }
        List<Apple> Apples { get; set; }
        List<Wall> Walls { get; set; }
        List<Bullet> Bullets { get; set; }
        List<Explosion> Explosions { get; set; }
    }
}
