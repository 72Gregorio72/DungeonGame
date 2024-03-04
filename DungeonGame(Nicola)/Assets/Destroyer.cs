using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //public RoomSpawner1 spawner;

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if(other.transform.gameObject.GetComponent<RoomSpawner1>().isSpawned){
                Destroy(this.transform.parent.gameObject);
                Debug.Log(other.transform.parent.gameObject.transform.position);
            }
        }
    }
}
