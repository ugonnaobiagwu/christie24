using System;
namespace sprint0.Items
{
	public class BlazeStateMachine : IItemStateMachine
	{
        private enum Direction { Up, Left, Right, Down };

        public BlazeStateMachine()
		{
		}

        public void Use()
        {
            /*
             * return the correct orientation of the item so the object can 
             * construct the right sprite
             */
        }

        public void Equip()
        {
            throw new NotImplementedException();
        }
    }
}

