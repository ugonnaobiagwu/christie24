using System;
using sprint0;
using sprint0.Commands;

namespace sprint0.Commands
{
    public class NextRoomCommand : ICommand
    {
        private ChangeRooms changeRooms;

        public NextRoomCommand(ChangeRooms room)
        {
            changeRooms = room;
        }

        public void execute()
        {
            changeRooms.MoveToNextRoom();
        }
    }
}
