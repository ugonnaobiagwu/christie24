using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBetterBowToACommand : ICommand
    {

        public EquipBetterBowToACommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBetterBow(Globals.ItemSlots.SLOT_A);
        }
    }
}
