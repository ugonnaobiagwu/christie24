﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class NextItemCommand : ICommand
    {
        Sprint0 Game;
        //Item Weapon;

        public NextItemCommand(Sprint0 game) //(Item weapon)
        {
            this.Game = game;
            //this.Weapon = weapon;
            throw new NotImplementedException();
        }

        public void execute()
        {
            //Weapon.NextItem();
            throw new NotImplementedException();
        }
    }
}
