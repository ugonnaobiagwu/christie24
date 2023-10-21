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
            private bool IsRemoveable = true;
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
                LinkObj = new ItemUseLink(LinkSpriteFactory, this);

            }


            /*The directions just change what position he is in, we have these defined already.*/
            public void LinkUp()
            {

                if (LinkDirection != Direction.Up)
                {
                    LinkDirection = Direction.Up;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Up");
                }
                YVal++;
                
            }

            public void LinkDown()
            {
                if (LinkDirection != Direction.Down)
                {
                    LinkDirection = Direction.Down;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Down");
                }
                YVal--;
            }

            public void LinkRight()
            {
                if (LinkDirection != Direction.Right)
                {
                    LinkDirection = Direction.Right;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Right");
                }
                XVal++;
            }

            public void LinkLeft()
            {
                if (LinkDirection != Direction.Left)
                {
                    LinkDirection = Direction.Left;
                    LinkSprite = LinkSpriteFactory.getAnimatedSprite("Left");
                }
                XVal--;
            }

            public void LinkTakeDamage()
            {
                HealthVal--;
                
                LinkObj = new DamagedLink(LinkSpriteFactory, this);
            }

            public void Update()
            {
                LinkSprite.Update();
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
            public String GetDirection()
            {
                String direction = "";
                switch(LinkDirection)
                {
                    case Direction.Left:
                        direction = "Left";
                        break;
                    case Direction.Right:
                        direction = "Right";
                        break;
                    case Direction.Up:
                        direction = "Up";
                        break;
                    case Direction.Down:
                        direction = "Down";
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
            public void Draw(SpriteBatch spriteBatch) 
            {
            /*This comes down to Sprite Factory*/
                LinkSprite.Draw(spriteBatch, XVal, YVal);
            }
            public void SetSprite(ISprite newLink) 
            {
                LinkSprite = newLink;
            }
            public int width()
            {
                //DEPENDS ON SPRITEFACTORY
                return 1;
            }
            public int height()
            {
                //DEPENDS ON SPRITEFACTORY
                return 1;
            }
            public bool isDynamic()
            {
                return IsDynamic;
            }
            public bool isUpdateable()
            {
                return IsUpdateable;
            }
            public bool isRemoveable()
            {
                return IsRemoveable;
            }
            public bool isDrawable()
            {
                return IsDrawable;
            }
            public void Draw(SpriteBatch spriteBatch, int x, int y)
            {
                LinkSprite.Draw(spriteBatch, x, y);
            }
    }
        

}
