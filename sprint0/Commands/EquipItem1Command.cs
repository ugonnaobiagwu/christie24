using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Items;

namespace sprint0.Commands
{
    public class EquipItem1Command
    {
        Sprint0 Game;
        ItemSystem Item;

        public EquipItem1Command(Sprint0 game, ItemSystem item)
        {
            this.Game = game;
            this.Item = item;
        }

        public void execute()
        {
            //Item.EquipNextItem();
            throw new NotImplementedException();
        }
    }
}
