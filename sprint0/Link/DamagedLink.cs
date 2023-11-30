using sprint0.AnimatedSpriteFactory;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.Globals;
using static sprint0.LinkObj.Link;

namespace sprint0.LinkObj
{
    internal class DamagedLink : ILink
    {
        SpriteFactory LinkFactory;
        ILink LinkObj;
        IGameObject LinkGameObj;
        float InitialTime;
        public DamagedLink(SpriteFactory linkFactory, ILink link)
        {
            LinkFactory = linkFactory;
            LinkObj = link;
            InitialTime = Globals.TotalSeconds;
        }
        public void LinkUp()
        {
            LinkObj.LinkUp();
        }

        public void LinkDown()
        {
            LinkObj.LinkDown();
        }

        public void LinkRight()
        {
            LinkObj.LinkRight();
        }

        public void LinkLeft()
        {
            LinkObj.LinkLeft();
        }
        public void LinkUseItem()
        {
            LinkObj.LinkUseItem();
        }
        public void LinkTakeDamage()
        {
            /*Can't Take Damage*/
        }
        //I'm fairly sure this is correct but if it's not, try this.SetLink(LinkObj)
        public void RemoveDecorator()
        {
            LinkObj.SetLink(LinkObj);
        }
        public String GetState()
        {
            return LinkObj.GetState();
        }
        public Direction GetDirection()
        {
            return LinkObj.GetDirection();
        }
        public int xPosition()
        {
            return LinkObj.xPosition();
        }
        public int yPosition()
        {
            return LinkObj.yPosition();
        }
        public int GetHealth()
        {
            return LinkObj.GetHealth();
        }
        public void SetState(Link.State newState)
        {
            LinkObj.SetState(newState);
        }
        public void SetLink(ILink link)
        {
            LinkObj.SetLink(link);
        }
        public void SetSprite(ISprite newSprite)
        {
            LinkObj.SetSprite(newSprite);
        }
        public int height()
        {
            return LinkObj.height();
        }
        public int width()
        {
            return LinkObj.width();
        }
        public bool isDynamic()
        {
            return LinkObj.isDynamic();
        }
        public bool isUpdateable()
        {
            return LinkObj.isUpdateable();
        }
        public bool isDrawable()
        {
            return LinkObj.isDrawable();
        }
        public bool isInPlay()
        {
            return LinkObj.isInPlay();
        }
        public void SetRoomId(int roomId)
        {
            LinkObj.SetRoomId(roomId);
        }
        public int GetRoomId()
        {
            return LinkObj.GetRoomId();
        }
        /*TO BE DELETE: FOR TESTING*/
        public void Draw(SpriteBatch spriteBatch)
        {
            LinkObj.Draw(spriteBatch);
        }
        public void Update()
        {
            float TimeDisplacement = TotalSeconds - InitialTime;
            if (TimeDisplacement == 3)
            {
                LinkObj.SetState(State.Default);
                RemoveDecorator();

            }
            else if (TimeDisplacement % 2 == 0)
            {
                /*The case where Link isn't shown*/
                LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Damaged"));

            }
            else
            {
                /*The case where Link's model is shown*/
                if (LinkObj.GetState().Equals("UseItem"))
                {
                    switch (LinkObj.GetDirection())
                    {
                        case Direction.Up:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemUp"));
                            break;
                        case Direction.Down:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemDown"));
                            break;
                        case Direction.Left:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemLeft"));
                            break;
                        case Direction.Right:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("ItemRight"));
                            break;
                    }

                }
                else
                {

                    switch (LinkObj.GetDirection())
                    {
                        case Direction.Up:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Up"));
                            break;
                        case Direction.Down:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Down"));
                            break;
                        case Direction.Left:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Left"));
                            break;
                        case Direction.Right:
                            LinkObj.SetSprite(LinkFactory.getAnimatedSprite("Right"));
                            break;
                    }

                }

            }
            LinkObj.Update();
        }

        public GameObjectType type { get { return GameObjectType.LINK; } }
        public void ChangeXandYValue(int x, int y)
        {

        }
    }
}
