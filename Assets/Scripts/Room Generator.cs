using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject Foyer;
    public GameObject LivingRoom;
    public GameObject DiningRoom;
    private class RoomCoordinate
    {
        public int x, y, z;
        public bool hasRoom = false;
    }
    private List<RoomCoordinate> RoomCoordinateList = new List<RoomCoordinate>();

    private void Start()
    {
        AddRoomsToList();
        GenerateRoom();
        GenerateLivingRoom();
        // RoomCoordinateList[11].hasRoom = true;
        GenerateDiningRoom();
    }

    private void AddRoomsToList()
    {
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 0, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 0, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 0, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 0, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 0, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 0, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 0, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 0, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 0, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 0, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 0, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 0, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 1, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 1, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 1, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 1, z = 0 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 1, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 1, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 1, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 1, z = 10 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -20, y = 1, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = -10, y = 1, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 0, y = 1, z = 20 });
        RoomCoordinateList.Add(new RoomCoordinate { x = 10, y = 1, z = 20 });
    }

   private void GenerateRoom()
    {
        RoomCoordinateList[2].hasRoom = true;
        GameObject room = Instantiate(Foyer);
        room.transform.position = new Vector3(0, 0, 0);
    }

    private void GenerateLivingRoom()
    {
        int location = Random.Range(0, 4);
        // int location = 0;
        Debug.Log(location);
        if (location == 0)
        {
            RoomCoordinateList[0].hasRoom = true;
            RoomCoordinateList[1].hasRoom = true;
            RoomCoordinateList[4].hasRoom = true;
            RoomCoordinateList[5].hasRoom = true;
            GameObject lr = Instantiate(LivingRoom);
            lr.transform.position = new Vector3(-15, 0, 5);

        }
        else if (location == 1)
        {
            RoomCoordinateList[4].hasRoom = true;
            RoomCoordinateList[5].hasRoom = true;
            RoomCoordinateList[8].hasRoom = true;
            RoomCoordinateList[9].hasRoom = true;
            GameObject lr = Instantiate(LivingRoom);
            lr.transform.position = new Vector3(-15, 0, 15);
        }
        else if (location == 2)
        {
            RoomCoordinateList[5].hasRoom = true;
            RoomCoordinateList[6].hasRoom = true;
            RoomCoordinateList[9].hasRoom = true;
            RoomCoordinateList[10].hasRoom = true;
            GameObject lr = Instantiate(LivingRoom);
            lr.transform.position = new Vector3(-5, 0, 15);
        }
        else if (location == 3)
        {
            RoomCoordinateList[6].hasRoom = true;
            RoomCoordinateList[7].hasRoom = true;
            RoomCoordinateList[11].hasRoom = true;
            RoomCoordinateList[12].hasRoom = true;
            GameObject lr = Instantiate(LivingRoom);
            lr.transform.position = new Vector3(5, 0, 15);
        }
    }

    private void GenerateDiningRoom()
    {
        bool genHap = false;
        while (!genHap)
        {
            int location = Random.Range(0, 9);
            //int location = 5;
            Debug.Log(location);
            if (location == 0 && !RoomCoordinateList[0].hasRoom)
            {
                if (!RoomCoordinateList[4].hasRoom)
                {
                    RoomCoordinateList[0].hasRoom = true;
                    RoomCoordinateList[4].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-20, 0, 5);
                    genHap = true;
                }
                else
                {
                    RoomCoordinateList[0].hasRoom = true;
                    RoomCoordinateList[1].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-15, 0, 0);
                    dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                    genHap = true;
                }
            }
            else if (location == 1 && !RoomCoordinateList[4].hasRoom)
            {
                if (!RoomCoordinateList[8].hasRoom)
                {
                    RoomCoordinateList[4].hasRoom = true;
                    RoomCoordinateList[8].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-20, 0, 15);
                    genHap = true;
                }
                else
                {
                    RoomCoordinateList[4].hasRoom = true;
                    RoomCoordinateList[5].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-15, 0, 10);
                    dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                    genHap = true;
                }
            }
            else if (location == 2 && (!RoomCoordinateList[8].hasRoom && !RoomCoordinateList[9].hasRoom))
            {
                RoomCoordinateList[8].hasRoom = true;
                RoomCoordinateList[9].hasRoom = true;
                GameObject dr = Instantiate(DiningRoom);
                dr.transform.position = new Vector3(-15, 0, 20);
                dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                genHap = true;
            }
            else if (location == 3 && (!RoomCoordinateList[1].hasRoom && !RoomCoordinateList[5].hasRoom))
            {
                RoomCoordinateList[1].hasRoom = true;
                RoomCoordinateList[5].hasRoom = true;
                GameObject dr = Instantiate(DiningRoom);
                dr.transform.position = new Vector3(-10, 0, 5);
                genHap = true;
            }
            else if (location == 4 && !RoomCoordinateList[5].hasRoom)
            {
                if (!RoomCoordinateList[10].hasRoom)
                {
                    RoomCoordinateList[5].hasRoom = true;
                    RoomCoordinateList[10].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-10, 0, 15);
                    genHap = true;
                }
                else
                {
                    RoomCoordinateList[5].hasRoom = true;
                    RoomCoordinateList[6].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(-5, 0, 10);
                    dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                    genHap = true;
                }
            }
            else if (location == 5 && !RoomCoordinateList[6].hasRoom)
            {
                if (!RoomCoordinateList[11].hasRoom)
                {
                    RoomCoordinateList[6].hasRoom = true;
                    RoomCoordinateList[11].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(0, 0, 15);
                    genHap = true;
                }
                else if (!RoomCoordinateList[7].hasRoom)
                {
                    RoomCoordinateList[6].hasRoom = true;
                    RoomCoordinateList[7].hasRoom = true;
                    GameObject dr = Instantiate(DiningRoom);
                    dr.transform.position = new Vector3(5, 0, 10);
                    dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                    genHap = true;
                }
            }
            else if (location == 6 && (!RoomCoordinateList[10].hasRoom && !RoomCoordinateList[11].hasRoom))
            {
                RoomCoordinateList[10].hasRoom = true;
                RoomCoordinateList[11].hasRoom = true;
                GameObject dr = Instantiate(DiningRoom);
                dr.transform.position = new Vector3(5, 0, 20);
                dr.transform.rotation = Quaternion.Euler(0, 90, 0);
                genHap = true;
            } 
            else if (location == 7 && !RoomCoordinateList[3].hasRoom)
            {
                RoomCoordinateList[3].hasRoom = true;
                RoomCoordinateList[7].hasRoom = true;
                GameObject dr = Instantiate(DiningRoom);
                dr.transform.position = new Vector3(10, 0, 5);
                genHap = true;
            }
            else if (location == 8 && !RoomCoordinateList[7].hasRoom)
            {
                RoomCoordinateList[7].hasRoom = true;
                RoomCoordinateList[11].hasRoom = true;
                GameObject dr = Instantiate(DiningRoom);
                dr.transform.position = new Vector3(10, 0, 15);
                genHap = true;
            }
        }
    }

}
