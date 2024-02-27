using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerHitbox : MonoBehaviour
{
    public SceneChanger sm;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the one you are interested in
        if (other.CompareTag("Player"))
        {
            sm.LoadScene("Dungeon");
        }
    }
}
