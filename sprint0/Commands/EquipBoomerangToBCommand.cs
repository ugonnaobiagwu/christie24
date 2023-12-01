using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBoomerangToBCommand : ICommand
    {

        public EquipBoomerangToBCommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBoomerang(Globals.ItemSlots.SLOT_B);
        }
    }
}
