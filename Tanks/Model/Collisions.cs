using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Collisions
    {
        private int mapWidth;
        private int mapHeight;
        Random random = new Random();

        public bool CheckCollisions(ListEntities objects, int mapWidth, int mapHeight, ref int score)
        {
            GameModel model = new GameModel(objects,mapWidth,mapHeight);

            bool gameOver = false;
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;

            CheckPlayerBounds(objects);

            // Player clashes with walls
            foreach (var wall in objects.Walls)
            {
                if (BoxCollides(wall.posWall, wall.sizeWall, objects.Player.posPlayer, objects.Player.sizePlayer))
                {
                    switch (objects.Player.direction)
                    {
                        case Direction.LEFT:
                            objects.Player.posPlayer.posx += 2;
                            break;
                        case Direction.RIGHT:
                            objects.Player.posPlayer.posx -= 2;
                            break;
                        case Direction.UP:
                            objects.Player.posPlayer.posy += 2;
                            break;
                        case Direction.DOWN:
                            objects.Player.posPlayer.posy -= 2;
                            break;
                    }
                }
            }

            // Player clashes with enemies
            foreach (var enemy in objects.Enemies)
            {
                if (BoxCollides(enemy.posEnemy, enemy.sizeEnemy, objects.Player.posPlayer, objects.Player.sizePlayer))
                {
                   return gameOver = true;
                }
            }

            for (int i = 0; i < objects.Enemies.Count; i++)
            {
                // Reverse direction, if enemy went abroad wall
                for (int k = 0; k < objects.Walls.Count; k++)
                {
                    if (BoxCollides(objects.Enemies[i].posEnemy, objects.Enemies[i].sizeEnemy,
                        objects.Walls[k].posWall, objects.Walls[k].sizeWall))
                    {
                        Move(objects, i);
                        objects.Enemies[i].ReverseDirecion(objects.Enemies[i].direction, objects.Enemies[i].speed,
                            objects.Enemies[i].sprite.pos, objects.Enemies[i].sizeEnemy);
                    }
                }

                // Reverse direction, if enemy went abroad map
                if (objects.Enemies[i].posEnemy.posx < 0 || 
                    objects.Enemies[i].posEnemy.posx > mapWidth - objects.Enemies[i].sizeEnemy.width ||
                     objects.Enemies[i].posEnemy.posy < 0 ||
                     objects.Enemies[i].posEnemy.posy > mapHeight - objects.Enemies[i].sizeEnemy.height)
                {
                    Move(objects, i);

                    objects.Enemies[i].ReverseDirecion(objects.Enemies[i].direction, objects.Enemies[i].speed,
                        objects.Enemies[i].sprite.pos, objects.Enemies[i].sizeEnemy);
                }
           
                // Reverse direction, if enemy went abroad other enemy
                for (int j = 0; j < i; j++)
                {
                   if(BoxCollides(objects.Enemies[i].posEnemy, objects.Enemies[i].sizeEnemy,
                       objects.Enemies[j].posEnemy, objects.Enemies[j].sizeEnemy))
                    {

                        Move(objects, i);
                        Move(objects, j);

                        objects.Enemies[i].ReverseDirecion(objects.Enemies[i].direction, objects.Enemies[i].speed,
                            objects.Enemies[i].sprite.pos, objects.Enemies[i].sizeEnemy);

                        objects.Enemies[j].ReverseDirecion(objects.Enemies[j].direction, objects.Enemies[j].speed,
                            objects.Enemies[j].sprite.pos, objects.Enemies[j].sizeEnemy);

                    }
                }
            }
            // Enemy is shooting
            foreach (var enemy in objects.Enemies)
            {
                switch (enemy.direction)
                {
                    case Direction.LEFT:
                        if (Collides(enemy.posEnemy.posx - 61, enemy.posEnemy.posy,
                             enemy.posEnemy.posx - 61 + enemy.sizeEnemy.width,
                             enemy.posEnemy.posy + enemy.sizeEnemy.height,
                             objects.Player.posPlayer.posx, objects.Player.posPlayer.posy,
                             objects.Player.posPlayer.posx + objects.Player.sizePlayer.width,
                             objects.Player.posPlayer.posy + objects.Player.sizePlayer.height))
                        {
                            if(random.Next(200) > 180)
                                enemy.InitBullet(objects);
                        }
                          
                        break;
                    case Direction.RIGHT:
                        if (Collides(enemy.posEnemy.posx + 61, enemy.posEnemy.posy,
                             enemy.posEnemy.posx + 61 + enemy.sizeEnemy.width,
                             enemy.posEnemy.posy + enemy.sizeEnemy.height,
                             objects.Player.posPlayer.posx, objects.Player.posPlayer.posy,
                             objects.Player.posPlayer.posx + objects.Player.sizePlayer.width,
                             objects.Player.posPlayer.posy + objects.Player.sizePlayer.height))
                        {
                            if (random.Next(200) > 180)
                                enemy.InitBullet(objects);
                        }
                        break;
                    case Direction.UP:
                        if (Collides(enemy.posEnemy.posx, enemy.posEnemy.posy - 61, enemy.posEnemy.posx + enemy.sizeEnemy.width,
                             enemy.posEnemy.posy - 61 + enemy.sizeEnemy.height,
                             objects.Player.posPlayer.posx, objects.Player.posPlayer.posy,
                             objects.Player.posPlayer.posx + objects.Player.sizePlayer.width,
                             objects.Player.posPlayer.posy + objects.Player.sizePlayer.height))
                        {
                            if (random.Next(200) > 180)
                                enemy.InitBullet(objects);
                        }
                        break;
                    case Direction.DOWN:
                        if (Collides(enemy.posEnemy.posx, enemy.posEnemy.posy + 61, enemy.posEnemy.posx + enemy.sizeEnemy.width,
                             enemy.posEnemy.posy + 61 + enemy.sizeEnemy.height,
                             objects.Player.posPlayer.posx, objects.Player.posPlayer.posy,
                             objects.Player.posPlayer.posx + objects.Player.sizePlayer.width,
                             objects.Player.posPlayer.posy + objects.Player.sizePlayer.height))
                        {
                            if (random.Next(200) > 180)
                                enemy.InitBullet(objects);
                        }
                        break;
                }
              
            }
            // Player picks apple
            foreach (var apple in objects.Apples)
            {
                if (BoxCollides(apple.posApple, apple.sizeApple, objects.Player.posPlayer, objects.Player.sizePlayer))
                {
                    objects.Apples.Remove(apple);
                    score++;
                    break;
                }
            }

            for (int i = 0; i < objects.Bullets.Count; i++)
            {
                bool check = false;
                if (objects.Bullets[i].senderPlayer)
                {
                    // Bullet hit enemy
                    for (int l = 0; l < objects.Enemies.Count; l++)
                    {
                        if (BoxCollides(objects.Bullets[i].posBullet, objects.Bullets[i].sizeBullet,
                            objects.Enemies[l].posEnemy, objects.Enemies[l].sizeEnemy))
                        {
                            objects.Bullets.Remove(objects.Bullets[i]);
                            objects.Enemies.Remove(objects.Enemies[l]);
                            check = true;
                            break;
                        }
                    }
                }
                else
                {
                    // Bullet hit player
                    if (BoxCollides(objects.Bullets[i].posBullet, objects.Bullets[i].sizeBullet,
                            objects.Player.posPlayer, objects.Player.sizePlayer))
                    {
                        return gameOver = true;
                    }
                }

                // Bullet hit wall
                if (objects.Bullets.Count > 0 && !check)
                {
                    for (int k = 0; k < objects.Walls.Count; k++)
                    {
                        if (BoxCollides(objects.Bullets[i].posBullet, objects.Bullets[i].sizeBullet,
                            objects.Walls[k].posWall, objects.Walls[k].sizeWall))
                        {
                            objects.Bullets.Remove(objects.Bullets[i]);
                            check = true;
                            break;
                        }
                    }
                }

                // Bullet went off map
                if (objects.Bullets.Count > 0 && !check)
                {
                    if (objects.Bullets[i].posBullet.posx < 0 ||
                   objects.Bullets[i].posBullet.posx > mapWidth - objects.Bullets[i].sizeBullet.width ||
                    objects.Bullets[i].posBullet.posy < 0 ||
                    objects.Bullets[i].posBullet.posy > mapHeight - objects.Bullets[i].sizeBullet.height)
                    {
                        objects.Bullets.Remove(objects.Bullets[i]);
                    }
                }
             }
                return gameOver;
        }

        private static void Move(ListEntities objects, int i)
        {
            switch (objects.Enemies[i].direction)
            {
                case Direction.LEFT:
                    objects.Enemies[i].posEnemy.posx += 2;
                    break;
                case Direction.RIGHT:
                    objects.Enemies[i].posEnemy.posx -= 2;
                    break;
                case Direction.UP:
                    objects.Enemies[i].posEnemy.posy += 2;
                    break;
                case Direction.DOWN:
                    objects.Enemies[i].posEnemy.posy -= 2;
                    break;
            }
        }

        private void CheckPlayerBounds(ListEntities objects)
        {
            if (objects.Player.posPlayer.posx < 0)
            {
                objects.Player.posPlayer.posx = 0;
            }
            else if (objects.Player.posPlayer.posx > mapWidth - objects.Player.sizePlayer.width)
            {
                objects.Player.posPlayer.posx = mapWidth - objects.Player.sizePlayer.width;
            }

            if (objects.Player.posPlayer.posy < 0)
            {
                objects.Player.posPlayer.posy = 0;
            }
            else if (objects.Player.posPlayer.posy > mapHeight - objects.Player.sizePlayer.height)
            {
                objects.Player.posPlayer.posy = mapHeight - objects.Player.sizePlayer.height;
            }
        }

        public bool BoxCollides(Pos pos1, Size size1, Pos pos2, Size size2)
        {
            return Collides(pos1.posx,pos1.posy,
                            pos1.posx + size1.width,pos1.posy + size1.height,
                            pos2.posx, pos2.posy,
                            pos2.posx + size2.width, pos2.posy + size2.height);
        }

        private bool Collides(double x1, double y1, double dx1, double dy1, double x2, double y2, double dx2, double dy2)
        {
            return !(dx1 <= x2 || x1 > dx2 ||
                     dy1 <= y2 || y1 > dy2);
        }
    }
}
