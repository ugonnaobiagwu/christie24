using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    using global::sprint0.Factory;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;

    /* Need to make interface*/
    public class Link : ILink
        {
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
            
            
            /*Edited to have a texture, row, and column input for the purpose of drawing*/
            public Link(int x, int y, int roomId)
            {
                /*This number is arbitrary*/
                HealthVal = 10;
                LinkSpriteFactory = new LinkFactory();
                XVal = x; YVal = y;
                LinkObj = this;
                RoomId = roomId;
            }

            /*This can be used for both attacking and use item because they have the same Link sprite but different items, which are handled by the item system*/
            public void LinkUseItem()
            {
                /*This may need altered to fit sprite animation length*/
                LinkObj.SetState("UseItem");
                LinkObj = new ItemUseLink(LinkSpriteFactory, SpriteBatch, this);

            }


            /*The directions just change what position he is in, we have these defined already.*/
            public void LinkUp()
            {

                if (LinkDirection != Direction.Up)
                {
                    LinkDirection = Direction.Up;
                    LinkSpriteFactory.changeDirection("up");
                }
                YVal++;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkDown()
            {
                if (LinkDirection != Direction.Down)
                {
                    LinkDirection = Direction.Down;
                    LinkSpriteFactory.changeDirection("down");
                }
                YVal--;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkRight()
            {
                if (LinkDirection != Direction.Right)
                {
                    LinkDirection = Direction.Right;
                    LinkSpriteFactory.changeDirection("right");
                }
                XVal++;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkLeft()
            {
                if (LinkDirection != Direction.Left)
                {
                    LinkDirection = Direction.Left;
                    LinkSpriteFactory.changeDirection("left");
                }
                XVal--;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkTakeDamage()
            {
                HealthVal--;
                /*Will need to add a way to make link invulnerable */
                LinkObj = new DamagedLink(LinkSpriteFactory, this, SpriteBatch);
            }

            public void Update()
            {
                LinkSpriteFactory.Update();
            }

            public int GetXVal()
            {
                return XVal;
            }
            public int GetYVal()
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
                        direction = "left";
                        break;
                    case Direction.Right:
                        direction = "right";
                        break;
                    case Direction.Up:
                        direction = "up";
                        break;
                    case Direction.Down:
                        direction = "down";
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
            public void SetRoomID(int id)
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
            
        }
        

}
