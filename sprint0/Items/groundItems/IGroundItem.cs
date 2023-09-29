using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items.groundItems
{
	public interface IGroundItem
	{
		public void Update();
		public void Draw(SpriteBatch spriteBatch, int x, int y);
	}
}

