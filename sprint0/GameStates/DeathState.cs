using System;
namespace sprint0.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Items.groundItems;
using System.Runtime.CompilerServices;
using sprint0.Controllers;
using sprint0.Blocks;
using sprint0.LinkObj;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;

	public class DeathState : IState
	{
		public DeathState()
		{
		}

        //Takes a list of all enemies and updates their 
        public void EnemyUpdate()
        {
            throw new NotImplementedException();
        }

        public bool GameResettable()
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            throw new NotImplementedException();
        }

        public void LinkUpdate()
        {
            throw new NotImplementedException();
        }

        public void RoomUpdate()
        {
            throw new NotImplementedException();
        }
    }


