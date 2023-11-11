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
        private ICommand linkItemUse;
        private ICommand linkSword;
        private ICommand linkEquipBow;
        private ICommand linkEquipBetterBow;
        private ICommand linkEquipBoomerang;
        private ICommand linkEquipBetterBoomerang;
        private ICommand linkEquipBomb;
        private ICommand linkEquipBlaze;
        private ICommand linkEquipSword;
        private ICommand linkDamaged;
        private ICommand previousBlock;
        private ICommand nextBlock;
        private ICommand previousItem;
        private ICommand nextItem;
        private ICommand previousEnemy;
        private ICommand nextEnemy;
        private ICommand quit;
        private ICommand reset;
        private ICommand pause;

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
            linkWalkingUp = new WalkUpCommand(Game, Globals.Link);
            linkWalkingLeft = new WalkLeftCommand(Game, Globals.Link);
            linkWalkingDown = new WalkDownCommand(Game, Globals.Link);
            linkWalkingRight = new WalkRightCommand(Game, Globals.Link);

            linkItemUse = new AttackCommand(Game, Globals.Link, Globals.LinkItemSystem);
            //linkSword = new SwingSwordCommand(Game);
            linkEquipBow = new EquipBowCommand(Game, Globals.LinkItemSystem);
            linkEquipBetterBow = new EquipBetterBowCommand(Game, Globals.LinkItemSystem);
            linkEquipBoomerang = new EquipBoomerangCommand(Game, Globals.LinkItemSystem);
            linkEquipBetterBoomerang = new EquipBetterBoomerangCommand(Game, Globals.LinkItemSystem);
            linkEquipBomb = new EquipBombCommand(Game, Globals.LinkItemSystem);
            linkEquipBlaze = new EquipBlazeCommand(Game, Globals.LinkItemSystem);
            linkEquipSword = new EquipSwordCommand(Game, Globals.LinkItemSystem);
            //pause = new PauseCommand(Game, Game.StateManager.PauseState);
            //linkDamaged = new DamagedCommand(Game);
            //nextBlock = new NextBlockCommand(Game, Game.block);
            //previousBlock = new PreviousBlockCommand(Game, Game.block);

            //previousEnemy = new PreviousEnemyCommand(Game);
            //nextEnemy = new NextEnemyCommand(Game);
            //quit = new QuitCommand(Game);
            //reset = new ResetCommand(Game);

        }

        // used to register keys with their respective commands
        // perhaps pass an array that has all the commands?
        public void registerKeys()
        {
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
            KeyMap.Add(Keys.N, linkItemUse);
            //KeyMap.Add(Keys.Z, linkSword);
            KeyMap.Add(Keys.D1, linkEquipBow);
            KeyMap.Add(Keys.D2, linkEquipBetterBow);
            KeyMap.Add(Keys.D3, linkEquipBoomerang);
            KeyMap.Add(Keys.D4, linkEquipBetterBoomerang);
            KeyMap.Add(Keys.D5, linkEquipBomb);
            KeyMap.Add(Keys.D6, linkEquipBlaze);
            KeyMap.Add(Keys.D7, linkEquipSword);
            //KeyMap.Add(Keys.E, linkDamaged);
            //KeyMap.Add(Keys.T, previousBlock);
            //KeyMap.Add(Keys.Y, nextBlock);
            //KeyMap.Add(Keys.U, previousItem);
            //KeyMap.Add(Keys.I, nextItem);
            //KeyMap.Add(Keys.O, previousEnemy);
            //KeyMap.Add(Keys.P, nextEnemy);
            KeyMap.Add(Keys.Q, quit);
            KeyMap.Add(Keys.R, reset);
            KeyMap.Add(Keys.Space, pause);

        }

        // executes commands for each key pressed
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