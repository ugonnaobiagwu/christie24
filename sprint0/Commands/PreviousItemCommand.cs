using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Items.groundItems;

namespace sprint0.Commands
{
    public class PreviousItemCommand : ICommand
    {
        Sprint0 Game;
        GroundItemSystem Weapon;

        public PreviousItemCommand(Sprint0 game, GroundItemSystem weapon)
        {
            this.Game = game;
            this.Weapon = weapon;
        }

        public void execute()
        {
            Weapon.PreviousItem();
        }
    }
}
