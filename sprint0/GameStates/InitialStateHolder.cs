using System;
using sprint0.LinkObj;

namespace sprint0.GameStates
{
	public static class InitialStateHolder
	{
		public static ILink InitialLink { get; set; }
		public static Camera InitialCamera { get; set; }
		public static GameObjectManager InitialGameObjectManager { get; set; }

    }
}

