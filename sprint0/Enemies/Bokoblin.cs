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
using static sprint0.Globals;

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
        private Globals.Direction BokoblinDirection;
        private int Health;
        private enum State { Dead, Default };
        private State BokoState = State.Default;
        private int[] SpriteSheetFrames;
        private bool followLinkBehaviorOn;
        private BokoblinBoomerang Boomerang;
        private int changeDirectionTicks = 0;
        private int totalChangeDirectionTicks = 60;
        private Vector2 posVector;
        private Vector2 linkVector;
        private float followSpeed = .05f;
        private float followThreshold = 250.0f;
        private float dodgeThreshold = 50.0f;
        private int changeFollowingCourseTicks = 0;
        private int totalFollowingCourseTicks = 10;
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
            Boomerang.SetRoomId(roomId);
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
            BokoblinDirection = Globals.Direction.Up;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Up");
            yPos--;

        }

        public void EnemyDown()
        {
            BokoblinDirection = Globals.Direction.Down;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Down");
            yPos++;

        }

        public void EnemyLeft()
        {
            BokoblinDirection = Globals.Direction.Left;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Left");
            xPos--;

        }

        public void EnemyRight()
        {
            BokoblinDirection = Globals.Direction.Right;
            BokoSprite = BokoblinFactory.getAnimatedSprite("Right");
            xPos++;

        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            return (int)BokoblinDirection;
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
            
            /*
             * If Link is at max level, the enemies will chase him. Here's how it works for when I'm reading this again later:
             * 
             * Given two vectors, Link's vector and a vector for the Enemy's position..
             * If the distance between the two positions are smaller than the follow threshold 
             * (which will ensure enemies outside of Link's room won't try to follow him) as well as the followTicks limit is met
             * (which just controls how quickly the Sprite can "change course")
             * 
             * Grab the direction in which the Enemy mus travel towards Link, and increment his position to be a fraction of the total distance in the direction an enemy must travel to get to Link.
             * Change its Sprite depending on where it's going, and reset the "changeCourse" timer.
             * 
             * Set his new X and Y positions.
             */
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
                        BokoSprite = BokoblinFactory.getAnimatedSprite("Right");
                    }
                    else if (linkVector.X < posVector.X)
                    {
                        BokoSprite = BokoblinFactory.getAnimatedSprite("Left");
                    }
                    changeFollowingCourseTicks = 0;
                }
                changeFollowingCourseTicks++;

                this.xPos = (int)posVector.X;
                this.yPos = (int)posVector.Y;

                if (changeDirectionTicks >= totalChangeDirectionTicks)
                {
                    Random rnd = new Random();
                    BokoblinDirection = (Globals.Direction)rnd.Next(4);
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
                    BokoblinDirection = (Globals.Direction)rnd.Next(4);
                    changeDirectionTicks = 0;
                }
                else
                {
                    changeDirectionTicks++;
                }
                switch (BokoblinDirection)
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

            if (!Boomerang.ThisStateMachine().isItemInUse())
            {
                BokoblinThrow();
            }

            if (this.BokoState.Equals(State.Dead))
            {
                inPlay = false;
                Globals.GameObjectManager.removeObject(this);

            }

            /* Dodge Arrows */
            /* Checks A and B independently in case Link happens to have the Bow and BetterBow equipped at the same time */
            if (LinkHasBowA())
            {
                if (Globals.LinkItemSystem.currentItemA.isInPlay())
                {
                    if (Globals.Link.GetDirection() == Direction.Left || Globals.Link.GetDirection() == Direction.Right)
                    {
                        Random dodgeRng = new Random();
                        if (dodgeRng.Next(10) < 4)
                        {
                            Dodge(Globals.LinkItemSystem.currentItemA);
                        }
                    }
                }
            }
            if (LinkHasBowB())
            {
                if (Globals.LinkItemSystem.currentItemB.isInPlay())
                {
                    if (ItemInRange(Globals.LinkItemSystem.currentItemB))
                    {
                        Random dodgeRng = new Random();
                        if (dodgeRng.Next(10) < 4)
                        {
                            Dodge(Globals.LinkItemSystem.currentItemA);
                        }
                    }
                }
            }
        }

        //Helper Methods for dodge behavior
        private bool LinkHasBowA()
        {
            return Globals.LinkItemSystem.currentItemA != null &&
                (Globals.LinkItemSystem.currentItemA.GetType().ToString().Equals("Bow") || Globals.LinkItemSystem.currentItemA.GetType().ToString().Equals("BetterBow"));
        }

        private bool LinkHasBowB()
        {
            return Globals.LinkItemSystem.currentItemA != null &&
                (Globals.LinkItemSystem.currentItemB.GetType().ToString().Equals("Bow") || Globals.LinkItemSystem.currentItemB.GetType().ToString().Equals("BetterBow"));
        }

        private bool ItemInRange(IItem bow)
        {
            switch (Globals.Link.GetDirection())
            {
                case Direction.Left:
                    return Math.Abs(yPos - Globals.Link.yPosition()) <= height() &&
                        bow.xPosition() - xPos <= dodgeThreshold;
                case Direction.Right:
                    return Math.Abs(yPos - Globals.Link.yPosition()) <= height() &&
                        xPos - bow.xPosition() <= dodgeThreshold;
                case Direction.Up:
                    return Math.Abs(xPos - Globals.Link.xPosition()) <= width() &&
                        yPos - bow.yPosition() <= dodgeThreshold;
                case Direction.Down:
                    return Math.Abs(xPos - Globals.Link.xPosition()) <= height() &&
                        bow.yPosition() - yPos <= dodgeThreshold;
            }
            return false;
        }

        private void Dodge(IItem bow)
        {
            if (Globals.Link.GetDirection() == Direction.Left || Globals.Link.GetDirection() == Direction.Right)
            {
                if (yPos < Globals.Link.yPosition())
                {
                    while (ItemInRange(bow))
                    {
                        EnemyDown();
                    }
                }
                else
                {
                    while (ItemInRange(bow))
                    {
                        EnemyUp();
                    }
                }
            }
            else
            {
                if (xPos < Globals.Link.xPosition())
                {
                    while (ItemInRange(bow))
                    {
                        EnemyLeft();
                    }
                }
                else
                {
                    while (ItemInRange(bow))
                    {
                        EnemyRight();
                    }
                }
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
            yPos += change;
        }

        public void ChangeEnemyX(int change)
        {
            xPos += change;
        }
        public GameObjectType type { get { return GameObjectType.ENEMY; } }

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
                Console.WriteLine("Minimal Hit");
                Health = Health - 1;
                if (Health <= 0)
                {
                    BokoState = State.Dead;
                }
            }
        }
    }
}
