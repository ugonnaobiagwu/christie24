using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.Items;

namespace sprint0.Enemies
{
    public class Bokoblin : IEnemy
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
        private BokoblinBoomerang Boomerang;

        public Bokoblin(int x, int y, int roomId, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            /* Subject to Change */
            Health = 3;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            BokoblinFactory = spriteFactory;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");
            Boomerang = new BokoblinBoomerang(projectileFactory);

            /* Temporary Values */
            Width = 1;
            Height = 1;

            /* Should be reduced to 1 line */
            SpriteSheetFrames = new int[] {64, 79, 65, 80, 66, 81, 67, 82};
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            BokoblinDirection = Direction.Up;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Up");
            yPos++;
            BokoSprite.Update();
        }

        public void EnemyDown()
        {
            BokoblinDirection = Direction.Down;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");
            yPos--;
            BokoSprite.Update();
        }

        public void EnemyLeft()
        {
            BokoblinDirection = Direction.Left;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Left");
            xPos--;
            BokoSprite.Update();
        }

        public void EnemyRight()
        {
            BokoblinDirection = Direction.Right;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Right");
            xPos++;
            BokoSprite.Update();
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

        public int GetHealth()
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
            if (Boomerang.ThisStateMachine().isItemInUse())
            {
                Boomerang.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            BokoSprite.Update();
            Boomerang.Update();

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

            if (!Boomerang.ThisStateMachine().isItemInUse())
            {
                BokoblinThrow();
            }
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
            Boomerang.Use(this);
        }
    }
}
