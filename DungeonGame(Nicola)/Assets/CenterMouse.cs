using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMouse : MonoBehaviour
{
    bool control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(control){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            control = false;
        }

        if(Input.GetKeyDown("e")){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            control = true;
        }
    }
}
