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
	public void registerKeys(Keys key, ICommand command)
	{
		KeyMap[key] = command;

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
