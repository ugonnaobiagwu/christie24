using System;
namespace sprint0.Items
{
	public interface IItemSprite : ISprite
	{
		public bool finishedAnimationCycle();
		public int itemWidth();
		public int itemHeight();
	}
}

