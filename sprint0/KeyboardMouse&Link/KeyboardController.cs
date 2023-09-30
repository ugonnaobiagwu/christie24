﻿using Microsoft.Xna.Framework.Input;

using sprint0.Commands;
using System;
using System.Collections.Generic;

public class KeyboardController
{
    //Instantiaze commands
    private ICommand linkWalkingUp;
    private ICommand linkWalkingDown;
    private ICommand linkWalkingLeft;
    private ICommand linkWalkingRight;
    private ICommand linkAttack1;
    private ICommand linkAttack2;
    private ICommand linkEquipItem1;
    private ICommand linkEquipItem2;
    private ICommand linkDamaged;
    private ICommand previousBlock; 
    private ICommand nextBlock;
    private ICommand previousItem;
    private ICommand nextItem;
    private ICommand previousEnemy;
    private ICommand nextEnemy;
    private ICommand quit;
    private ICommand reset;

    // makes a dictionary for the keys and commands
    private Dictionary<Keys, ICommand> KeyMap;
    // to store the previous keyboard state
    private List<Keys> previousKeys;
    private List<Keys> pressed;

    public KeyboardController(sprint0.Sprint0 Game)
	{
		KeyMap = new Dictionary<Keys, ICommand>();
        previousKeys = new List<Keys>();

        // not sure if I should put this in here or registerkeys
        //linkWalkingUp = new WalkUpCommand(Game);
        //linkWalkingLeft = new WalkLeftCommand(Game);
        //linkWalkingDown = new WalkDownCommand(Game);
        //linkWalkingRight = new WalkRightCommand(Game);
        //linkAttack1 = new AttackCommand(Game);
        //linkAttack2 = new AttackCommand(Game);
        //linkEquipItem2 = new EquipItem1Command(Game);
        //linkEquipItem2 = new EquipItem2Command(Game);
        //linkDamaged = new DamagedCommand(Game);
        //previousBlock = new PreviousBlockCommand(Game);
        //nextBlock = new NextBlockCommand(Game);
        previousItem = new PreviousItemCommand(Game, Game.groundItems);
        nextItem = new NextItemCommand(Game, Game.groundItems);
        //previousEnemy = new PreviousEnemyCommand(Game);
        //nextEnemy = new NextEnemyCommand(Game);
        quit = new QuitCommand(Game);
        //reset = new ResetCommand(Game);

    }

    


    // used to register keys with their respective commands
    // perhaps pass an array that has all the commands?
    public void registerKeys()
	{
		// KeyMap[key] = command;
        // Names of Commands are not permanent
        KeyMap.Add(Keys.W, linkWalkingUp);
        KeyMap.Add(Keys.A, linkWalkingLeft);
        KeyMap.Add(Keys.S, linkWalkingDown);
        KeyMap.Add(Keys.D, linkWalkingRight);
        KeyMap.Add(Keys.N, linkAttack1);
        KeyMap.Add(Keys.Z, linkAttack2);
        KeyMap.Add(Keys.NumPad1, linkEquipItem1);
        KeyMap.Add(Keys.NumPad2, linkEquipItem2);
        KeyMap.Add(Keys.E, linkDamaged);
        KeyMap.Add(Keys.T, previousBlock);
        KeyMap.Add(Keys.Y, nextBlock);
        KeyMap.Add(Keys.U, previousItem);
        KeyMap.Add(Keys.I, nextItem);
        KeyMap.Add(Keys.O, previousEnemy);
        KeyMap.Add(Keys.P, nextEnemy);
        KeyMap.Add(Keys.Q, quit);
        KeyMap.Add(Keys.R, reset);

    }

	// executes commands for each key pressed
    public void Update()
	{
		pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
        Keys lastPressed = Keys.None;

        // tentative transitions
        // so this loop adds new command in to previousKeys
		foreach (Keys key in pressed)
		{
            // adds to the list the current action/command
            if (!previousKeys.Contains(key) && pressed.Contains(key))
            {
                KeyMap[key].execute();
                previousKeys.Add(key);
                lastPressed = key;
                break;
            }
		}

        // makes sure it executes
        if (lastPressed != Keys.None)
        {
            KeyMap[lastPressed].execute();
        }

        // does the other commands
        foreach(Keys key in pressed)
        {
            KeyMap[key].execute();
        }

        // save current keys
        previousKeys = new List<Keys>(pressed);
    }
}
