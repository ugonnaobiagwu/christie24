using System;
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
                    Globals.Camera.MoveCameraLeft(16);
                    break;
                case "scrollRight":
                    Globals.Camera.MoveCameraRight(16);
                    break;
                case "scrollUp":
                    Globals.Camera.MoveCameraUp(12);
                    break;
                case "scrollDown":
                    Globals.Camera.MoveCameraDown(12);
                    break;
                default: break;
            }
        }
    }
}
