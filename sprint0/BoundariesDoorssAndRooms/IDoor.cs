using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.BoundariesDoorsAndRooms
{
    public interface IDoor : IGameObject
    {
        public enum DoorState { Open, Closed, Locked, Bombable, Exploded, Wall }
        public DoorState GetState();
        public void SetState(DoorState state);
        public int GetToRoomId();
        public void SetToRoomId(int roomId);
    }
}