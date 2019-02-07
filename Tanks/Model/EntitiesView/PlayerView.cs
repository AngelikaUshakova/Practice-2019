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
        public Pos posPlayer = new Pos();
        public Size sizePlayer = new Size();

        public PlayerView(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {
            posPlayer.posx = x;
            posPlayer.posy = y;
            sizePlayer.width = width;
            sizePlayer.height = height;
            Pos pos = new Pos { posx = 0, posy = 0 };
            ChangeSprite(direction, speed, pos, sizePlayer);
        }

        public void ChangeSprite(Direction direction, int speed, Pos pos, Size size)
        {
            this.direction = direction;
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
            sprite.Draw(graf, posPlayer.posx, posPlayer.posy);
        }

        public void InitBullet(ListEntities objects)
        {
            int x = posPlayer.posx + sizePlayer.width / 2;
            int y = posPlayer.posy + sizePlayer.height / 2;

            objects.Bullets.Add(new BulletView(x, y, 5, 5, direction,true));
        }
    }
}
