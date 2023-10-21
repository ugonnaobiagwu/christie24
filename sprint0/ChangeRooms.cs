using System;
using System.Collections.Generic;
using sprint0;
using sprint0.Commands;

public class ChangeRooms
{
    private List<int> rooms;
    private int currentRoomIndex;
    private int currentRoomID;
    private Dictionary<int, List<GameObject>> gameObjects;

    //Constructor, initialization, and other methods...

    public ChangeRooms(sprint0.Sprint0 Game)
    {
        GameObject obj = new GameObject();
        gameObjects = obj.getDictionary();
        rooms = obj.getRoomIDs();
        currentRoomIndex = 0;
        currentRoomID = rooms[currentRoomIndex];
    }

    public void MoveToPreviousRoom()
    {
        currentRoomIndex--;
        if (currentRoomIndex < 0)
        {
            currentRoomIndex = rooms.Count - 1; // Wrap around to the last room's index
            currentRoomID = rooms[currentRoomIndex];
        }
        //You can directly access the current room using rooms[currentRoomIndex]
        }

    public void MoveToNextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex >= rooms.Count)
        {
            currentRoomIndex = 0; // Wrap around to the first room's index
            currentRoomID = rooms[currentRoomIndex];
        }
        //You can directly access the current room using rooms[currentRoomIndex]
    }

    //returns current room ID
    public int GetCurrentRoomID()
    {
        return currentRoomID;
    }
}
