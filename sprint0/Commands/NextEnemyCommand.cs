using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;

namespace sprint0.Commands
{
    public class NextEnemyCommand : ICommand
    {
        Sprint0 Game;
        //Enemy Monster;

        public NextEnemyCommand(Sprint0 game) //(Enemy monster)
        {
            this.Game = game;
            //this.Monster = monster;
            throw new NotImplementedException();
        }

        public void execute()
        {
            //Monster.NextEnemy();
            throw new NotImplementedException();
        }
    }
}
