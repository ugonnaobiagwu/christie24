using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBombToBCommand : ICommand
    {

        public EquipBombToBCommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBomb(Globals.ItemSlots.SLOT_B);
        }
    }
}
