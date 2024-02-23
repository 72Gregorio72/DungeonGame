using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject projectile;
    //public Transform player;
    public Transform shotPoint;
    public float launchforce = 0f;

    float shootTimer;
    public float shootTime;
    bool isShoot = false;
    bool startCount = true;
    //float dir = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(){
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootTime)
        {
            isShoot = true;

            shootTimer = 0;

            startCount = false;
        }

        if(isShoot){
            GameObject newArrow = Instantiate(projectile, shotPoint.position, shotPoint.rotation);

            newArrow.GetComponent<Rigidbody2D>().AddForce(shotPoint.up * launchforce, ForceMode2D.Impulse);

            startCount = true;

            isShoot = false;
        }
        
    }
}
