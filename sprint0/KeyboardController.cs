using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class KeyboardController : IController
{
	private Dictionary<Keys, ICommand> KeyMap;
	public KeyboardController()
	{
		KeyMap = new Dictionary<Keys, ICommand>();
	}
	public void registerKey(Keys key, ICommand command)
	{
		KeyMap.Add(key, command);
	}
	public void Update()
	{
		Keys[] Pressed = Keyboard.GetState().GetPressedKeys(); 
		foreach (Keys key in Pressed)
		{
			KeyMap[key].execute();
		}
	}
}
