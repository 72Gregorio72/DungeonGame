using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Vector3 mousePos;
    public Camera cam;
    public Rigidbody2D rb;
    public Transform other;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - other.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        other.rotation = rotation;
    }
}
