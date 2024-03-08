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
    private CornerTemplates Cornertemplates;
    private HallwayTemplates Hallwaytemplates;
    private int rand;
    private bool spawned = false;
    int currentRooms;
    int maxRooms;
    public RoomsCreated rooms;

    public bool isSpawned = false;

    public string type;

    private float waitTime = 5f;
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Cornertemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<CornerTemplates>();
        Hallwaytemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<HallwayTemplates>();
        rooms = GameObject.FindGameObjectWithTag("NumberOfRoom").GetComponent<RoomsCreated>();

        //rand = Random.Range(0, 100);

        Invoke("Spawn", 0.1f);
        Invoke("checkSpawn", 0.05f);

        Destroy(gameObject, waitTime);
    }

    void checkSpawn(){
        isSpawned = true;
        Debug.Log("Spawned: " + isSpawned);
    }

    // Update is called once per frame
    void Spawn(){
        int percentage = 0;
        currentRooms = rooms.roomsNum;
        maxRooms = rooms.maxRooms;
        if(currentRooms < maxRooms){
            if(!spawned){

                percentage = Random.Range(0, 100);

                if(type == "Room"){
                    if(percentage < 0){
                        type = "Hallway";
                    } else if(percentage < 80){
                        type = "Corner";
                    } else {
                        type = "Room";
                    }
                } else if(type == "Hallway"){
                    if(percentage < 80){
                        type = "Room";
                    } else if(percentage < 95){
                        type = "Corner";
                    } else {
                        type = "Hallway";
                    }
                } else if(type == "Corner"){
                    if(percentage < 70){
                        type = "Room";
                    } else if(percentage < 95){
                        type = "Corner";
                    } else {
                        type = "Corner";
                    }
                }

                switch(openingDirecion){
                    case 1:{//1 = bottom
                        if(type == "Room" ){
                            rand = Random.Range(0, templates.bottomRooms.Length);
                            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Corner"){
                            rand = Random.Range(0, Cornertemplates.bottomCorner.Length);
                            Instantiate(Cornertemplates.bottomCorner[rand], transform.position, Cornertemplates.bottomCorner[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Hallway"){
                            rand = Random.Range(0, Hallwaytemplates.bottomHallway.Length);
                            Instantiate(Hallwaytemplates.bottomHallway[rand], transform.position, Hallwaytemplates.bottomHallway[rand].transform.rotation);
                            rooms.AddRoom();
                        }  

                    break;
                    }

                    case 2:{//2 = top
                            if(type == "Room" ){
                            rand = Random.Range(0, templates.topRooms.Length);
                            Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Corner"){
                            rand = Random.Range(0, Cornertemplates.topCorner.Length);
                            Instantiate(Cornertemplates.topCorner[rand], transform.position, Cornertemplates.topCorner[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Hallway"){
                            rand = Random.Range(0, Hallwaytemplates.topHallway.Length);
                            Instantiate(Hallwaytemplates.topHallway[rand], transform.position, Hallwaytemplates.topHallway[rand].transform.rotation);
                            rooms.AddRoom();
                        }

                    break;
                    }

                    case 3:{// 3 = left
                        if(type == "Room" ){
                            rand = Random.Range(0, templates.leftRooms.Length);
                            Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Corner"){
                            rand = Random.Range(0, Cornertemplates.leftCorner.Length);
                            Instantiate(Cornertemplates.leftCorner[rand], transform.position, Cornertemplates.leftCorner[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Hallway"){
                            rand = Random.Range(0, Hallwaytemplates.leftHallway.Length);
                            Instantiate(Hallwaytemplates.leftHallway[rand], transform.position, Hallwaytemplates.leftHallway[rand].transform.rotation);
                            rooms.AddRoom();
                        }

                    break;
                    }

                    case 4:{//4 = right
                        if(type == "Room" ){
                            rand = Random.Range(0, templates.rightRooms.Length);
                            Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Corner"){
                            rand = Random.Range(0, Cornertemplates.rightCorner.Length);
                            Instantiate(Cornertemplates.rightCorner[rand], transform.position, Cornertemplates.rightCorner[rand].transform.rotation);
                            rooms.AddRoom();
                        } else if(type == "Hallway"){
                            rand = Random.Range(0, Hallwaytemplates.rightHallway.Length);
                            Instantiate(Hallwaytemplates.rightHallway[rand], transform.position, Hallwaytemplates.rightHallway[rand].transform.rotation);
                            rooms.AddRoom();
                        }

                    break;
                    }
                }
                spawned = true;
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
