using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class QuitCommand : ICommand
    {
        Sprint0 Game;

        public QuitCommand(Sprint0 game)
        {
            this.Game = game;
        }

        public void execute()
        {
            Game.Exit();
        }
    }
}
