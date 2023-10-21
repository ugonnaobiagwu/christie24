using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Link;

namespace sprint0.Commands
{
    public class WalkRightCommand : ICommand
    {
        Sprint0 Game;
        ILink Link;

        public WalkRightCommand(Sprint0 game, ILink link)
        {
            this.Game = game;
            this.Link = link;
        }

        public void execute()
        {
            Link.LinkRight();
        }
    }
}
