using System;
namespace sprint0
{
	public interface IGameObject
	{
		public int xPosition(); // returns X pos of object
		public int yPosition(); // returns Y pos of object
		public int width(); // (i.e.) "how big are you?"
        public int height(); // (i.e.) "how big are you?"
        public bool isDynamic(); // does this object move? 
		public bool isUpdateable();
		public bool isDrawable();
		public bool isRemoveable();
		public void SetRoomId(int roomId);
		public int GetRoomId();
	}
}

