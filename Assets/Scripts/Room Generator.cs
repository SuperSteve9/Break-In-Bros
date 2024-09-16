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

    int x, y;

    private void Start()
    {
        GameObject foyerroom = Instantiate(foyer);
        foyerroom.transform.position = new Vector3(0, -1, 0);
        LoopGeneration();
        LoopGeneration();
        LoopGeneration();
        LoopGeneration();
    }

    private void GenerateRoom(Vector3 pos)
    {
        int randnum = Random.Range(0, 6);
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
        } else if (randnum == 5)
        {
            GameObject room = Instantiate(stairwell);
            room.transform.position = pos;
        }
    }

    private void LoopGeneration()
    {
        for (int i = 0; i < 20; i++)
        {
            int direction = Random.Range(0, 4);
            if (direction == 0)
            {
                x += 10;
                GenerateRoom(new Vector3(x, -1, y));
            }
            else if (direction == 1)
            {
                y += 10;
                GenerateRoom(new Vector3(x, -1, y));
            }
            else if (direction == 2) 
            {
                x -= 10;
                GenerateRoom(new Vector3(x, -1, y));    
            } else if (direction == 3) 
            {
                y -= 10;
                GenerateRoom(new Vector3(x, -1, y));
            }
        }
        x = 0;
        y = 0;
    }
}
