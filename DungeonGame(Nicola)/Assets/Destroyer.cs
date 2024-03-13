using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //public RoomSpawner1 spawner;

    private RoomTemplates templates;

    public RoomsCreated rooms;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        rooms = GameObject.FindGameObjectWithTag("NumberOfRoom").GetComponent<RoomsCreated>();
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if(other.transform.gameObject.GetComponent<RoomSpawner1>().isSpawned){
                Destroy(this.transform.parent.gameObject);
                templates.rooms.Remove(this.transform.parent.gameObject);
                rooms.RemoveRoom(this.gameObject.GetComponent<RoomSpawner1>().type);
            }
        }
    }
}
