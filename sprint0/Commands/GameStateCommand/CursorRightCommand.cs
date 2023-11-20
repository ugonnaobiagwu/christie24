using System;
using sprint0.GameStates;
namespace sprint0.Commands.GameStateCommand
{
    public class CursorRightCommand : ICommand
    {
        Sprint0 Game;
        InventoryCursor Cursor;
        public CursorRightCommand(Sprint0 game, InventoryCursor cursor)
        {
            Cursor = cursor;
            this.Game = game;
        }
        public void execute()
        {
            Cursor.moveRight();
        }
    }
}