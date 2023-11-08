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
    IState ScrollState;

    IState state;

    ILink player;
    bool PauseCommand;
    List<IGameObject> CurrentUpdatables;
   
		public PlayingState(IState deathState, IState inventoryState, IState scrollState)
		{
        //Define transition states
        DeathState = deathState;
        InventoryState = inventoryState;
        ScrollState = scrollState;

        //Set conditions for state
        this.state.EnemyUpdate();
        this.state.GameResettable();
        this.state.LinkUpdate();
        this.state.RoomUpdate();

        PauseCommand = false;
		}

    public new void Update()
    {
        //Code for state transitons => Death, inventory, scroll
        if (player.GetHealth() <= 0)
        {
            this.state = ScrollState;
        }
        else if (PauseCommand) {
            this.state = InventoryState;
        } //inventory transition check
        else if () { } //scroll transition check
    }
    //Method to update pause bool based on commands
    public void UpdatePause()
    {
        PauseCommand = true;
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

