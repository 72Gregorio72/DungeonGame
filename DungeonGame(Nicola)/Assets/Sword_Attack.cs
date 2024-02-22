using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Attack : MonoBehaviour
{
    public Transform PlayerNear;

    public float PlayerRange = 50f;

    public LayerMask layers;

    public int attackDamage;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Collider2D[] PlayerIsNear = Physics2D.OverlapCircleAll(PlayerNear.position, PlayerRange, layers);  

            foreach (Collider2D enemy in PlayerIsNear){
                enemy.GetComponent<Enemy_Health>().TakeDamage(attackDamage);
            }

            anim.SetTrigger("Sword_Attack");
        } 
        
    }

    void OnDrawGizmosSelected()
    {
        if (PlayerNear == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(PlayerNear.position, PlayerRange);
    }

}
