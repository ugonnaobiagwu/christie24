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
    public class Oktorok : IOktorok, IGameObject
    {
        private Sprint0 Game;
        private SpriteFactory OktorokFactory;
        private SpriteBatch SpriteBatch;
        private ISprite OktoSprite;
        private int xPos;
        private int yPos;
        private int Height;
        private int Width;
        private int RoomId;
        private enum Direction { Up, Down, Left, Right };
        private Direction OktorokDirection;
        private int Health;
        private enum State { Attack, Walk };
        private State OktorokState;
        private int[] SpriteSheetFrames;

        public Oktorok(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            /* Subject to Change */
            Health = 3;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            OktorokFactory = spriteFactory;
            OktoSprite = OktorokFactory.getAnimatedSprite("Down");

            /* Temporary Values */
            Height = 1;
            Width = 1;

            SpriteSheetFrames = new int[] { 0, 15, 1, 16, 2, 17, 3, 18 };
        }

        /* ---Movement--- */
        public void OktorokUp()
        {
            OktorokDirection = Direction.Up;
            yPos++;
        }

        public void OktorokDown()
        {
            OktorokDirection = Direction.Down;
            yPos--;
        }

        public void OktorokLeft()
        {
            OktorokDirection = Direction.Left;
            xPos--;
        }

        public void OktorokRight()
        {
            OktorokDirection = Direction.Right;
            xPos++;
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

        public int getHealth()
        {
            return Health;
        }

        public String getState()
        {
            if(OktorokState == State.Attack)
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
            OktoSprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            OktoSprite.Update();
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
    }
}
