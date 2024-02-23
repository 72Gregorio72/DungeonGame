using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public Item addItem;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        } else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayItems();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            AddItem(addItem);
        }
    }

    public void DisplayItems()
    {
        Debug.Log("Displaying items");
        for (int i = 0; i < items.Count; i++)
        {
            if (i < slots.Length && slots[i] != null)
            {
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = items[i].itemImage;

                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString();
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.black;
                
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void AddItem(Item item){
        if(!items.Contains(item)){
            items.Add(item);
            itemNumbers.Add(1);
        } else {
            Debug.Log("Item already in inventory");
            for(int i = 0; i < items.Count; i++){
                if(items[i] == item){
                    itemNumbers[i]++;
                }
            }
        }

        DisplayItems();
    }
}
