using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerTemplates : MonoBehaviour
{
    public GameObject[] bottomCorner;
    public GameObject[] topCorner;
    public GameObject[] leftCorner;
    public GameObject[] rightCorner;

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
