using System;
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
        }
    }
}

