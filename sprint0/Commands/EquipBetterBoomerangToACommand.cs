using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBetterBoomerangToACommand : ICommand
    {

        public EquipBetterBoomerangToACommand()
        {
        }

        public void execute()
        {
            Globals.LinkItemSystem.EquipBetterBoomerang(Globals.ItemSlots.SLOT_A);
        }
    }
}
