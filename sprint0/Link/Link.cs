using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    using global::sprint0.AnimatedSpriteFactory;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;
    

    /* Need to make interface*/
    public class Link : ILink 
    {
            private bool IsUpdateable = true;
            private bool IsDrawable = true;
            private bool IsInPlay = true;
            private bool IsDynamic = true;
            SpriteFactory LinkSpriteFactory;
            private int HealthVal { get; set; }
            private int XVal { get; set; }
            private int YVal { get; set; }
            private int RoomId;
            private enum Direction { Left, Right, Up, Down};
            public enum State { UseItem, Default }
            Direction LinkDirection = Direction.Down;
            State LinkState = State.Default;
            ILink LinkObj;
            ISprite LinkSprite;
            /*Edited to have a texture, row, and column input for the purpose of drawing*/
            public Link(int x, int y, int roomId, SpriteFactory spriteFactory)
            {
                /*This number is arbitrary*/
                HealthVal = 10;
                LinkSpriteFactory = spriteFactory;
                XVal = x; YVal = y;
                LinkObj = this;
                RoomId = roomId;
                IsDynamic = true;
                LinkSprite = LinkSpriteFactory.getAnimatedSprite("Down");
            }

            /*This can be used for both attacking and use item because they have the same Link sprite but different items, which are handled by the item system*/
            public void LinkUseItem()
            {
                /*This may need altered to fit sprite animation length*/
                LinkObj.SetState("UseItem");
                switch (LinkDirection)
                {   
                    case Direction.Left:
                        LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemLeft");
                        break;
                    case Direction.Right:
                        LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemRight");
                        break; 
                    case Direction.Up:
                        LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemUp");
                        break;
                    default:
                        LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemDown");
                        break;
                }
               

            }


            /*The directions just change what position he is in, we have these defined already.*/
            public void LinkUp()
            {

                if (LinkDirection != Direction.Up && LinkState == State.Default)
                {
                    LinkDirection = Direction.Up;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Up");
                }
                YVal--;
                LinkSprite.Update();
                
            }

            public void LinkDown()
            {
                if (LinkDirection != Direction.Down && LinkState == State.Default)
                {
                    LinkDirection = Direction.Down;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Down");
                }
                YVal++;
                LinkSprite.Update();
        }

            public void LinkRight()
            {
                if (LinkDirection != Direction.Right && LinkState == State.Default)
                {
                    LinkDirection = Direction.Right;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Right");
                }
                XVal++;
                LinkSprite.Update();
        }

            public void LinkLeft()
            {
                if (LinkDirection != Direction.Left && LinkState == State.Default)
                {
                    LinkDirection = Direction.Left;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Left");
                }
                XVal--;
                LinkSprite.Update();
        }

            public void LinkTakeDamage()
            {
                HealthVal--;
                //Add an if else to turn link dead if the health is 0 
                LinkObj = new DamagedLink(LinkSpriteFactory, this);
            }

            public void Update()
            {
                if (LinkState == State.UseItem)
                {
                    if(LinkSprite.GetCurrentFrame() == LinkSprite.GetTotalFrames())
                    {
                        switch (LinkDirection)
                        {
                            case Direction.Left:
                                LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemLeft");
                                break;
                            case Direction.Right:
                                LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemRight");
                                break;
                            case Direction.Up:
                                LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemUp");
                                break;
                            default:
                                LinkSprite = LinkSpriteFactory.getAnimatedSprite("ItemDown");
                                break;
                        }
                    }
                }
            }

            public int xPosition()
            {
                return XVal;
            }
            public int yPosition()
            {
                return YVal;
            }
            public int GetHealth()
            {
                return HealthVal;
            }
            /*These next three methods could be compact probably*/
            public int GetDirection()
            {
                int direction = 0;
                switch(LinkDirection)
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
            public String GetState()
            {
                String state = "";
                switch(LinkState)
                {
                    case State.UseItem:
                        state = "UseItem";
                        break;
                    case State.Default:
                        state = "Default";
                        break;
                }
                return state;
            }
            public void SetState(String newState)
            {
                switch(newState)
                {
                    case "UseItem":
                        LinkState = State.UseItem;
                        break;
                    case "Default":
                        LinkState = State.Default;
                    break;
                }
            }
            public void SetRoomId(int id)
            {
                RoomId = id;
            }
            public int GetRoomId() 
            {
                return RoomId;
            }
            /*Needed to reset link after decorator finishes*/
            public void SetLink(ILink link)
            {
                LinkObj = link;
            }

            public void SetSprite(ISprite newLink) 
            {
                LinkSprite = newLink;
            }
            public int width()
            {
                return LinkSprite.GetWidth(); 
            }
            public int height()
            {
                return LinkSprite.GetHeight();
            }
            public bool isDynamic()
            {
                return IsDynamic;
            }
            public bool isUpdateable()
            {
                return IsUpdateable;
            }
            public bool isInPlay()
            {
                return IsInPlay;
            }
            public bool isDrawable()
            {
                return IsDrawable;
            }
            public void Draw(SpriteBatch spriteBatch)
            {
                LinkSprite.Draw(spriteBatch, XVal, YVal);
            }
    }
        

}
