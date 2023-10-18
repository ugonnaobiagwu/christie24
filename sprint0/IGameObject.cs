﻿using System;
namespace sprint0
{
	public interface IGameObject
	{
        public void addToList(int level, Object obj); //adds object to list
		public int xPosition(); // returns X pos of object
		public int yPosition(); // returns Y pos of object
		public int width(); // (i.e.) "how big are you?"
		public int height(); // (i.e.) "how big are you?"
		public bool isDynamic(); // does this object move? 
	}
}

