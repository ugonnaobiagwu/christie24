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

        //Item specific fields
        private Boolean itemAttackable;
        //items that attack in zelda 1 do so by moving and colliding with player/enemy
        private int velocityHorizontal; //left = negative, right = positive
        private int velocityVertical; //up = negative, down = positive
        private SpriteBatch itemSpriteBatch { get; set; }
        public ItemFactory(String itemName, SpriteBatch passedBatch)
		{
            SpriteName = itemName;
            itemSpriteBatch = passedBatch;
		}

        public override void attack()
        {
            
            this.Draw(itemSpriteBatch);
            //Update sprite position based on velocity
            SpritePosition = new Vector2(SpritePosition.X + (float)velocityHorizontal, SpritePosition.Y + (float)velocityVertical);
            //Going to have to make a loop for this, will loop based on total active frames of an item and if item has collided yet (if collidable)
        }
    }
}

