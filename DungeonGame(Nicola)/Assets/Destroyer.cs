using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //public RoomSpawner1 spawner;

    void Start(){
        //spawner = GameObject.FindGameObjectWithTag("RoomSpawner1").GetComponent<RoomSpawner1>();
    }

   void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("SpawnPoint")){
        Debug.Log("Destroying");
        if(other.GetComponent<RoomSpawner1>().openingDirecion != 0){
            Destroy(other.transform.parent.gameObject);
        }
    }
   }
}
