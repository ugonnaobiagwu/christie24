using System;
using sprint0.GameStates;
namespace sprint0.Commands.GameStateCommand
{
	public class CursorLeftCommand:ICommand
    {
        Sprint0 Game;
        InventoryCursor Cursor;
        public CursorLeftCommand(Sprint0 game, InventoryCursor cursor)
		{
            Cursor = cursor;
            this.Game = game;
		}
        public void execute()
        {
            Cursor.moveLeft();
        }
    }
}

