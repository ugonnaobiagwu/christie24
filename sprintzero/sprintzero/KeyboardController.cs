using System;
using Microsoft.Xna.Framework.Input;
using static sprintzero.Game1;
using System.Collections.Generic;

namespace sprintzero
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, int> KeyboardMappings;
        private KeyboardState currentState;

        private void CreateMappings()
        {
            Dictionary<Keys, int> keyboardMappings =
               new Dictionary<Keys, int>();
            keyboardMappings.Add(Keys.D0, 0); //quit
            keyboardMappings.Add(Keys.D1, 1); //nonMovingNonAnimatedSprite
            keyboardMappings.Add(Keys.D2, 2); //nonMovingAnimatedSprite
            keyboardMappings.Add(Keys.D3, 3); //movingNonAnimatedSprite
            keyboardMappings.Add(Keys.D4, 4); //movingAnimatedSprite
            KeyboardMappings = keyboardMappings;
        }

        public KeyboardController()
        {
            CreateMappings();
        }

        public int processInput()
        {
            int input = -1;
            currentState = Keyboard.GetState();
            Keys[] currentlyPressedKeys = currentState.GetPressedKeys();
            foreach (Keys x in currentlyPressedKeys)
            {
                if (KeyboardMappings.ContainsKey(x))
                {
                    input = KeyboardMappings.GetValueOrDefault(x);
                }
            }
            return input;
        }

    }
}

