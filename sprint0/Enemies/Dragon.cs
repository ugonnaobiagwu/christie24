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

namespace sprint0.Enemies
{
    public class Dragon : IDragon, IGameObject
    {
        Sprint0 Game;
        SpriteFactory DragonFactory;
        SpriteBatch SpriteBatch;
        ISprite SkellySprite;
        private int Health;
        private int xPos;
        private int yPos;
        private int Direction;
        private int[] SpriteSheetFrames;
        private int RoomId;
        private DragonBlaze[] Fireballs;

        public Dragon(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            /* Can be adjusted */
            Health = 10;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            DragonFactory = spriteFactory;
            SkellySprite = DragonFactory.getAnimatedSprite("Default");
            Fireballs = new DragonBlaze[] { new DragonBlaze(spriteFactory, 0), new DragonBlaze(spriteFactory, 1), new DragonBlaze(spriteFactory, 2) };
            SpriteSheetFrames = new int[] { 0, 1, 2, 3 };
        }

        /* ---Movement--- */
        public void DragonUp()
        {
            Direction = 0;
            yPos++;
        }

        public void DragonDown()
        {
            Direction = 2;
            yPos--;
        }

        public void DragonLeft()
        {
            Direction = 1;
            xPos--;
        }

        public void DragonRight()
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
                    DragonUp();
                    break;
                case 1:
                    DragonLeft();
                    break;
                case 2:
                    DragonDown();
                    break;
                case 3:
                    DragonRight();
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
    }
}
