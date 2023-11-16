using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using sprint0.LinkObj;

namespace sprint0
{
	public static class Globals
	{
		public static float TotalSeconds { get; set; }
		public static void Update(GameTime timer)
		{
			TotalSeconds = (float)timer.ElapsedGameTime.TotalSeconds;
		}
		public static ItemSystem LinkItemSystem = new ItemSystem();
		public static GameObjectManager GameObjectManager = new GameObjectManager();
		public enum Direction { Left, Right, Up, Down }
		public static Camera Camera = new Camera();
		public static ILink Link;
		public enum ItemSlots { SLOT_A, SLOT_B };
		public enum ItemsInSlots { BOW, BETTER_BOW, BOOMERANG, BETTER_BOOMERANG, BLAZE, BOMB, SWORD, EMPTY};
    }
}

