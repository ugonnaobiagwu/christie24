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

	public class DeathState : StateManager, IState
	{

    IState PlayingState;

    private IState state;

    ILink player;
    List<IGameObject> CurrentUpdatables;
    public DeathState(IState playingState)
		{
        //Define transition states
        PlayingState = playingState;

        //Set conditions for state
        this.state.EnemyUpdate();
        this.state.GameResettable();
        this.state.LinkUpdate();
        this.state.RoomUpdate();
    }
    private new void Update()
    {
        //Add logic for transition into play state here - based on commands, key press?
    }
        //Takes a list of all enemies and updates their 
        public new void EnemyUpdate()
        {
        this.state.EnemyDeactivate();
        }

        public new bool GameResettable()
        {
        return true;
        }

        public new string GetState()
        {
        return "Dead";
        }

        public new void LinkUpdate()
        {
        this.state.LinkDeactivate();
        }

        public new void RoomUpdate()
        {
        this.state.RoomDeactivate();
        }
    }


