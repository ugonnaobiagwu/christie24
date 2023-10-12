using System;
namespace sprint0
{
	public interface IItem
	{
		public void Draw();
		public void Update();
		public void Use(int linkDirection, int linkXPos, int linkYPos);
		
	}
}

