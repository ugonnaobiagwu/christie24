using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using sprint0.Commands;
using sprint0.Blocks;
using sprint0;
using sprint0.Commands.GameStateCommand;
using sprint0.GameStates;

namespace sprint0.Controllers
{
    public class InventoryController
    {
        //Instantiaze commands
        private ICommand cursorLeft;
        private ICommand cursorRight;
        private ICommand cursorUp;
        private ICommand cursorDown;
        private ICommand selectItemA;
        private ICommand selectItemB;

        private ICommand leftScroll;

        // makes a dictionary for the keys and commands
        private Dictionary<Keys, ICommand> KeyMap;
        // to store the previous keyboard state
        private List<Keys> previousKeys;
        private List<Keys> pressed;

        public InventoryController(sprint0.Sprint0 Game, InventoryCursor cursor)
        {
            KeyMap = new Dictionary<Keys, ICommand>();
            previousKeys = new List<Keys>();

            cursorLeft = new CursorLeftCommand(Game, cursor);
            cursorRight = new CursorRightCommand(Game, cursor);
            cursorUp = new CursorUpCommand(Game, cursor);
            cursorDown = new CursorDownCommand(Game, cursor);

            leftScroll = new LeftScrollCommand(Game);
        }
        public void registerKeys()
        {
            KeyMap.Add(Keys.W, cursorUp);
            KeyMap.Add(Keys.A, cursorLeft);
            KeyMap.Add(Keys.S, cursorDown);
            KeyMap.Add(Keys.D, cursorRight);

            KeyMap.Add(Keys.J, leftScroll);
        }

        public void Update()
        {

            // EDGE TRANSITIONS
            // If a key is in pressed but not in previousKeys
            // it means it was just pressed, so we execute.
            pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());

            // press transitions
            foreach (Keys key in pressed)
            {
                // adds to the list the current action/command
                if (KeyMap.ContainsKey(key) && previousKeys.Contains(key) && pressed.Contains(key))
                {
                    // edge transition from up to down
                    KeyMap[key].execute();
                    previousKeys.Add(key);
                    // just executes ONE command
                    break;
                }
            }

            // save current keys into previous keys
            previousKeys = new List<Keys>(pressed);
        }
    }
}

