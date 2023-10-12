using System;
namespace sprint0
{
	public interface IItemSystem
	{
		public void EquipNextItem();
		public void EquipPreviousItem();
		public void UseCurrentItem();
		public void Draw(); // draws the current item.
		public void Update(); // updates the current item

    }
}


