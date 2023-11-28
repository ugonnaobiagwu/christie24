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

        private ICommand linkEquipBowA;
        private ICommand linkEquipBowB;

        private ICommand linkEquipBetterBowA;
        private ICommand linkEquipBetterBowB;

        private ICommand linkEquipBoomerangA;
        private ICommand linkEquipBoomerangB;

        private ICommand linkEquipBetterBoomerangA;
        private ICommand linkEquipBetterBoomerangB;

        private ICommand linkEquipBombA;
        private ICommand linkEquipBombB;

        private ICommand linkEquipBlazeA;
        private ICommand linkEquipBlazeB;

        private ICommand linkEquipSwordA;
        private ICommand linkEquipSwordB;

        private ICommand SelectItem;

        private ICommand leftScroll;

        public float inputPoll = 0.5f;
        public bool inputLimit = false;
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

            linkEquipBowA = new EquipBowToACommand();
            linkEquipBowB = new EquipBowToBCommand();
            linkEquipBetterBowA = new EquipBetterBowToACommand();
            linkEquipBetterBowB = new EquipBetterBowToBCommand();
            linkEquipBoomerangA = new EquipBoomerangToACommand();
            linkEquipBoomerangB = new EquipBoomerangToBCommand();
            linkEquipBetterBoomerangA = new EquipBetterBoomerangToACommand();
            linkEquipBetterBoomerangB = new EquipBetterBoomerangToBCommand();
            linkEquipBlazeA = new EquipBlazeToACommand();
            linkEquipBlazeB = new EquipBlazeToBCommand();
            linkEquipBombA = new EquipBombToACommand();
            linkEquipBombB = new EquipBombToBCommand();
            linkEquipSwordA = new EquipSwordToACommand();
            linkEquipSwordB = new EquipSwordToBCommand();
            SelectItem = new SelectItem(Game, cursor, linkEquipBow, linkEquipBomb, linkEquipBoomerang, linkEquipBlaze);
            leftScroll = new LeftScrollCommand(Game);
        }
        public void registerKeys()
        {
            KeyMap.Add(Keys.W, cursorUp);
            KeyMap.Add(Keys.A, cursorLeft);
            KeyMap.Add(Keys.S, cursorDown);
            KeyMap.Add(Keys.D, cursorRight);

            KeyMap.Add(Keys.J, leftScroll);
            KeyMap.Add(Keys.B, SelectItem);
        }

        public void Update()
        {
            inputPoll -= Globals.TotalSeconds;
            if (inputPoll <= 0)
            {
                inputPoll += 0.5f;
                inputLimit = false;
            }

            // EDGE TRANSITIONS
            // If a key is in pressed but not in previousKeys
            // it means it was just pressed, so we execute.
            pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());

            // press transitions
            if (!inputLimit)
            {
                foreach (Keys key in pressed)
                {
                    // adds to the list the current action/command
                    if (KeyMap.ContainsKey(key) && previousKeys.Contains(key) && pressed.Contains(key))
                    {
                        // edge transition from up to down
                        KeyMap[key].execute();
                        previousKeys.Add(key);
                        // just executes ONE command
                        inputLimit = true;
                        break;
                    }
                }
            }
            // save current keys into previous keys
            previousKeys = new List<Keys>(pressed);
        }
    }
}

