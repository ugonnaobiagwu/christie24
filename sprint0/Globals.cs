using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace sprint0
{
	public static class Globals
	{
		public static float TotalSeconds { get; set; }
		public static void Update(GameTime timer)
		{
			TotalSeconds = (float)timer.ElapsedGameTime.TotalSeconds;
		}
        public static ItemSystem LinkItemSystem =  new ItemSystem();
		public static GameObjectManager GameObjectManager = new GameObjectManager();
		public enum Direction { Left, Right, Up, Down }
		public static Camera Camera = new Camera();
    }
}

