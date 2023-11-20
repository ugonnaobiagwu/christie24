using System;
using Microsoft.Xna.Framework;
using sprint0;
namespace sprint0.GameStates
{
    public class ScrollState : StateManager, IState
    {
        public ScrollState()
        {
        }

        public void ScrollLeft()
        {
            ScrollTransition("scrollLeft");
        }

        public void ScrollRight()
        {
            ScrollTransition("scrollRight");
        }

        public void ScrollUp()
        {
            ScrollTransition("scrollUp");
        }

        public void ScrollDown()
        {
            ScrollTransition("scrollDown");
        }

        public void ScrollTransition(string scrollInstruction)
        {
            switch (scrollInstruction)
            {
                // hopefully this works for 16x12 rooms
                case "scrollLeft":
                    Globals.Camera.MoveCameraToLeftRoom();
                    break;
                case "scrollRight":
                    Globals.Camera.MoveCameraToRightRoom();
                    break;
                case "scrollUp":
                    Globals.Camera.MoveCameraToTopRoom();
                    break;
                case "scrollDown":
                    Globals.Camera.MoveCameraToBottomRoom();
                    break;
                default: break;
            }
        }

        public Boolean TransitionComplete() { return Globals.Camera.cameraMovementComplete();  }
    }
}
