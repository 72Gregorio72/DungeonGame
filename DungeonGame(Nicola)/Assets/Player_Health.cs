using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    //public Health_Bar healthbar;

    public int maxHealth = 100;

    public int currentHealth;

    public int damage = 20;

    public bool shield = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        if(!shield)
        {
            currentHealth -= damage;

            //healthbar.SetHealth(currentHealth); 

            if(currentHealth <= 0)
            {
                Die();
            }
        }
        
    }

    void Die()
    {
        Debug.Log("U DIED");
    }
}
