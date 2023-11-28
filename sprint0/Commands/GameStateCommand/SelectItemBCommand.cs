using System;
using sprint0.GameStates;
using static sprint0.HUDs.Inventory;

namespace sprint0.Commands.GameStateCommand
{
    public class SelectItemBCommand : ICommand
    {
        Sprint0 Game;
        InventoryCursor Cursor;
        private ICommand linkEquipBow;
        private ICommand linkEquipBoomerang;
        private ICommand linkEquipBomb;
        private ICommand linkEquipBlaze;
        public SelectItemBCommand(Sprint0 game, InventoryCursor cursor, ICommand equipBow, ICommand equipBomb, ICommand equipBoomerang, ICommand equipBlaze)
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
        }
    }
}


