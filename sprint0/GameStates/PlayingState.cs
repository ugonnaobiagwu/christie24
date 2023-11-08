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
using sprint0.Link;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;

public class PlayingState: StateManager, IState
	{
    IState DeathState;
    IState PauseState;
    IState InventoryState;

    private IState state;

    ILink player;
    List<IGameObject> CurrentUpdatables;
   
		public PlayingState()
		{
		}

    public void Update()
    {
        //Code for state transitons => Death, inventory, scroll
    }
    public void EnemyUpdate()
    {
        this.state.EnemyActivate();
    }

    public bool GameResettable()
    {
        return false;
    }

    public string GetState()
    {
        return "Playing";
    }

    public void LinkUpdate()
    {
        this.state.LinkActivate();
    }

    public void RoomUpdate()
    {
        this.state.RoomActivate();
    }


}

