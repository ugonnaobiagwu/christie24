using System;
namespace sprint0.Items
{
	public class ItemStateMachine : IItemStateMachine
	{
        private bool inUse;
        public ItemStateMachine()
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

        public void CeaseUse()
        {
            inUse = false;
        }

        
    }
}

