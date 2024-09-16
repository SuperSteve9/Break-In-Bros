using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [Header("Rooms")]
    public GameObject foyer;

    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject room5;

    public GameObject stairwell;

    private void Start()
    {
        GameObject foyerroom = Instantiate(foyer);
        foyerroom.transform.position = new Vector3(0, -1, 0);
        GenerateRoom(new Vector3(0, -1, 10));
        GenerateRoom(new Vector3(0, -1, -10));
        GenerateRoom(new Vector3(10, -1, 10));
        GenerateRoom(new Vector3(10, -1, -10));
        GenerateRoom(new Vector3(10, -1, 0));
    }

    private void GenerateRoom(Vector3 pos)
    {
        int randnum = Random.Range(0, 5);
        if (randnum == 0) 
        {
            GameObject room = Instantiate(room1);
            room.transform.position = pos;
        } else if (randnum == 1) 
        {
            GameObject room = Instantiate(room2);
            room.transform.position = pos;
        } else if (randnum == 2) 
        {
            GameObject room = Instantiate(room3);
            room.transform.position = pos;
        } else if (randnum == 3) 
        {
            GameObject room = Instantiate(room4);
            room.transform.position = pos;
        } else if (randnum == 4) 
        {
            GameObject room = Instantiate(room5);
            room.transform.position = pos;
        }
    }
}
