using System;
namespace sprint0.Items
{
	public class BowStateMachine : IItemStateMachine
	{
        private bool inUse;
        public BowStateMachine()
		{
            inUse = false;
		}
        
        /*
         * Changes state of the bow in to 'in use'.
         */
        public void Use()
        {
            inUse = true;
        }

        public bool isItemInUse()
        {
            return inUse;
        }

        public void isEquipped()
        {
            throw new NotImplementedException();
        }

        public void CeaseUse()
        {
            inUse = false;
        }
    }
}

