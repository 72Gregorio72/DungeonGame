using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    public Transform shotPoint;
    public float launchforce = 0f;

    float shootTimer;
    public float shootTime;
    bool isShoot = false;
    bool startCount = true;
    float dir = 1;

    // Update is called once per frame
    void Update()
    {

        if(shootTimer < shootTime && startCount)
        {
            shootTimer += Time.deltaTime;
        }

        if (shootTimer >= shootTime)
        {
            isShoot = true;

            shootTimer = 0;

            startCount = false;
        }

        if (Input.GetButton("Fire1"))
        {
            if(shootTimer <= 0){
                Shoot();
            }
            
        }
    }

    public void Shoot(){

        GameObject newArrow = Instantiate(projectile, shotPoint.position, shotPoint.rotation);

        newArrow.GetComponent<Rigidbody2D>().AddForce(shotPoint.up * launchforce, ForceMode2D.Impulse);

        startCount = true;
    }
}
