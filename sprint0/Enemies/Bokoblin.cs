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
    public class Bokoblin : IBokoblin, IGameObject
    {
        private Sprint0 Game;
        private SpriteFactory BokoblinFactory;
        private SpriteBatch SpriteBatch;
        private ISprite BokoSprite;
        private int xPos;
        private int yPos;
        private int Height;
        private int Width;
        private int RoomId;
        private enum Direction { Up, Down, Left, Right };
        private Direction BokoblinDirection;
        private int Health;
        private enum State { Attack, Walk };
        private State BokoblinState;
        private int[] SpriteSheetFrames;

        public Bokoblin(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            /* Subject to Change */
            Health = 3;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            BokoblinFactory = spriteFactory;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");

            /* Temporary Values */
            Width = 1;
            Height = 1;

            /* Should be reduced to 1 line */
            SpriteSheetFrames = new int[] {64, 79, 65, 80, 66, 81, 67, 82};
        }

        /* ---Movement--- */
        public void BokoblinUp()
        {
            BokoblinDirection = Direction.Up;
            yPos++;
        }

        public void BokoblinDown()
        {
            BokoblinDirection = Direction.Down;
            yPos--;
        }

        public void BokoblinLeft()
        {
            BokoblinDirection = Direction.Left;
            xPos--;
        }

        public void BokoblinRight()
        {
            BokoblinDirection = Direction.Right;
            xPos++;
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

        public String getState()
        {
            if (BokoblinState == State.Attack)
            {
                return "Attack";
            }
            return "Walk";
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
            return Width;
        }

        public int height()
        {
            return Height;
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
            BokoSprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            BokoSprite.Update();
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
    }
}
