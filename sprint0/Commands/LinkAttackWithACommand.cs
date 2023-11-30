using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.LinkObj;
using sprint0.Sound.Ocarina;

namespace sprint0.Commands
{
    public class LinkAttackWithACommand : ICommand
    {
        public LinkAttackWithACommand()
        {
        }

        public void execute()
        {
            //Globals.Link.LinkUseItem();
            Globals.LinkItemSystem.UseCurrentItemA(Globals.Link.GetDirection(), Globals.Link.xPosition(), Globals.Link.yPosition(), Globals.Link.height(), Globals.Link.width());

        }
    }
}
