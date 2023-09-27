using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class WalkDownCommand : ICommand
    {
        Sprint0 Game;
        //Player link;

        public WalkDownCommand(Sprint0 game) //(Player link)
        {
            this.Game = game;
            //this.Link = link;
            throw new NotImplementedException();
        }

        public void execute()
        {
            //Link.walkDown();
            throw new NotImplementedException();
        }
    }
}
