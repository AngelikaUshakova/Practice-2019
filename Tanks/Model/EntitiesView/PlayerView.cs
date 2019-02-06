using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntitiesView
{
    public class PlayerView : Player
    {
        Sprite sprite;

        public PlayerView(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Pos pos = new Pos { posx = 0, posy = 0 };
            Size size = new Size { width = width, height = height };

            switch (direction)
            {
                case Direction.LEFT:
                    sprite = new Sprite("PlayerL.png", pos, size, 2, speed);
                    break;
                case Direction.RIGHT:
                    sprite = new Sprite("PlayerR.png", pos, size, 2, speed);
                    break;
                case Direction.UP:
                    sprite = new Sprite("PlayerU.png", pos, size, 2, speed);
                    break;
                case Direction.DOWN:
                    sprite = new Sprite("PlayerD.png", pos, size, 2, speed);
                    break;
            }
        }

        public void Update(float msc)
        {
            sprite.Update(msc);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, X, Y);
        }
    }
}
