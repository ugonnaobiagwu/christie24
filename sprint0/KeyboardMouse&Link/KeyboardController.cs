﻿using Microsoft.Xna.Framework.Input;
using Sprint_2;
using System;
using System.Collections.Generic;

public class KeyboardController : IController
{
    //Instantiaze commands
    ICommand linkWalkingUp;
    ICommand linkWalkingDown;
    ICommand linkWalkingLeft;
    ICommand linkWalkingRight;
    ICommand linkAttack;
    ICommand linkAttack;
    ICommand linkEquipItem1;
    ICommand linkEquipItem2;
    ICommand linkDamaged; 
    ICommand previousBlock;
    ICommand nextBlock;
    ICommand previousItem;
    ICommand nextItem;
    ICommand previousEnemy;
    ICommand nextEnemy;
    ICommand quit;
    ICommand reset;

    // makes a dictionary for the keys and commands
    private Dictionary<Keys, ICommand> KeyMap;
	public KeyboardController()
	{
		KeyMap = new Dictionary<Keys, ICommand>();

        // not sure if I should put this in here or registerkeys
        linkWalkingUp = new LinkWalkingUp();
        linkWalkingLeft = new LinkWalkingLeft();
        linkWalkingDown = new LinkWalkingDown();
        linkWalkingRight = new LinkWalkingRight();
        linkAttack = new LinkAttack();
        linkAttack = new LinkAttack();
        linkEquipItem2 = new LinkEquipItem1();
        linkEquipItem2 = new LinkEquipItem2();
        linkDamaged = new LinkDamaged();
        previousBlock = new PreviousBlock();
        nextBlock = new NextBlock();
        previousItem = new PreviousItemD();
        nextItem = new NextItem();
        previousEnemy = new PreviousEnemy();
        nextEnemy = new NextEnemy();
        quit = new Quit();
        reset = new Reset();

    }


    // used to register keys with their respective commands
    // perhaps pass an array that has all the commands?
    public void registerKeys()
	{
		// KeyMap[key] = command;
        // Names of Commands are not permanent
        // does not detect transition states
        // you need to detect transitions 
        KeyMap.Add(Keys.W, LinkWalkingUp);
        KeyMap.Add(Keys.A, LinkWalkingLeft);
        KeyMap.Add(Keys.S, LinkWalkingDown);
        KeyMap.Add(Keys.D, LinkWalkingRight);
        KeyMap.Add(Keys.N, LinkAttack);
        KeyMap.Add(Keys.Z, LinkAttack);
        KeyMap.Add(Keys.NumPad1, LinkEquipItem1);
        KeyMap.Add(Keys.NumPad2, LinkEquipItem2);
        KeyMap.Add(Keys.E, LinkDamaged);
        KeyMap.Add(Keys.T, PreviousBlock);
        KeyMap.Add(Keys.Y, NextBlock);
        KeyMap.Add(Keys.U, PreviousItemD);
        KeyMap.Add(Keys.I, NextItem);
        KeyMap.Add(Keys.O, PreviousEnemy);
        KeyMap.Add(Keys.P, NextEnemy);
        KeyMap.Add(Keys.Q, Quit);
        KeyMap.Add(Keys.R, Reset);

    }

	// executes commands for each key pressed
    public void Update()
	{
		Keys[] Pressed = Keyboard.GetState().GetPressedKeys(); 
		foreach (Keys key in Pressed)
		{
			KeyMap[key].execute();
		}
	}
}
