using System;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is colliding with the item
            Collider2D playerCollider = GetComponent<Collider2D>();
            Collider2D[] colliders = Physics2D.OverlapBoxAll(playerCollider.bounds.center, playerCollider.bounds.size, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    if (GameManager.instance.itemNumbers.Count < GameManager.instance.slots.Length)
                    {
                        // Add item to the list 
                        GameManager.instance.AddItem(item);
                        Destroy(gameObject);
                    }
                    else
                    {
                        // Inventory is full
                        Debug.Log("Inventory is full");
                    }
                }
            }
        }
    }
    /*
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
    }*/
}
