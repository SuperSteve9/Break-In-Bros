using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject room5;
    public GameObject room6;

    Vector3 pos1 = new Vector3(0, 0, 10);
    Vector3 pos2 = new Vector3(0, 0, 0);
    Vector3 pos3 = new Vector3(0, 0, -10);
    Vector3 pos4 = new Vector3(10, 0, 0);
    Vector3 pos5 = new Vector3(-10, 0, 0);
    Vector3 pos6 = new Vector3(0, 5, 0);
    Vector3 pos7 = new Vector3(0, 5, 10);
    Vector3 pos8 = new Vector3(0, 5, 0);
    Vector3 pos9 = new Vector3(0, 5, -10);
    Vector3 pos10 = new Vector3(10, 5, 0);
    Vector3 pos11 = new Vector3(-10, 5, 0);

    public Vector2 stairXZ;

    public bool pos1used = false;
    public bool pos2used = false;
    public bool pos3used = false;
    public bool pos4used = false;
    public bool pos5used = false;
    public bool pos6used = false;
    public bool pos7used = false;
    public bool pos8used = false;
    public bool pos9used = false;
    public bool pos10used = false;
    public bool pos11used = false;

    bool validposfound = false;

    void Start()
    {
        GenerateRoom(room1);
        GenerateRoom(room2);
        GenerateRoom(room3);
        GenerateRoom(room4);
        GenerateRoom(room5);
        GenerateRoom(room6);
    }

    public void PlaceRoom(GameObject room, string roomName, ref bool used, Vector3 pos)
    {

        if (roomName == "Room1")
        { 
            validposfound = true;
            used = true;
            stairXZ = new Vector2(pos.x, pos.z);
            room.transform.position = pos;
            Debug.Log("Generating stairwell " + room.name + " at " + pos.ToString());
        } else {
            if (new Vector2(pos.x, pos.z) != stairXZ)
            {
                validposfound = true;
                used = true;
                room.transform.position = pos;
                Debug.Log("Generating " + room.name + " at " + pos.ToString());
            }

        }
    }

    public void GenerateRoom(GameObject room)
    {
        string roomName = room.name;
        GameObject newRoom = Instantiate(room);
        int randnum;
        validposfound = false;
        while (!validposfound)
        {
                randnum = Random.Range(1, 12);
                if (randnum == 1 && !pos1used)
                {
                    PlaceRoom(newRoom, roomName, ref pos1used, pos1);
                }
                else if (randnum == 2 && !pos2used)
                {
                    PlaceRoom(newRoom, roomName, ref pos2used, pos2);
                }
                else if (randnum == 3 && !pos3used)
                {
                    PlaceRoom(newRoom, roomName, ref pos3used, pos3);
                }
                else if (randnum == 4 && !pos4used)
                {
                    PlaceRoom(newRoom, roomName, ref pos4used, pos4);
                }
                else if (randnum == 5 && !pos5used)
                {
                    PlaceRoom(newRoom, roomName, ref pos5used, pos5);
                }
                else if (randnum == 6 && !pos6used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos6used, pos6);
                }
                else if (randnum == 7 && !pos7used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos7used, pos7);
                }
                else if (randnum == 8 && !pos8used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos8used, pos8);
                }
                else if (randnum == 9 && !pos9used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos9used, pos9);
                }
                else if (randnum == 10 && !pos10used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos10used, pos10);
                }
                else if (randnum == 11 && !pos11used && roomName != "Room1")
                {
                    PlaceRoom(newRoom, roomName, ref pos11used, pos11);
                }
        }
    }
}
