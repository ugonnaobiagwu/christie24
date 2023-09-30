﻿using Microsoft.Xna.Framework.Input;
using Sprint0;
using sprint0.Commands;
using System;
using System.Collections.Generic;

public class KeyboardController : IController
{
    //Instantiaze commands
    private ICommand linkWalkingUp;
    private ICommand linkWalkingDown;
    private ICommand linkWalkingLeft;
    private ICommand linkWalkingRight;
    private ICommand linkAttack;
    private ICommand linkAttack;
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

    public KeyboardController()
	{
		KeyMap = new Dictionary<Keys, ICommand>();
        previousKeys = new List<Keys>();

        // not sure if I should put this in here or registerkeys
        linkWalkingUp = new WalkUpCommand();
        linkWalkingLeft = new WalkLeftCommand();
        linkWalkingDown = new WalkDownCommand();
        linkWalkingRight = new WalkRightCommand();
        linkAttack = new AttackCommand();
        linkAttack = new AttackCommand();
        linkEquipItem2 = new EquipItem1Command();
        linkEquipItem2 = new EquipItem2Command();
        linkDamaged = new DamagedCommand();
        previousBlock = new PreviousBlockCommand();
        nextBlock = new NextBlockCommand();
        previousItem = new PreviousItemCommand();
        nextItem = new NextItemCommand();
        previousEnemy = new PreviousEnemyCommand();
        nextEnemy = new NextEnemyCommand();
        quit = new QuitCommand();
        reset = new ResetCommand();

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
        KeyMap.Add(Keys.N, linkAttack);
        KeyMap.Add(Keys.Z, linkAttack);
        KeyMap.Add(Keys.NumPad1, linkEquipItem1);
        KeyMap.Add(Keys.NumPad2, linkEquipItem2);
        KeyMap.Add(Keys.E, linkDamaged);
        KeyMap.Add(Keys.T, previousBlock);
        KeyMap.Add(Keys.Y, nextBlock);
        KeyMap.Add(Keys.U, previousItemD);
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
		foreach (Keys key in Pressed)
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
            lastPressed.execute();
        }

        // does the other commands
        foreach(Keys key in Pressed)
        {
            KeyMap[key].execute();
        }

        // save current keys
        previousKeys = new List<Keys>(pressed);
    }
}
