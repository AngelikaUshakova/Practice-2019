using Model.EntitiesView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameModel : IGameModel
    {
        public ListEntities objects;
        Collisions collisions = new Collisions();
        Random random = new Random();
        int timer = 0;
        public int score;

        public bool gameOver = false;
        private int mapWidth;
        private int mapHeight;

        public GameModel(ListEntities objects, int mapWidth, int mapHeight)
        {
            this.objects = objects;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
        }

        public void ChangePlayerDirection(Direction direction)
        {
            Pos pos = new Pos() { posx = 0, posy = 0 };
            objects.Player.ChangeSprite(direction, objects.Player.speed, pos, objects.Player.sizePlayer);
        }

        public void ChangeEnemyDirection(Direction direction, EnemyView enemy)
        {
            Pos pos = new Pos() { posx = 0, posy = 0 };
            enemy.ChangeSprite(direction, enemy.speed, pos, enemy.sizeEnemy);
        }


        public void Draw(Graphics graf)
        {
            throw new NotImplementedException();
        }

        public void GameOver()
        {
            gameOver = true;
        }

        public void NewGame(bool gameOver)
        {
            objects.Apples = new List<AppleView>();
            objects.Enemies = new List<EnemyView>();
            objects.Bullets = new List<BulletView>();
            objects.Walls = new List<WallView>();

            Init init = new Init(objects, mapWidth, mapHeight);
            init.InitWalls();
            init.InitApple();
            init.InitPlayer();
            init.InitEnemies();
            score = 0;
            this.gameOver = gameOver;
        }

        public bool Update(int msc)
        {
            Init init = new Init(objects, mapWidth, mapHeight);

            timer += msc;

            objects.Player.Update(timer);
            // Create new apple
            if (objects.Apples.Count < 5 && random.Next(300) > 250)
            {
                init.InitApple();
            }
            // Create new enemy
            if (objects.Enemies.Count < 5 && random.Next(300) > 250)
            {
                init.InitEnemies();
            }
            // Random change enemy's direction 
            foreach (var enemy in objects.Enemies)
            {
                if (random.Next(300) > 295)
                {
                    ChangeEnemyDirection(new Init(objects, mapWidth, mapHeight).RandomDirection(), enemy);
                }
                enemy.Update(timer);
            }

            Move();

            // Check Collisions
            if (collisions.CheckCollisions(objects, mapWidth, mapHeight, ref score))
            {
                GameOver();
                return gameOver;
            }

            return gameOver;
        }

        public void Move()
        {
            switch (objects.Player.direction)
            {
                case Direction.LEFT:
                    objects.Player.posPlayer.posx -= 2;
                    break;

                case Direction.RIGHT:
                    objects.Player.posPlayer.posx += 2;
                    break;

                case Direction.UP:
                    objects.Player.posPlayer.posy -= 2;
                    break;

                case Direction.DOWN:
                    objects.Player.posPlayer.posy += 2;
                    break;
            }

            foreach (var enemy in objects.Enemies)
            {
                switch (enemy.direction)
                {
                    case Direction.LEFT:
                        enemy.posEnemy.posx -= 2;
                        break;

                    case Direction.RIGHT:
                        enemy.posEnemy.posx += 2;
                        break;

                    case Direction.UP:
                        enemy.posEnemy.posy -= 2;
                        break;

                    case Direction.DOWN:
                        enemy.posEnemy.posy += 2;
                        break;
                }
            }

            foreach (var bullet in objects.Bullets)
            {
                switch (bullet.direction)
                {
                    case Direction.LEFT:
                        bullet.posBullet.posx -= 4;
                        break;

                    case Direction.RIGHT:
                        bullet.posBullet.posx += 4;
                        break;

                    case Direction.UP:
                        bullet.posBullet.posy -= 4;
                        break;

                    case Direction.DOWN:
                        bullet.posBullet.posy += 4;
                        break;
                }
            }
        }

        public ref int GetScore()
        {
            return ref score;
        }

        public void Shoot()
        {
            objects.Player.InitBullet(objects);
        }
    }
}
