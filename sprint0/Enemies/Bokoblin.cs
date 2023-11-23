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
using sprint0.HUDs;
using sprint0.Items;
using sprint0.Sound.Ocarina;

namespace sprint0.Enemies
{
    public class Bokoblin : IEnemy, IElementalEnemy
    {
        private Sprint0 Game;
        private SpriteFactory BokoblinFactory;
        private SpriteBatch SpriteBatch;
        private ISprite BokoSprite;
        private Globals.EnemyElementType element;
        private int xPos;
        private int yPos;
        private int Height;
        private int Width;
        private int RoomId;
        private enum Direction { Up, Down, Left, Right };
        private Direction BokoblinDirection;
        private int Health;
        private enum State { Dead, Default };
        private State BokoState = State.Default;
        private int[] SpriteSheetFrames;
        private bool followLinkBehaviorOn;
        private BokoblinBoomerang Boomerang;
        private int changeDirectionTicks = 0;
        private int totalChangeDirectionTicks = 60;
        private int direction;
        private Vector2 posVector;
        private Vector2 linkVector;
        private Vector2 oldLinkVector;
        private Vector2 linkVelocity;
        private float followSpeed = .05f;
        private float followThreshold = 500.0f;
        private int followticks = 0;
        private int totalfollowticks = 10;
        private bool inPlay;



        public Bokoblin(int x, int y, int roomId, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            /* Subject to Change */
            Health = 4;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            BokoblinFactory = spriteFactory;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");
            Boomerang = new BokoblinBoomerang(projectileFactory);
            element = Globals.EnemyElementType.NEUTRAL;

            Globals.GameObjectManager.addObject(Boomerang);

            /* Temporary Values */
            Width = BokoSprite.GetWidth();
            Height = BokoSprite.GetHeight();

            /* Should be reduced to 1 line */
            SpriteSheetFrames = new int[] { 64, 79, 65, 80, 66, 81, 67, 82 };
            followLinkBehaviorOn = false;
            inPlay = true;
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            BokoblinDirection = Direction.Up;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Up");
            yPos--;

        }

        public void EnemyDown()
        {
            BokoblinDirection = Direction.Down;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");
            yPos++;

        }

        public void EnemyLeft()
        {
            BokoblinDirection = Direction.Left;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Left");
            xPos--;

        }

        public void EnemyRight()
        {
            BokoblinDirection = Direction.Right;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Right");
            xPos++;

        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            int direction = -1;
            switch (BokoblinDirection)
            {
                case Direction.Left:
                    direction = 0;
                    break;
                case Direction.Right:
                    direction = 1;
                    break;
                case Direction.Up:
                    direction = 2;
                    break;
                case Direction.Down:
                    direction = 3;
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
            String state = "";
            switch (BokoState)
            {
                case State.Default:
                    state = "Default";
                    break;
                case State.Dead:
                    state = "Dead";
                    break;
            }
            return state;
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
            if (!this.BokoState.Equals(State.Dead))
            {
                BokoSprite.Draw(spriteBatch, xPos, yPos, 0.0f);
            }
            else
            {
                Boomerang.thisStateMachine.CeaseUse();
            }
        }

        //Code Smell: Long Method
        public void Update()
        {
            BokoSprite.Update();
            Boomerang.Update();

            if (Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH)
                /*|| Inventory.CurrentLinkLevel.Equals(Inventory.LinkLevel.HIGH) */)
            // it shouldn't change once its set so idk if the above line is neccesary
            {
                element = Globals.EnemyElementType.FIRE;
                followLinkBehaviorOn = true;
            }

            //Enemy Movement
            if (followLinkBehaviorOn)
            {
                oldLinkVector = new Vector2(linkVector.X, linkVector.Y);
                posVector = new Vector2(xPos, yPos);
                linkVector = new Vector2(Globals.Link.xPosition(), Globals.Link.yPosition());
                linkVelocity = linkVector - oldLinkVector;
                if (Vector2.Distance(posVector, linkVector) <= followThreshold && followticks >= totalfollowticks)
                {
                    Vector2 direction = Vector2.Normalize(linkVector - posVector);
                    posVector += direction * followSpeed * Vector2.Distance(posVector, linkVector);
                    if (linkVector.X > posVector.X)
                    {
                        BokoSprite = BokoblinFactory.getAnimatedSprite("Right");
                    }
                    else if (linkVector.X < posVector.X)
                    {
                        BokoSprite = BokoblinFactory.getAnimatedSprite("Left");
                    }
                    followticks = 0;
                }
                followticks++;

                this.xPos = (int)posVector.X;
                this.yPos = (int)posVector.Y;

                if (changeDirectionTicks >= totalChangeDirectionTicks)
                {
                    Random rnd = new Random();
                    BokoblinDirection = (Direction)rnd.Next(4);
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
            }

            if (!Boomerang.ThisStateMachine().isItemInUse())
            {
                BokoblinThrow();
            }

            if (this.BokoState.Equals(State.Dead))
            {
                inPlay = false;
                Globals.GameObjectManager.removeObject(this);

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

            Health = Health - 2;
            if (Health <= 0)
            {
                BokoState = State.Dead;
            }
        }

        public void setState(String state)
        {
            switch (state)
            {
                case "Default":
                    BokoState = State.Default;
                    break;
                case "Dead":
                    BokoState = State.Dead;
                    Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_DIE);
                    break;
            }
        }

        public void BokoblinThrow()
        {
            Boomerang.Use(this);

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
            if (element.Equals(Globals.EnemyElementType.FIRE))
            {
                Console.WriteLine("Critical Hit!");
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

                Health = Health - 3;
                if (Health <= 0)
                {
                    BokoState = State.Dead;
                }
            }
        }

        public void TakeMinimalDamage()
        {
            // likewise theres no such thing as min damage if you have not been leveled up yet.
            if (element.Equals(Globals.EnemyElementType.FIRE))
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

                Health = Health - 1;
                if (Health <= 0)
                {
                    BokoState = State.Dead;
                }
            }
        }
    }
}
