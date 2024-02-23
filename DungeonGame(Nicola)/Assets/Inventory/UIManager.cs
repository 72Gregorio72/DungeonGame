using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject inventoryMenu;


    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryControl();
    }

    void InventoryControl(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameManager.instance.isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        inventoryMenu.gameObject.SetActive(false);
        GameManager.instance.isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void Pause(){
        inventoryMenu.gameObject.SetActive(true);
        GameManager.instance.isPaused = true;
        Time.timeScale = 0.0f;
    }
}
