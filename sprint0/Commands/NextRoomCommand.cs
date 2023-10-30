﻿using System;
using sprint0;
using sprint0.Commands;
using sprint0.Rooms;

namespace sprint0.Commands
{
    public class NextRoomCommand : ICommand
    {
        private Room room;

        public NextRoomCommand(Room room)
        {
            this.room = room;
        }

        public void execute()
        {
            room.NextRoom();
        }
    }
}