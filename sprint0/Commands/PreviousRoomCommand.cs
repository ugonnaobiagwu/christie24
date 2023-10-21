using System;
using sprint0;
using sprint0.Commands;

namespace sprint0.Commands
{
    public class PreviousRoomCommand : ICommand
    {
        private ChangeRooms changeRooms;

        public PreviousRoomCommand(ChangeRooms room)
        {
            changeRooms = room;
        }

        public void execute()
        {
            changeRooms.MoveToPreviousRoom();
        }
    }
}
