using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject SpawnArea;

    float spawnTimer;
    float spawnTime;
    bool isSpawn = false;
    public float timeToSpawn;
    int currentEnemy;
    public int maxEnemy = 0;
    public bool firstEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > timeToSpawn){
            spawnTimer = 0;
            isSpawn = true;
        }

        if(isSpawn){
            Spawn();
            isSpawn = false;
        }
    }

    void Spawn(){
        firstEnemy = true;
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = SpawnArea.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for(int i = 0; i < numberToSpawn && currentEnemy < maxEnemy; i++){
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            currentEnemy++;
        }
    }
}
