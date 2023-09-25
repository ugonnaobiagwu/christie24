using System;
using sprint0.Items;

namespace sprint0
{
	public class BombStateMachine : IItemStateMachine
    {
        public BombStateMachine()
		{
		}

        public void Explode()
        {
            throw new NotImplementedException();
        }
        public void Use()
        {
            /*
             * return the correct orientation of the item so the object can 
             * construct the right sprite
             */
        }

        public void IsEquipped()
        {
            throw new NotImplementedException();
        }
    }
}

