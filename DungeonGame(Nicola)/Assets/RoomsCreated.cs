using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCreated : MonoBehaviour
{
    public int roomsNum = 0;
    public int maxRooms = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRoom(string type){
        if(type == "Room"){
            roomsNum++;
        }
    }

    public void RemoveRoom(string type){
        if(type == "Room"){
            roomsNum--;
        }
    }
}
