 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner1 : MonoBehaviour
{
    public int openingDirecion;

    public string Down1;
    public string Up2;
    public string left3;
    public string right4;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    int currentRooms;
    int maxRooms;
    public RoomsCreated rooms;

    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        rooms = GameObject.FindGameObjectWithTag("NumberOfRoom").GetComponent<RoomsCreated>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        currentRooms = rooms.roomsNum;
        maxRooms = rooms.maxRooms;
        if(currentRooms < maxRooms){
            if(!spawned){
                switch(openingDirecion){
                    case 1:{//1 = bottom

                        rand = Random.Range(0, templates.bottomRooms.Length);
                        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                        rooms.AddRoom();

                    break;
                    }

                    case 2:{//2 = top
                    
                        rand = Random.Range(0, templates.topRooms.Length);
                        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                        rooms.AddRoom();

                    break;
                    }

                    case 3:{// 3 = left

                        rand = Random.Range(0, templates.leftRooms.Length);
                        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                        rooms.AddRoom();

                    break;
                    }

                    case 4:{//4 = right

                        rand = Random.Range(0, templates.rightRooms.Length);
                        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                        rooms.AddRoom();

                    break;
                    }

                    spawned = true;
                }
            }   
        } else  if(currentRooms >= maxRooms && !spawned && openingDirecion != 0){
            Instantiate(templates.closedRoom, transform.position, transform.rotation);
            spawned = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        /*if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner1>().spawned == true && spawned == false){
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            //spawned = true;
        }*/
    }
}
