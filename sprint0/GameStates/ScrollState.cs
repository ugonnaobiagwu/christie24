using System;
namespace sprint0.GameStates
{
    public class ScrollState : StateManager, IState
    {
        public ScrollState()
        {
        }
        
        public void ScrollLeft(int currentRoomID, int nextRoomID)
        {
            // do logic
            ScrollTransition("scrollLeft");
        }

        public void ScrollRight(int currentRoomID, int nextRoomID)
        {
            // do logic
            ScrollTransition("scrollRight");
        }

        public void ScrollUp(int currentRoomID, int nextRoomID)
        {
            // do logic
            ScrollTransition("scrollRight");
        }

        public void ScrollDown(int currentRoomID, int nextRoomID)
        {
            // do logic
            ScrollTransition("scrollRight");
        }

        public void ScrollTransition(string scrollInstruction)
        {
            switch (scrollInstruction)
            {
                case "scrollLeft":
                    //logic
                    break;
                case "scrollRight":
                    //logic
                    break;
                case "scrollUp":
                    //logic
                    break;
                case "scrollDown":
                    //logic
                    break;
                default: break;
            }
        }
    }
}
