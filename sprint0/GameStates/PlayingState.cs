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

public class PlayingState:  StateManager, IState
	{

    IState state;

    ILink player;
    bool PauseCommand;
    List<IGameObject> CurrentUpdatables;

    public PlayingState(ILink link)
    {
        
        player = link;
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
            state.StateTransition("Dead");
        }
        else if (PauseCommand) {
            state.StateTransition("Inventory");
        } //inventory transition check
        else if () { } //scroll transition check
    }
    //Method to update pause bool based on commands
    public void UpdatePause()
    {
        PauseCommand = true;
    }
 
    public new void EnemyUpdate()
    {
        this.state.EnemyActivate();
    }

    public new bool GameResettable()
    {
        return false;
    }

    public new string GetState()
    {
        return "Playing";
    }

    public new void LinkUpdate()
    {
        this.state.LinkActivate();
    }

    public new void RoomUpdate()
    {
        this.state.RoomActivate();
    }


}

