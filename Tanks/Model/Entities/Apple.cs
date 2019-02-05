using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Apple : ImmovableObject
    {
        public Apple(int x, int y, int width, int height) : base(x, y, width, height)
        {
        
        }
    }
}
