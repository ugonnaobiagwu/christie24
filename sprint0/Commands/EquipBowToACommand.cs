using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBowToACommand : ICommand
    {

        public EquipBowToACommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBow(Globals.ItemSlots.SLOT_A);
        }
    }
}
