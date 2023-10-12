using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace sprint0.Items
{
	public class BetterBoomerang : IItem
	{
        private ISprite thisSprite;

		public BetterBoomerang(IList<Texture2D> itemSpriteSheet)
        {
            
		}

        public void Draw()
        {
            //thisSprite.Draw();
        }

        public void Update()
        {
            //thisSprite.Update();
        }

        public void Use()
        {
            //thisSprite = new BetterBoomerang();
        }
    }
}

