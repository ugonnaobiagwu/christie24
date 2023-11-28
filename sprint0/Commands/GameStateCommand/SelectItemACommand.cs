using System;
using sprint0.GameStates;
using static sprint0.HUDs.Inventory;

namespace sprint0.Commands.GameStateCommand
{
	public class SelectItemACommand :ICommand
	{
        Sprint0 Game;
        InventoryCursor Cursor;
        private ICommand linkEquipBow;
        private ICommand linkEquipBoomerang;
        private ICommand linkEquipBomb;
        private ICommand linkEquipBlaze;
        public SelectItemACommand(Sprint0 game, InventoryCursor cursor, ICommand equipBow, ICommand equipBomb, ICommand equipBoomerang, ICommand equipBlaze)
		{
            this.Game = game;
            Cursor = cursor;

            linkEquipBow = equipBow;
            linkEquipBoomerang = equipBoomerang;
            linkEquipBomb = equipBomb;
            linkEquipBlaze = equipBlaze;
        }

        public void execute()
        {
            Console.WriteLine("Item switch A");
            switch (Cursor.ReturnSelectedItem())
            {
                case ItemTypes.BOOMERANG:
                    if (Globals.LinkItemSystem.ItemInSlotB != Globals.ItemsInSlots.BOOMERANG)
                    {
                        linkEquipBoomerang.execute();
                    }
                    break;
                case ItemTypes.BOMB:
                    if (Globals.LinkItemSystem.ItemInSlotB != Globals.ItemsInSlots.BOMB)
                    {
                        linkEquipBomb.execute();
                    }
                    break;
                case ItemTypes.BOW:
                    if (Globals.LinkItemSystem.ItemInSlotB != Globals.ItemsInSlots.BOW)
                    {
                        linkEquipBow.execute();
                    }
                    break;
                case ItemTypes.BLAZE:
                    if (Globals.LinkItemSystem.ItemInSlotB != Globals.ItemsInSlots.BLAZE)
                    {
                        linkEquipBlaze.execute();
                    }
                    break;
            }
        }
    }
}

