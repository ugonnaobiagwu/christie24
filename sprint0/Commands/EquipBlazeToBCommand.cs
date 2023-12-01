using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBlazeToBCommand : ICommand
    {

        public EquipBlazeToBCommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBlaze(Globals.ItemSlots.SLOT_B);
        }
    }
}
