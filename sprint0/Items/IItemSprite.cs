using System;
namespace sprint0.Items
{
	public interface IItemSprite : ISprite
	{
		public int currentItemXPos();
		public int currentItemYPos();
		public bool finishedAnimationCycle();
	}
}

