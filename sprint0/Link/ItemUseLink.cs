// ﻿using Microsoft.Xna.Framework.Graphics;
// using sprint0.AnimatedSpriteFactory;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace sprint0.Link
// {
//     internal class ItemUseLink : ILink
//     {
//         SpriteFactory LinkFactory;
//         ILink LinkObj;
//         /*NOTE: This number needs to be updated to reflect the actual length of the animation*/
//         int timer = 10;
//         public ItemUseLink(SpriteFactory linkFactory, ILink link)
//         {
//             LinkFactory = linkFactory;
//             LinkObj = link;
//         }
//         /*Link can't move while using an item*/
//         public void LinkUp() { }
//         public void LinkDown() { }
//         public void LinkLeft() { }
//         public void LinkRight() { }
//         public void LinkUseItem() { }
//         public void LinkTakeDamage() 
//         {
//             LinkObj.LinkTakeDamage();           
//         }
//         public int xPosition()
//         {
//             return LinkObj.xPosition();
//         }
//         public int yPosition()
//         {
//             return LinkObj.yPosition();
//         }
//         public int GetDirection()
//         {
//             return LinkObj.GetDirection();
//         }
//         public int GetHealth()
//         {
//             return LinkObj.GetHealth();
//         }
//         public String GetState()
//         {
//             return LinkObj.GetState();
//         }
//         public void SetState(String newState)
//         {
//             LinkObj.SetState(newState);
//         }
//         public void SetLink(ILink link)
//         {
//             LinkObj.SetLink(link);
//         }
//         /*WARNING: This may be a cause of issues, its possible that it may not reset link and instead loop, but I don't think it will.
//          PARRALLEL CODE: ItemUseLink.cs*/
//         public void RemoveDecorator()
//         {
//             LinkObj.SetLink(LinkObj);
//         }
//         public void Update()
//         {
//             LinkObj.Update();
//             if(timer == 0)
//             {
//                 LinkObj.SetState("Default");
//                 RemoveDecorator();
//             }
//             else if (!LinkObj.GetState().Equals("UseItem")) 
//             {
//                 LinkObj.SetSprite(LinkFactory.getAnimatedSprite("UseItem"));
               
//             }
//             LinkObj.Update();
            
//         }
//         public void SetSprite(ISprite newSprite)
//         {
//             LinkObj.SetSprite(newSprite);
//         }
//         public int height()
//         {
//             return LinkObj.height();
//         }
//         public int width()
//         {
//             return LinkObj.width();
//         }
//         public bool isDynamic()
//         {
//             return LinkObj.isDynamic();
//         }
//         public bool isUpdateable()
//         {
//             return LinkObj.isUpdateable();
//         }
//         public bool isDrawable()
//         {
//             return LinkObj.isDrawable();
//         }
//         public bool isRemoveable()
//         {
//             return LinkObj.isRemoveable();
//         }
//         public void SetRoomId(int roomId)
//         {
//             LinkObj.SetRoomId(roomId);
//         }
//         public int GetRoomId()
//         {
//             return LinkObj.GetRoomId();
//         }
//         /*TO BE DELETE: FOR TESTING*/
//         public void Draw(SpriteBatch spriteBatch)
//         {
//             LinkObj.Draw(spriteBatch);
//         }
//     }
// }
