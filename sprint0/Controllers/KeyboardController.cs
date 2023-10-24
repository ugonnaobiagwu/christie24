using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0.Blocks;
using sprint0;

namespace sprint0.Controllers
{
    public class KeyboardController : IController
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
            /*    linkWalkingUp = new WalkUpCommand(Game);
                linkWalkingLeft = new WalkLeftCommand(Game);
                linkWalkingDown = new WalkDownCommand(Game);
                linkWalkingRight = new WalkRightCommand(Game);
                linkAttack1 = new AttackCommand(Game);
                linkAttack2 = new AttackCommand(Game);
                linkEquipItem1 = new EquipItem1Command(Game);
                linkEquipItem2 = new EquipItem2Command(Game);
                linkDamaged = new DamagedCommand(Game);*/
            nextBlock = new NextBlockCommand(Game, Game.block);
            previousBlock = new PreviousBlockCommand(Game, Game.block);
            previousItem = new PreviousItemCommand(Game, Game.groundItems);
            nextItem = new NextItemCommand(Game, Game.groundItems);
            /*previousEnemy = new PreviousEnemyCommand(Game);
            nextEnemy = new NextEnemyCommand(Game);*/
            //quit = new QuitCommand(Game);
            //reset = new ResetCommand(Game);

        }

        // used to register keys with their respective commands
        // perhaps pass an array that has all the commands?
        public void registerKeys()
        {
            // KeyMap[key] = command;
            // Names of Commands are not permanent

            // Movement Controls
            // link moves up for up arrow key, and w key
            KeyMap.Add(Keys.W, linkWalkingUp);
            KeyMap.Add(Keys.Up, linkWalkingUp);
            // link moves left for left arrow key, and a key
            KeyMap.Add(Keys.A, linkWalkingLeft);
            KeyMap.Add(Keys.Left, linkWalkingLeft);
            // link moves down for down arrow key, and s key
            KeyMap.Add(Keys.S, linkWalkingDown);
            KeyMap.Add(Keys.Down, linkWalkingDown);
            // link moves right for right arrow key, and d key
            KeyMap.Add(Keys.D, linkWalkingRight);
            KeyMap.Add(Keys.Right, linkWalkingRight);

            // other commands
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
            // testing purposes
            //Keys[] Pressed = Keyboard.GetState().GetPressedKeys();
            //foreach (Keys key in Pressed)
            //{
            //    KeyMap[key].execute();
            //}

            // EDGE TRANSITIONS
            // If a key is in pressed but not in previousKeys
            // it means it was just pressed, so we execute.
            // If a key is in previousKeys but not in pressed
            // it means it was just released, so we discard it
            // we then execute the 'last' pressed key
            pressed = new List<Keys>(Keyboard.GetState().GetPressedKeys());
            Keys lastPressed = Keys.None;

            // press transitions
            foreach (Keys key in pressed)
            {
                // adds to the list the current action/command
                if (!previousKeys.Contains(key) && pressed.Contains(key) && KeyMap.ContainsKey(key))
                {
                    // edge transition from up to down
                    KeyMap[key].execute();
                    previousKeys.Add(key);
                    lastPressed = key;
                    // just executes ONE command
                    break;
                }
            }
            // release transititions
            /*foreach (Keys key in previousKeys)
            {
                // removes previously pressed and executed keys
                if (!pressed.Contains(key))
                {
                    previousKeys.Remove(key);
                }
            }*/

            // executes the last command 
            /*if (lastPressed != Keys.None)
            {
                KeyMap[lastPressed].execute();
            }*/

            // save current keys into previous keys
            previousKeys = new List<Keys>(pressed);
        }
    }
}