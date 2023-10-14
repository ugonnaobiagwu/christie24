using System;
namespace sprint0.Items
{
	public interface IItemStateMachine
	{
        public void Use();
        public bool isItemInUse();
        public void CeaseUse();

    }
}

