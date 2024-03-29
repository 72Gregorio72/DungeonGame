using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescr;

    public Sprite itemImage;
    public int itemPrice;

    public GameObject itemPrefab;
    
}
