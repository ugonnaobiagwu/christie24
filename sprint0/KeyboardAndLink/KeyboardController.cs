﻿using Microsoft.Xna.Framework.Input;
using Sprint_2;
using System;
using System.Collections.Generic;

public class KeyboardController : IController
{
	// makes a dictionary for the keys and commands
	private Dictionary<Keys, ICommand> KeyMap;
	public KeyboardController()
	{
		KeyMap = new Dictionary<Keys, ICommand>();
	}


    // used to register keys with their respective commands
    // perhaps pass an array that has all the commands?
    public void registerKeys(ICommand[] command)
	{
		// KeyMap[key] = command;
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
