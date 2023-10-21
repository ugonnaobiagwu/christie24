using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBombCommand : ICommand
    {
        Sprint0 Game;
        IItemSystem Item;

        public EquipBombCommand(Sprint0 game, IItemSystem item)
        {
            this.Game = game;
            this.Item = item;
        }

        public void execute()
        {
            Item.EquipBomb();
        }
    }
}
