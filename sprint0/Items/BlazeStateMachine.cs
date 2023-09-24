using System;
namespace sprint0.Items
{
	public class BlazeStateMachine : IItemStateMachine
	{
        private enum GoombaHealth { Normal, Stomped, Flipped };

        public BlazeStateMachine()
		{
		}

        public void inPocket()
        {
            throw new NotImplementedException();
        }

        public void inUse()
        {
            throw new NotImplementedException();
        }
    }
}

