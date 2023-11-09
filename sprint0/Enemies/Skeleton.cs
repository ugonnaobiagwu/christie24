using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;

namespace sprint0.Enemies
{
    public class Skeleton: ISkeleton, IGameObject
    {
        Sprint0 Game;
        SpriteFactory SkeletonFactory;
        SpriteBatch SpriteBatch;
        ISprite SkellySprite;
        private int Health;
        private int xPos;
        private int yPos;
        private int Direction;
        private int[] SpriteSheetFrames;
        private int RoomId;

        public Skeleton(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            /* Can be adjusted */
            Health = 3;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            SkeletonFactory = spriteFactory;
            SkellySprite = SkeletonFactory.getAnimatedSprite("Default");

            SpriteSheetFrames = new int[] { 74, 89 };
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

        public int getHealth()
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
            SkellySprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            SkellySprite.Update();

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
                /* Code to delete the Skeleton */
            }
        }
    }
}
