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
    public Item addItem1;

    public ItemButton thisButton;
    public ItemButton[] itemButtons;

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

        if(Input.GetKeyDown(KeyCode.H)){
            AddItem(addItem1);
        }

        if(Input.GetKeyDown(KeyCode.G)){
            RemoveItem(addItem);
        }

        if(Input.GetKeyDown(KeyCode.J)){
            RemoveItem(addItem1);
        }
    }

    public void DisplayItems()
    {
        #region 
        /*for (int i = 0; i < items.Count; i++)
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
        }*/
        #endregion

        for(int i = 0; i < slots.Length; i++){
            if(i < items.Count){
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = items[i].itemImage;

                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemNumbers[i].ToString();
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.black;
                
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            } else {
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = null;

                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = null;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = Color.black;
                
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
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

    public void RemoveItem(Item item){
        if(items.Contains(item)){
            for(int i = 0; i < items.Count; i++){
                if(items[i] == item){
                    itemNumbers[i]--;
                    if(itemNumbers[i] == 0){
                        items.Remove(item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        } else {
            Debug.Log("Item not in inventory");
        }
        ResetButtonItems();
        DisplayItems();
    }

    public void ResetButtonItems(){
        for(int i = 0; i < itemButtons.Length; i++){
            if(i < items.Count){
                itemButtons[i].thisItem = items[i];
                itemButtons[i].buttonID = i;
            } else {
                itemButtons[i].thisItem = null;
                itemButtons[i].buttonID = i;
            }
        }
    }
}
