using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipSwordToACommand : ICommand
    {

        public EquipSwordToACommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipSword(Globals.ItemSlots.SLOT_A);
        }
    }
}
