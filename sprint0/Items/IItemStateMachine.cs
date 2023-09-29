using System;
namespace sprint0.Items
{
	public interface IItemStateMachine
	{
		public void Use();
		public void CeaseUse();
        public bool isItemInUse(); // reports the current state of the item usage

    }
}

