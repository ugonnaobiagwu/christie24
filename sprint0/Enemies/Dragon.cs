﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.HUDs;
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
        private enum State { Dead, Default };
        private State DragonState = State.Default;
        private int changeDirectionTicks = 0;
        private int totalChangeDirectionTicks = 100;
        private int direction;

        public Dragon(int x, int y, int roomId, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            /* Can be adjusted */
            Health = 12;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            DragonFactory = spriteFactory;
            DragonSprite = DragonFactory.getAnimatedSprite("Default");
            Fireballs = new DragonBlaze[] { new DragonBlaze(projectileFactory, 0), new DragonBlaze(projectileFactory, 1), new DragonBlaze(projectileFactory, 2) };
            foreach(DragonBlaze fire in Fireballs)
            {
                Globals.GameObjectManager.addObject(fire);
            }
            SpriteSheetFrames = new int[] { 0, 1, 2, 3 };
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            Direction = 0;
            yPos--;
        }

        public void EnemyDown()
        {
            Direction = 2;
            yPos++;
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

        public String getState()
        {
            if(DragonState == State.Default)
            {
                return "Default";
            }
            return "Dead";
        }

        public void setState(String state)
        {
            switch (state)
            {
                case "Default":
                    DragonState = State.Default;
                    break;
                case "Dead":
                    DragonState = State.Dead;
                    Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_DIE);
                    break;
            }
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
            return DragonSprite.GetWidth();
        }

        public int height()
        {
            /* Temporary Value */
            return DragonSprite.GetHeight();
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
            if(DragonState != State.Dead)
            {
                DragonSprite.Draw(spriteBatch, xPos, yPos, 0.0f);
                //foreach (DragonBlaze fireball in Fireballs)
                //{
                //    if (fireball.ThisStateMachine().isItemInUse())
                //    {
                //        fireball.Draw(spriteBatch);
                //    }
                //}
            } else
            {
                foreach (DragonBlaze fireball in Fireballs)
                {
                    if (fireball.ThisStateMachine().isItemInUse())
                    {
                        fireball.thisStateMachine.CeaseUse();
                    }
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

            /*
             * Link's Level can only be increased, not decreased, 
             * so this should be fine. We won't do this at the constructor
             * level, since his health wont increase as Link plays the game.
             */
            if (Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.MEDIUM))
            {
                Health = 14;
            }
            if (Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH))
            {
                Health = 16;
            }


            if (changeDirectionTicks >= totalChangeDirectionTicks)
            {
                Random rnd = new Random();
                direction = rnd.Next(4);
                changeDirectionTicks = 0;
            }
            else
            {
                changeDirectionTicks++;
            }

            switch (direction)
            {
                case 0:
                    EnemyLeft();
                    break;
                case 1:
                    EnemyRight();
                    break;
                case 2:
                    EnemyUp();
                    break;
                case 3:
                    EnemyDown();
                    break;
            }

            DragonShoot();
        }

        /* ---Other Methods--- */
        public void TakeDamage()
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
                DragonState = State.Dead;
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
        public GameObjectType type { get { return GameObjectType.ENEMY; } }
    }
}
