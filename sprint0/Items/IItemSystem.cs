﻿using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;
using static sprint0.Globals;

namespace sprint0
{
	public interface IItemSystem
	{
		/* 
		 * Requires that items are properly loaded before system use.
		*/
		//public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth); // WILL GET REMOVED LATER

		public void LoadBow(SpriteFactory factory, SpriteFactory despawnFactory);
		public void LoadBetterBow(SpriteFactory factory, SpriteFactory despawnFactory);
        public void LoadBoomerang(SpriteFactory factory);
		public void LoadBetterBoomerang(SpriteFactory factory);
		public void LoadBlaze(SpriteFactory factory);
		public void LoadBomb(SpriteFactory factory, SpriteFactory explosiveFactory);
		public void LoadSword(SpriteFactory factory, SpriteFactory iceFactory, SpriteFactory fireFactory);
        public void LoadSpriteBatch(SpriteBatch incomingSpriteBatch);

        /* Equipment methods. Can only be called if an item is not alraedy equipped to that 
		 * button.
		 * 
		 * itemButton 1 - A BUTTON
		 * itemButton 2 - B BUTTON
		 */

        //Will later ensures that you cant have two items equipped to the same button, by swapping them out if so
		//Link Sword will need a new instance upon equipment 

        public void EquipBow(Globals.ItemSlots itemSlot);
		public void EquipBetterBow(Globals.ItemSlots itemSlot);
		public void EquipBoomerang(Globals.ItemSlots itemSlot);
		public void EquipBetterBoomerang(Globals.ItemSlots itemSlot);
		public void EquipBlaze(Globals.ItemSlots itemSlot);
		public void EquipBomb(Globals.ItemSlots itemSlot);
        public void EquipSword(Globals.ItemSlots itemSlot);

        //public void UseCurrentItem(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth); // send in link's data as the parameters. enumerations are built upon ints.
        
		public void UseCurrentItemA(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
		
		public void UseCurrentItemB(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
		 
        public void Draw(); // draws both items in link's equipment
        public void Update(); // updates the both items in link's equipment

    }
}


