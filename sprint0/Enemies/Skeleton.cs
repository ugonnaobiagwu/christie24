using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.Factory;

namespace sprint0.Enemies
{
    public class Skeleton: ISkeleton, IGameObject
    {
        Sprint0 Game;
        SpriteFactory SkeletonFactory;
        SpriteBatch SpriteBatch;
        private int Health;
        private int xPos;
        private int yPos;
        private int Direction;
        private int[] SpriteSheetFrames;

        public Skeleton(Sprint0 game, SpriteBatch spriteBatch)
        {
            /* Can be adjusted */
            Health = 3;
            SpriteBatch = spriteBatch;
            Game = game;

            /* Should be reformatted to 1 line */
            SpriteSheetFrames = new int[2];
            SpriteSheetFrames[0] = 74;
            SpriteSheetFrames[1] = 89;
        }

        /* ---Movement--- */
        public void SkeletonUp()
        {
            Direction = 0;
            yPos++;
            SkeletonFactory.Draw(SpriteBatch, xPos, yPos);
        }
        x
        public void SkeletonDown()
        {
            Direction = 2;
            yPos--;
            SkeletonFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void SkeletonLeft()
        {
            Direction = 1;
            xPos--;
            SkeletonFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void SkeletonRight()
        {
            Direction = 3;
            xPos++;
            SkeletonFactory.Draw(SpriteBatch, xPos, yPos);
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

        public void Update()
        {
            SkeletonFactory.Update();
        }
    }
}
