using System;
namespace sprint0
{
	public interface IGameObject
	{
        public void addToList(int room, Object obj); //adds object to list
        public void removeFromList(int room, Object obj); //removes object from list
    }
}

