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
    public class AttackCommand : ICommand
    {
        Sprint0 Game;
        ILink Link;
        IItemSystem LinkItems;


        public AttackCommand(Sprint0 game, ILink link, IItemSystem linkItemSystem)
        {
            this.Game = game;
            this.Link = link;
            this.LinkItems = linkItemSystem;
        }

        public void execute()
        {
            Link.LinkUseItem();
            LinkItems.UseCurrentItem(Link.GetDirection(), Link.xPosition(), Link.yPosition(), Link.height(), Link.width());
          
        }
    }
}
