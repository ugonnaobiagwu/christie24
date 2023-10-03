using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace sprint0.Factory
{
	public class ItemFactory : SpriteFactory
	{
        private Texture2D SpriteSheet { get; set; }
        private Vector2 SpritePosition { get; set; }
        private string SpriteName { get; set; }
        private string SpriteDirection { get; set; }
        private int SpriteFrames { get; set; }
        private Boolean SpriteCollidable { get; set; }
        private IDictionary<int, Rectangle> TextureDictionary { get; set; }
        public ItemFactory()
		{
		}

        public override void attack()
        {
            //Unless items have uniform attack animation this is gonna have a ton of cases dependent of SpriteName
            throw new NotImplementedException();
        }
    }
}

