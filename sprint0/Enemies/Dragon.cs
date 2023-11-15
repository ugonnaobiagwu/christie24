using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;
using sprint0.Sound.Ocarina;

namespace sprint0.Enemies
{
    public class Dragon : IEnemy
    {
        Sprint0 Game;
        SpriteFactory DragonFactory;
        SpriteBatch SpriteBatch;
        ISprite DragonSprite;
        private int Health;
        private int xPos;
        private int yPos;
        private int Direction;
        private int[] SpriteSheetFrames;
        private int RoomId;
        private DragonBlaze[] Fireballs;

        public Dragon(int x, int y, int roomId, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            /* Can be adjusted */
            Health = 10;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            DragonFactory = spriteFactory;
            DragonSprite = DragonFactory.getAnimatedSprite("Default");
            Fireballs = new DragonBlaze[] { new DragonBlaze(projectileFactory, 0), new DragonBlaze(projectileFactory, 1), new DragonBlaze(projectileFactory, 2) };
            SpriteSheetFrames = new int[] { 0, 1, 2, 3 };
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            Direction = 0;
            yPos++;
        }

        public void EnemyDown()
        {
            Direction = 2;
            yPos--;
        }

        public void EnemyLeft()
        {
            Direction = 1;
            xPos--;
        }

        public void EnemyRight()
        {
            Direction = 3;
            xPos++;
        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            return Direction;
        }

        public int getX()
        {
            return xPos;
        }

        public int GetHealth()
        {
            return Health;
        }

        /* ---IGameObject--- */
        public int xPosition()
        {
            return xPos;
        }

        public int yPosition()
        {
            return yPos;
        }

        public int width()
        {
            /* Temporary Value */
            return 1;
        }

        public int height()
        {
            /* Temporary Value */
            return 1;
        }

        public bool isDynamic()
        {
            return true;
        }

        public bool isUpdateable()
        {
            return true;
        }

        public bool isInPlay()
        {
            return true;
        }

        public bool isDrawable()
        {
            return true;
        }

        public void SetRoomId(int roomId)
        {
            RoomId = roomId;
        }

        public int GetRoomId()
        {
            return RoomId;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DragonSprite.Draw(spriteBatch, xPos, yPos);
            foreach (DragonBlaze fireball in Fireballs)
            {
                if(fireball.ThisStateMachine().isItemInUse())
                {
                    fireball.Draw(spriteBatch);
                }
            }
        }

        public void Update()
        {
            DragonSprite.Update();
            foreach(DragonBlaze fireball in Fireballs)
            {
                fireball.Update();
            }

            Random rnd = new Random();
            int direction = rnd.Next(4);

            switch (direction)
            {
                case 0:
                    EnemyUp();
                    break;
                case 1:
                    EnemyLeft();
                    break;
                case 2:
                    EnemyDown();
                    break;
                case 3:
                    EnemyRight();
                    break;
            }

            DragonShoot();
        }

        /* ---Other Methods--- */
        public void takeDamage()
        {
            /* Placeholder Knockback animation */
            for (int i = 0; i < 10; i++)
            {
                switch (Direction)
                {
                    case 0:
                        yPos--;
                        break;
                    case 1:
                        xPos++;
                        break;
                    case 2:
                        yPos++;
                        break;
                    case 3:
                        xPos--;
                        break;
                }
            }

            Health--;
            if (Health <= 0)
            {
                /* Code to delete the Dragon */
            }

        }

        public void DragonShoot()
        {
            foreach(DragonBlaze fireball in Fireballs)
            {
                fireball.Use(this);
                
            }
        }

        public void ChangeEnemyY(int change)
        {
            xPos += change;
        }

        public void ChangeEnemyX(int change)
        {
            yPos += change;
        }
        public String type() { return "Enemy"; }
    }
}
