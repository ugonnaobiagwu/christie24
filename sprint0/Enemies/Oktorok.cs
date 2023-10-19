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
    public class Oktorok : IOktorok
    {
        private Sprint0 Game;
        private SpriteFactory OktorokFactory;
        private SpriteBatch SpriteBatch;
        private int xPos;
        private int yPos;
        private enum Direction { Up, Down, Left, Right };
        private Direction OktorokDirection;
        private int Health;
        private enum State { Attack, Walk };
        private State OktorokState;
        private int[] SpriteSheetFrames;

        public Oktorok(SpriteBatch spriteBatch, Sprint0 game)
        {
            Game = game;
            SpriteBatch = spriteBatch;
            /* Subject to Change */
            Health = 3;

            /* Should be reduced to 1 line */
            SpriteSheetFrames = new int[8];
            SpriteSheetFrames[0] = 0;
            SpriteSheetFrames[1] = 15;
            SpriteSheetFrames[2] = 1;
            SpriteSheetFrames[3] = 16;
            SpriteSheetFrames[4] = 2;
            SpriteSheetFrames[5] = 17;
            SpriteSheetFrames[6] = 3;
            SpriteSheetFrames[7] = 18;
        }

        /* ---Movement--- */
        public void OktorokUp()
        {
            OktorokDirection = Direction.Up;
            yPos++;
            OktorokFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void OktorokDown()
        {
            OktorokDirection = Direction.Down;
            yPos--;
            OktorokFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void OktorokLeft()
        {
            OktorokDirection = Direction.Left;
            xPos--;
            OktorokFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void OktorokRight()
        {
            OktorokDirection = Direction.Right;
            xPos++;
            OktorokFactory.Draw(SpriteBatch, xPos, yPos);
        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            int direction = -1;
            switch (OktorokDirection)
            {
                case Direction.Left:
                    direction = 1;
                    break;
                case Direction.Right:
                    direction = 3;
                    break;
                case Direction.Up:
                    direction = 0;
                    break;
                case Direction.Down:
                    direction = 2;
                    break;
            }
            return direction;
        }

        public int getX()
        {
            return xPos;
        }

        public int getY()
        {
            return yPos;
        }

        public int getHealth()
        {
            return Health;
        }

        public int getState()
        {
            if(OktorokState == State.Attack)
            {
                return 1;
            }
            return 0;
        }

        /* ---Other Methods--- */
        public void TakeDamage()
        {
            /* Placeholder Knockback animation */
            for (int i = 0; i < 10; i++)
            {
                switch (getDirection())
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
                /* Code to delete the Oktorok */
            }
        }

        public void setState(String state)
        {
            switch(state)
            {
                case "Attack":
                    OktorokState = State.Attack;
                    break;
                case "Walk":
                    OktorokState= State.Walk;
                    break;
            }
        }

        public void OktorokShoot()
        {
            /* Code to make oktorok shoot */
        }

        public void Update()
        {
            OktorokFactory.Update();
        }
    }
}
