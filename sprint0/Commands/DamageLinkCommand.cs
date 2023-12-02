using System;
using sprint0.HUDs;

namespace sprint0.Commands
{
	public class DamageLinkCommand :ICommand
	{
		public DamageLinkCommand()
		{
		}

        public void execute()
        {
            Globals.Link.LinkTakeDamage();
            Inventory.LoseHeart();
        }
    }
}

