using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public interface IController
{
   
    public void registerKey(Keys key, ICommand command);
    public void Update();
   

}
