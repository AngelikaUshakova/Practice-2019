using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntitiesView
{
    public class EnemyView : Enemies
    {
        public Sprite sprite;
        public Pos posEnemy = new Pos();
        public Size sizeEnemy = new Size();

        public EnemyView(int x, int y, int width, int height, Direction direction, int speed) : base(x, y, width, height, direction, speed)
        {
            posEnemy.posx = x;
            posEnemy.posy = y;
            sizeEnemy.width = width;
            sizeEnemy.height = height;
            Pos pos = new Pos { posx = 0, posy = 0 };

            ChangeSprite(direction, speed, pos, sizeEnemy);
        }

        internal void ChangeSprite(Direction direction, int speed, Pos pos, Size size)
        {
            this.direction = direction;
            switch (direction)
            {
                case Direction.LEFT:
                    sprite = new Sprite("EnemyL.png", pos, size, 2, speed);
                    break;
                case Direction.RIGHT:
                    sprite = new Sprite("EnemyR.png", pos, size, 2, speed);
                    break;
                case Direction.UP:
                    sprite = new Sprite("EnemyU.png", pos, size, 2, speed);
                    break;
                case Direction.DOWN:
                    sprite = new Sprite("EnemyD.png", pos, size, 2, speed);
                    break;
            }
        }

        public void ReverseDirecion(Direction direction,int speed, Pos pos, Size size)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    this.direction = Direction.RIGHT;
                    sprite = new Sprite("EnemyR.png", pos, size, 2, speed);
                    break;
                case Direction.RIGHT:
                    this.direction = Direction.LEFT;
                    sprite = new Sprite("EnemyL.png", pos, size, 2, speed);
                    break;
                case Direction.UP:
                    this.direction = Direction.DOWN;
                    sprite = new Sprite("EnemyD.png", pos, size, 2, speed);
                    break;
                case Direction.DOWN:
                    this.direction = Direction.UP;
                    sprite = new Sprite("EnemyU.png", pos, size, 2, speed);
                    break;
            }
        }
        public void Update(float msc)
        {
            sprite.Update(msc);
        }

        public void Draw(Graphics graf)
        {
            sprite.Draw(graf, posEnemy.posx, posEnemy.posy);
        }

        public void InitBullet(ListEntities objects)
        {
            int x = posEnemy.posx + sizeEnemy.width / 2;
            int y = posEnemy.posy + sizeEnemy.height / 2;

            objects.Bullets.Add(new BulletView(x, y, 5, 5, direction,false));
        }
    }
}
