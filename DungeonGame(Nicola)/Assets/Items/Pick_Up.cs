using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if(GameManager.instance.itemNumbers.Count < GameManager.instance.slots.Length){
                //add item to the list 
            GameManager.instance.AddItem(item);
            Destroy(gameObject);
            } else {
                //inventory is full
                Debug.Log("Inventory is full");
            }
        }
    }
}
