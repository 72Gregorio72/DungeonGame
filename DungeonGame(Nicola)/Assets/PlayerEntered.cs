using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntered : MonoBehaviour
{
    bool spawnable = false;
    public GameObject spawnArea;
    public GameObject doors;
    public Animator anim;
    public bool isEnemy = true;

    public Transform enemies;
    public float enemyRange = 50f;
    public LayerMask layers;
    public spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesInside = Physics2D.OverlapCircleAll(enemies.position, enemyRange, layers);

        foreach (Collider2D player2 in enemiesInside)
        {   
            isEnemy = true;
        }

        if(!isEnemy && spawner.firstEnemy){
            Debug.Log("ciao");
            PlayerFinished();
        }

        if(spawnable){
            Invoke("PlayerEnteredRoom", 0.5f);  
        }

        isEnemy = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            spawnable = true;
        } 
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            enemies++;
            Debug.Log(enemies);
        }
    }*/

    void PlayerEnteredRoom(){
        spawnArea.active = true;
        doors.active = true;
        anim.SetBool("RoomIsOpen", false);
        spawnable = false;
    }

    void PlayerFinished(){
        spawnArea.active = false;
        doors.active = false;
        anim.SetBool("RoomIsOpen", true);
    }

    /*void EnemiesCheck(){     
        if(!isEnemy){
            Debug.Log("ciao");
            //PlayerFinished();
        }
    }*/

    void OnDrawGizmosSelected()
    {
        if (enemies == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(enemies.position, enemyRange);
    }
}
