using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
	public interface IItemSystem
	{
		/* 
		 * Requires that items are properly loaded before system use.
		*/
		public void LoadBow(IList<Texture2D> itemSpriteSheet);
		public void LoadBetterBow(IList<Texture2D> itemSpriteSheet);
		public void LoadBoomerang(IList<Texture2D> itemSpriteSheet);
		public void LoadBetterBoomerang(IList<Texture2D> itemSpriteSheet);
		public void LoadBlaze(IList<Texture2D> itemSpriteSheet);
		public void LoadBomb(IList<Texture2D> itemSpriteSheet);
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


