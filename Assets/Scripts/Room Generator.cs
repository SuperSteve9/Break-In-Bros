using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject Foyer;
    public GameObject Stairwell;
    public GameObject DiningRoom;
    private struct RoomCoordinate
    {
        public int x, y, z;
    }
    private List<RoomCoordinate> RoomCoordinateList = new List<RoomCoordinate>();

    private void Start()
    {
        GameObject frontDoor =  Instantiate(Foyer);
        frontDoor.transform.position = new Vector3(0, -1, 0);
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = -1, z = 0 });
        GenerateRoom(Stairwell);

    }

    private void GenerateRoom(GameObject originalRoom)
    {
        GameObject room = Instantiate(originalRoom);
        bool hasGeneratedRoom = false;
        while (!hasGeneratedRoom) 
        {
            int Randint = Random.Range(0, 12);
            if (Randint == 0)
            {
                room.transform.position = new Vector3(-20, -1, 0);
                RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = -1, z = 0 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 1)
            {
                room.transform.position = new Vector3(-10, -1, 0);
                RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = -1, z = 0 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 2)
            {
                room.transform.position = new Vector3(10, -1, 0);
                RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = -1, z = 0 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 3)
            {
                room.transform.position = new Vector3(-20, -1, 10);
                RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = -1, z = 10 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 4)
            {
                room.transform.position = new Vector3(-10, -1, 10);
                RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = -1, z = 10 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 5)
            {
                room.transform.position = new Vector3(0, -1, 10);
                RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = -1, z = 10 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 6)
            {
                room.transform.position = new Vector3(10, -1, 10);
                RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = -1, z = 10 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 7)
            {
                room.transform.position = new Vector3(-20, -1, 20);
                RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = -1, z = 20 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 8)
            {
                room.transform.position = new Vector3(-20, -1, 20);
                RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = -1, z = 20 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 9)
            {
                room.transform.position = new Vector3(-10, -1, 20);
                RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = -1, z = 20 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 10)
            {
                room.transform.position = new Vector3(0, -1, 20);
                RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = -1, z = 20 });
                hasGeneratedRoom = true;
            }
            else if (Randint == 11)
            {
                room.transform.position = new Vector3(10, -1, 20);
                RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = -1, z = 20 });
                hasGeneratedRoom = true;
            }
        }
    }
}
