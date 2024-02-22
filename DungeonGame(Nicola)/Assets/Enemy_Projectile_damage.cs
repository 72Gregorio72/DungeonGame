using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile_damage : MonoBehaviour
{
    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask layers;

    public int attackDamage = 15;

    //public Animator animator;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, layers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Player_Health>().TakeDamage(attackDamage);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;

        rb.isKinematic = true;

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

        

        //animator.SetTrigger("End");
    }
}
