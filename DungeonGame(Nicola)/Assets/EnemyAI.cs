using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform PlayerNear;

    public Transform EnemyShoot;

    public float PlayerRange = 50f;

    public float ShootRange = 50f;

    public LayerMask layers;

    public Transform player;

    public float speed;

    private float distance;

    public Rigidbody2D rb;

    bool chasing = true;

    public Transform Head;

    Vector2 dir;

    // Update is called once per frame
    void Update() 
    { 
        Collider2D[] PlayerIsNear = Physics2D.OverlapCircleAll(PlayerNear.position, PlayerRange, layers);  

        Collider2D[] EnemyCanShoot = Physics2D.OverlapCircleAll(EnemyShoot.position, ShootRange, layers);

        foreach (Collider2D player in PlayerIsNear)
        {   
            //lookAtPlayer

            Vector2 targetPos = player.transform.position;

            dir = targetPos - (Vector2)transform.position;

            Head.up = dir;

            //
            foreach (Collider2D player2 in EnemyCanShoot)
            {   
                Shoot();
            }

            if(chasing){
                distance = Vector2.Distance(transform.position, player.transform.position);
    
                Vector2 direction = player.transform.position - transform.position;

                direction.Normalize();

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }

            chasing = true;
        }
        
            
    }
    
    void OnDrawGizmosSelected()
    {
        if (PlayerNear == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(PlayerNear.position, PlayerRange);

        if (EnemyShoot == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(EnemyShoot.position, ShootRange);
    }

    void Shoot(){
        chasing = false;

        GetComponent<Enemy_Shooting>().Shoot();
    }
}
