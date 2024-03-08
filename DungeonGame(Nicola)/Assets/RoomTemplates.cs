using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;

    public GameObject closedRoom;

    public int roomsNum = 0;
    public int maxRooms;

    public float waitTime;

    public GameObject bossDoor;
    private bool spawnedBoss = false;

    public void AddRoom(){
        roomsNum++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && !spawnedBoss){
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1){
                    Instantiate(bossDoor, rooms[i].transform.position, Quaternion.identity);
                    waitTime = 4;
                    spawnedBoss = true;
                }
            }
        } else {
            waitTime -= Time.deltaTime;
        }
    }
}
