using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    float y = 180;

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        

        if (X == -1f)
        {
            transform.rotation = Quaternion.Euler(0f, y, 0f);
            //Debug.Log("destra");
        }

        if (X == 1f)
        {
            transform.rotation = Quaternion.Euler(0f, 4f, 0f);
            //Debug.Log("sinistra");
        }
    }
}
