using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBetterBowToBCommand : ICommand
    {

        public EquipBetterBowToBCommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBetterBow(Globals.ItemSlots.SLOT_B);
        }
    }
}
