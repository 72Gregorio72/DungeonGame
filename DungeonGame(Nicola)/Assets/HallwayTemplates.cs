using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayTemplates : MonoBehaviour
{
    public GameObject[] bottomHallway;
    public GameObject[] topHallway;
    public GameObject[] leftHallway;
    public GameObject[] rightHallway;

    public GameObject closedRoom;

    public int roomsNum = 0;
    public int maxRooms;

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
        
    }
}
