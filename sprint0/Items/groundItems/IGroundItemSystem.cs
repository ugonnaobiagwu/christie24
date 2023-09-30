using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items.groundItems
{
	public interface IGroundItemSystem
	{
		public void NextItem();
		public void PreviousItem();
		public void Draw();
		public void Update();
		public void LoadBow(Texture2D itemSpriteSheet);
		public void LoadBoomerang(Texture2D itemSpriteSheet);
		public void LoadBomb(Texture2D itemSpriteSheet);
		public void LoadBlaze(Texture2D itemSpriteSheet);
		public void LoadHeart(Texture2D itemSpriteSheet);
		public void LoadShimmeringRupee(Texture2D itemSpriteSheet);
		public void LoadFairy(Texture2D itemSpriteSheet);
		public void LoadTriforcePiece(Texture2D itemSpriteSheet);
		public void LoadKey(Texture2D itemSpriteSheet);
		public void LoadRupee(Texture2D itemSpriteSheet);
		public void LoadPage(Texture2D itemSpriteSheet);
		public void LoadBigHeart(Texture2D itemSpriteSheet);
		public void LoadCompass(Texture2D itemSpriteSheet);
		public void LoadClock(Texture2D itemSpriteSheet);
	}
}

