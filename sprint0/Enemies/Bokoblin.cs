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
    public class Bokoblin : IBokoblin, IGameObject
    {
        private Sprint0 Game;
        private SpriteFactory BokoblinFactory;
        private SpriteBatch SpriteBatch;
        private int xPos;
        private int yPos;
        private enum Direction { Up, Down, Left, Right };
        private Direction BokoblinDirection;
        private int Health;
        private enum State { Attack, Walk };
        private State BokoblinState;
        private int[] SpriteSheetFrames;

        public Bokoblin(SpriteBatch spriteBatch, Sprint0 game)
        {
            Game = game;
            SpriteBatch = spriteBatch;
            /* Subject to Change */
            Health = 3;

            /* Should be reduced to 1 line */
            SpriteSheetFrames = new int[8];
            SpriteSheetFrames[0] = 64;
            SpriteSheetFrames[1] = 79;
            SpriteSheetFrames[2] = 65;
            SpriteSheetFrames[3] = 80;
            SpriteSheetFrames[4] = 66;
            SpriteSheetFrames[5] = 81;
            SpriteSheetFrames[6] = 67;
            SpriteSheetFrames[7] = 82;
        }

        /* ---Movement--- */
        public void BokoblinUp()
        {
            BokoblinDirection = Direction.Up;
            yPos++;
            BokoblinFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void BokoblinDown()
        {
            BokoblinDirection = Direction.Down;
            yPos--;
            BokoblinFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void BokoblinLeft()
        {
            BokoblinDirection = Direction.Left;
            xPos--;
            BokoblinFactory.Draw(SpriteBatch, xPos, yPos);
        }

        public void BokoblinRight()
        {
            BokoblinDirection = Direction.Right;
            xPos++;
            BokoblinFactory.Draw(SpriteBatch, xPos, yPos);
        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            int direction = -1;
            switch (BokoblinDirection)
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

        public int getHealth()
        {
            return Health;
        }

        public int getState()
        {
            if (BokoblinState == State.Attack)
            {
                return 1;
            }
            return 0;
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
                /* Code to delete the Bokoblin */
            }
        }

        public void setState(String state)
        {
            switch (state)
            {
                case "Attack":
                    BokoblinState = State.Attack;
                    break;
                case "Walk":
                    BokoblinState = State.Walk;
                    break;
            }
        }

        public void BokoblinThrow()
        {
            /* Code to make Bokoblin throw boomerang */
        }

        public void Update()
        {
            BokoblinFactory.Update();
        }
    }
}
