﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class EquipBlazeCommand : ICommand
    {
        Sprint0 Game;
        //ItemSystem Item;

        public EquipBlazeCommand(Sprint0 game) //(ItemSystem item)
        {
            this.Game = game;
            //this.Item = item;
            throw new NotImplementedException();
        }

        public void execute()
        {
            //Item.EquipBlaze();
            throw new NotImplementedException();
        }
    }
}