using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;

    public Transform shotPoint;

    Transform player;

    public Rigidbody2D rb;

    public Camera cam;

    public Transform camera;

    Vector2 movement;
    Vector2 mousePos;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        GameObject other = GameObject.FindGameObjectWithTag("Player");

        player = other.transform;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x += camera.position.x;

        Vector3 mP = Input.mousePosition;

        float difX = player.position.x - mousePos.x;

        if(difX < 0){
            difX *= -1;
        }

        float difY = player.position.y - mousePos.y;

        if(difY < 0){
            difY *= -1;
        }

        /*if(difX > difY){
            if(player.position.x - mousePos.x > 0){
                anim.SetFloat("Horizontal", -1);
                anim.SetFloat("Vertical", 0);
            } else {
                anim.SetFloat("Horizontal", 1);
                anim.SetFloat("Vertical", 0);
            }
        } else {
            if(player.position.y - mousePos.y > 0){
                anim.SetFloat("Vertical", -1);
                anim.SetFloat("Horizontal", 0);
            } else {
                anim.SetFloat("Vertical", 1);
                anim.SetFloat("Horizontal", 0);
            }
        }*/

        if(player.position.x - mousePos.x > 0){
                anim.SetFloat("Horizontal", -1);
                anim.SetFloat("Vertical", 0);
            } else {
                anim.SetFloat("Horizontal", 1);
                anim.SetFloat("Vertical", 0);
            }
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);

        /*
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;*/
    }
}
