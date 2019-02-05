using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Explosion : ImmovableObject
    {
        public Explosion(int x, int y, int width, int height) : base(x, y, width, height)
        {
        } 
    }
}
