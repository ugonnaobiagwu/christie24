using System;
namespace sprint0.Items.groundItems
{
	public interface IGroundItemSystem
	{
		public void NextItem();
		public void PreviousItem();
		public void Draw();
		public void Update();
	}
}

