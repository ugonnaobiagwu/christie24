using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.HUDs;
using sprint0.Items;
using sprint0.Sound.Ocarina;

namespace sprint0.Enemies
{
    public class Oktorok : IEnemy, IElementalEnemy
    {
        private Sprint0 Game;
        private SpriteFactory OktorokFactory;
        private SpriteBatch SpriteBatch;
        private ISprite OktoSprite;
        private Globals.EnemyElementType element;
        private int xPos;
        private int yPos;
        private int Height;
        private int Width;
        private int RoomId;
        private Globals.Direction OktorokDirection;
        private int Health;
        private enum State { Dead, Default };
        private State OktoState = State.Default;
        private int[] SpriteSheetFrames;
        private OktorokBlaze Projectile;
        private int changeDirectionTicks = 0;
        private int totalChangeDirectionTicks = 60;
        private Vector2 posVector;
        private Vector2 linkVector;
        private float followSpeed = .05f;
        private float followThreshold = 250.0f;
        private int changeFollowingCourseTicks = 0;
        private int totalFollowingCourseTicks = 10;
        private bool inPlay;
        private bool followLinkBehaviorOn;


        public Oktorok(int x, int y, int roomId, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            /* Subject to Change */
            Health = 4;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            OktorokFactory = spriteFactory;
            OktoSprite = OktorokFactory.getAnimatedSprite("Down");
            Projectile = new OktorokBlaze(projectileFactory);
            element = Globals.EnemyElementType.NEUTRAL;
            Globals.GameObjectManager.addObject(Projectile);
            OktorokDirection = Globals.Direction.Down;

            /* Temporary Values */
            Height = OktoSprite.GetHeight();
            Width = OktoSprite.GetWidth();

            SpriteSheetFrames = new int[] { 0, 15, 1, 16, 2, 17, 3, 18 };
            followLinkBehaviorOn = false;
            inPlay = true;
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            OktorokDirection = Globals.Direction.Up;
            OktoSprite = OktorokFactory.getAnimatedSprite("Up");
            yPos--;

        }

        public void EnemyDown()
        {
            OktorokDirection = Globals.Direction.Down;
            OktoSprite = OktorokFactory.getAnimatedSprite("Down");
            yPos++;
        }

        public void EnemyLeft()
        {
            OktorokDirection = Globals.Direction.Left;
            OktoSprite = OktorokFactory.getAnimatedSprite("Left");
            xPos--;
        }

        public void EnemyRight()
        {
            OktorokDirection = Globals.Direction.Right;
            OktoSprite = OktorokFactory.getAnimatedSprite("Right");
            xPos++;
        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            return (int)OktorokDirection;
        }

        public int GetHealth()
        {
            return Health;
        }

        public String getState()
        {
            if(OktoState == State.Dead)
            {
                return "Dead";
            }
            return "Default";
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
            return inPlay;
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
            if(OktoState != State.Dead)
            {
                OktoSprite.Draw(spriteBatch, xPos, yPos, 0.0f);
                
            }
            else
            {
                Projectile.thisStateMachine.CeaseUse();
            }
        }

        public void Update()
        {
            OktoSprite.Update();
            Projectile.Update();

            if (Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.MEDIUM)
                /*|| Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH) */)
            // it shouldn't change once its set so idk if the above line is neccesary
            {
                element = Globals.EnemyElementType.ICE;
            }

            if (Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH)
                /*|| Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH) */)
            // it shouldn't change once its set so idk if the above line is neccesary
            {
                followLinkBehaviorOn = true;
            }

            if (followLinkBehaviorOn)
            {
                posVector = new Vector2(xPos, yPos);
                linkVector = new Vector2(Globals.Link.xPosition(), Globals.Link.yPosition());
                if (Vector2.Distance(posVector, linkVector) <= followThreshold && changeFollowingCourseTicks >= totalFollowingCourseTicks)
                {
                    Vector2 direction = Vector2.Normalize(linkVector - posVector);
                    posVector += direction * followSpeed * Vector2.Distance(posVector, linkVector);
                    if (linkVector.X > posVector.X)
                    {
                        OktoSprite = OktorokFactory.getAnimatedSprite("Right");
                    }
                    else if (linkVector.X < posVector.X)
                    {
                        OktoSprite = OktorokFactory.getAnimatedSprite("Left");
                    }
                    changeFollowingCourseTicks = 0;
                }
                changeFollowingCourseTicks++;

                this.xPos = (int)posVector.X;
                this.yPos = (int)posVector.Y;

                if (changeDirectionTicks >= totalChangeDirectionTicks)
                {
                    Random rnd = new Random();
                    OktorokDirection = (Globals.Direction)rnd.Next(4);
                    changeDirectionTicks = 0;
                }
                else
                {
                    changeDirectionTicks++;
                }

            }
            else
            {

                if (changeDirectionTicks >= totalChangeDirectionTicks)
                {
                    Random rnd = new Random();
                    OktorokDirection = (Globals.Direction)rnd.Next(4);
                    changeDirectionTicks = 0;
                }
                else
                {
                    changeDirectionTicks++;
                }

                switch (OktorokDirection)
                {
                    case Globals.Direction.Left:
                        EnemyLeft();
                        break;
                    case Globals.Direction.Right:
                        EnemyRight();
                        break;
                    case Globals.Direction.Up:
                        EnemyUp();
                        break;
                    case Globals.Direction.Down:
                        EnemyDown();
                        break;
                }
            }

            if (!Projectile.ThisStateMachine().isItemInUse())
            {
                OktorokShoot();
            }
            if (this.OktoState.Equals(State.Dead))
            {
                inPlay = false;
                Globals.GameObjectManager.removeObject(this);

            }
        }

        /* ---Other Methods--- */
        public void TakeDamage()
        {
            Health = Health - 2;
            if (Health <= 0)
            {
                OktoState = State.Dead;
            }
        }

        public void setState(String state)
        {
            switch(state)
            {
                case "Dead":
                    OktoState = State.Dead;
                    Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_DIE);
                    break;
                case "Default":
                    OktoState = State.Default;
                    break;
            }
        }

        public void OktorokShoot()
        {
            Projectile.Use(this);
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

        public Globals.EnemyElementType EnemyElement()
        {
            return element;
        }

        public void TakeCriticalDamage()
        {
            // theres no such thing as crit damage if you have not been leveled up yet.
            if (element.Equals(Globals.EnemyElementType.ICE))
            {
                Console.WriteLine("Critical Hit!");
                Health = Health - 3;
                if (Health <= 0)
                {
                    OktoState = State.Dead;
                }
            }
        }

        public void TakeMinimalDamage()
        {
            // likewise theres no such thing as min damage if you have not been leveled up yet.
            if (element.Equals(Globals.EnemyElementType.ICE))
            {
                Console.WriteLine("Minimal Hit");
                Health = Health - 1;
                if (Health <= 0)
                {
                    OktoState = State.Dead;
                }
            }
        }
    }
}
