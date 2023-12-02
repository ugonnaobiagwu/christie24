using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.AnimatedSpriteFactory;
using sprint0.HUDs;
using sprint0.Sound.Ocarina;
using static sprint0.Globals;

namespace sprint0.Enemies
{
    public class Skeleton: IEnemy
    {
        Sprint0 Game;
        SpriteFactory SkeletonFactory;
        SpriteBatch SpriteBatch;
        ISprite SkellySprite;
        public enum State { Default, Dead };
        State SkellyState = State.Default;
        private int Health;
        private int xPos;
        private int yPos;
        private int[] SpriteSheetFrames;
        private int RoomId;
        private int changeDirectionTicks = 0;
        private int totalChangeDirectionTicks = 30;
        private Globals.Direction SkeletonDirection;
        private bool followLinkBehaviorOn;
        private Vector2 posVector;
        private Vector2 linkVector;
        private float followSpeed = .05f;
        private float followThreshold = 250.0f;
        private float dodgeThreshold = 50.0f;
        private int changeFollowingCourseTicks = 0;
        private int totalFollowingCourseTicks = 10;
        private bool inPlay;

        public Skeleton(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            /* Can be adjusted */
            Health = 4;

            xPos = x;
            yPos = y;
            RoomId = roomId;
            SkeletonFactory = spriteFactory;
            SkellySprite = SkeletonFactory.getAnimatedSprite("Default");

            SpriteSheetFrames = new int[] { 74, 89 };
            followLinkBehaviorOn = false;
            inPlay = true;
        }

        /* ---Movement--- */
        public void EnemyUp()
        {
            SkeletonDirection = Direction.Up;
            yPos--;
        }
        
        public void EnemyDown()
        {
            SkeletonDirection = Direction.Right;
            yPos++;
        }

        public void EnemyLeft()
        {
            SkeletonDirection = Direction.Left;
            xPos--;
        }

        public void EnemyRight()
        {
            SkeletonDirection = Direction.Right;
            xPos++;
        }

        /* ---Get Methods--- */
        public int getDirection()
        {
            return (int)SkeletonDirection;
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
            String state = "";
            switch (SkellyState)
            {
                case State.Default:
                    state = "Default";
                    break;
                case State.Dead:
                    state = "Dead";
                    Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_DIE);
                    break;
            }

            return state;
        }
        public void setState(String state)
        {
            switch (state)
            {
                case "Default":
                    SkellyState = State.Default;
                    break;
                case "Dead":
                    SkellyState = State.Dead;
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
            return SkellySprite.GetWidth();
        }

        public int height()
        {
            /* Temporary Value */
            return SkellySprite.GetHeight();
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
            if(SkellyState != State.Dead)
            {
                SkellySprite.Draw(spriteBatch, xPos, yPos, 0.0f);
            }
        }

        public void Update()
        {
            SkellySprite.Update();
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
                    changeFollowingCourseTicks = 0;
                }
                changeFollowingCourseTicks++;

                this.xPos = (int)posVector.X;
                this.yPos = (int)posVector.Y;

                if (changeDirectionTicks >= totalChangeDirectionTicks)
                {
                    Random rnd = new Random();
                    SkeletonDirection = (Direction)rnd.Next(4);
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
                    SkeletonDirection = (Direction)rnd.Next(4);
                    changeDirectionTicks = 0;
                }
                else
                {
                    changeDirectionTicks++;
                }

                switch (SkeletonDirection)
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
            if (this.SkellyState.Equals(State.Dead))
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
                        if(dodgeRng.Next(10) < 4)
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
            Health--;
            if (Health <= 0)
            {
                SkellyState = State.Dead;
            }
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
    }
}
