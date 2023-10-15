using System;
namespace sprint0
{
	public interface IGameObject
	{
		public int xPosition(); // returns X pos of object
		public int yPosition(); // returns Y pos of object
		public int area(); // returns rectangle area of object (i.e.) "how big are you?"
		public bool isDynamic(); // does this object move? 
	}
}

