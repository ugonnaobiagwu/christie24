using System;
using sprint0.GameStates;
using static sprint0.HUDs.Inventory;
using static sprint0.Globals;
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
            //Console.WriteLine("Item switch A");
            if (Cursor.currentRow == 0)
            {
                switch (Cursor.ReturnSelectedItem())
                {
                    case ItemTypes.BOOMERANG:
                        linkEquipBoomerang.execute();
                        break;
                    case ItemTypes.BOMB:
                        linkEquipBomb.execute();
                        break;
                    case ItemTypes.BOW:
                        linkEquipBow.execute();
                        break;
                    case ItemTypes.BLAZE:
                        linkEquipBlaze.execute();
                        break;
                }
            } else if (Cursor.currentRow == 1)
            {
                switch (Cursor.ReturnSelectedTunic())
                {
                    case LinkTunic.GREEN:
                        Console.WriteLine("A green tunic");
                        Globals.LinkItemSystem.CurrentTunic = LinkTunic.GREEN;
                        break;
                    case LinkTunic.FIRE:
                        Console.WriteLine("A fire tunic");
                        Globals.LinkItemSystem.CurrentTunic = LinkTunic.FIRE;
                        break;
                    case LinkTunic.ICE:
                        Globals.LinkItemSystem.CurrentTunic = LinkTunic.ICE;
                        break;
                }
            }
        }
    }
}

