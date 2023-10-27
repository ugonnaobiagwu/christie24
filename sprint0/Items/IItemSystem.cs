using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;

namespace sprint0
{
	public interface IItemSystem
	{
		/* 
		 * Requires that items are properly loaded before system use.
		*/
		public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
        public void LoadBow(SpriteFactory factory);
		public void LoadBetterBow(SpriteFactory factory);
		public void LoadBoomerang(SpriteFactory factory);
		public void LoadBetterBoomerang(SpriteFactory factory);
		public void LoadBlaze(SpriteFactory factory);
		public void LoadBomb(SpriteFactory factory);
		public void LoadSpriteBatch(SpriteBatch incomingSpriteBatch);
        public void EquipBow();
		public void EquipBetterBow();
		public void EquipBoomerang();
		public void EquipBetterBoomerang();
		public void EquipBlaze();
		public void EquipBomb();
		public void UseCurrentItem(int linkDirection, int linkXPos, int linkYPos); // send in link's data as the parameters. enumerations are built upon ints.
		public void Draw(); // draws the current item in link's equipment
        public void Update(); // updates the current item in link's equipment

    }
}


